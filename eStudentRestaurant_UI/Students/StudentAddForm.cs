﻿using eStudentRestaurant_API.Models;
using eStudentRestaurant_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStudentRestaurant_UI.Students
{
    public partial class StudentAddForm : Form
    {
        private WebAPIHelper citiesServices = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.CitiesRoutes);
        private WebAPIHelper studentService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.StudentsRoutes);


        public StudentAddForm()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void StudentAddForm_Load(object sender, EventArgs e)
        {
            #region GetCities
            HttpResponseMessage responseCities = citiesServices.GetResponse();
            List<City> cities = new List<City>();
            if (responseCities.IsSuccessStatusCode)
            {
                cities = responseCities.Content.ReadAsAsync<List<City>>().Result;
            }
            List<ComboItem> comboItems = new List<ComboItem>();

            foreach (City item in cities)
            {
                comboItems.Add(new ComboItem { ID = item.CityID, Text = item.Name });
            }

            CityComboBox.DataSource = comboItems;
            #endregion
        }

        #region validating

        private void FirstNameInput_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(FirstNameInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(FirstNameInput, Messages.Required_Error);
            }
            else if (FirstNameInput.TextLength > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(FirstNameInput, Messages.overflow_err);
            }
            else if (FirstNameInput.Text.Any(char.IsDigit))
            {
                e.Cancel = true;
                errorProvider.SetError(FirstNameInput, Messages.number_err);
            }
            else
            {
                errorProvider.SetError(FirstNameInput, "");
            }


        }

        private void LastNameInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(LastNameInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(LastNameInput, Messages.Required_Error);
            }
            else if (LastNameInput.TextLength > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(LastNameInput, Messages.overflow_err);
            }
            else if (LastNameInput.Text.Any(char.IsDigit))
            {
                e.Cancel = true;
                errorProvider.SetError(LastNameInput, Messages.number_err);
            }
            else
            {
                errorProvider.SetError(LastNameInput, "");
            }
        }

        private void JmbgInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(JmbgInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(JmbgInput, Messages.Required_Error);
            }
            else if (JmbgInput.TextLength != 13 || JmbgInput.Text.Any(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider.SetError(JmbgInput, Messages.jmbg_err);
            }

            else
            {
                errorProvider.SetError(JmbgInput, "");
            }
        }



        private void AddressInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(AddressInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(AddressInput, Messages.Required_Error);
            }
            else if (AddressInput.TextLength > 100)
            {
                e.Cancel = true;
                errorProvider.SetError(AddressInput, Messages.overflow_err);
            }
            else
            {
                errorProvider.SetError(AddressInput, "");
            }
        }

        private void UsernameInput_Validating(object sender, CancelEventArgs e)
        {
            HttpResponseMessage res = studentService.GetActionResponse("UsernameExist", UsernameInput.Text);

            if (String.IsNullOrEmpty(UsernameInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(UsernameInput, Messages.Required_Error);
            }
            else if (UsernameInput.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(UsernameInput, Messages.Error);
            }
            else if (UsernameInput.TextLength > 100)
            {
                e.Cancel = true;
                errorProvider.SetError(UsernameInput, Messages.overflow_err);
            }

            else if (res.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                e.Cancel = true;
                errorProvider.SetError(UsernameInput, Messages.username_ex_err);
            }

            else
                errorProvider.SetError(UsernameInput, null);



        }

        private void PasswordInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(PasswordInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(PasswordInput, Messages.Required_Error);
            }
            else if (PasswordInput.TextLength < 6 || !PasswordInput.Text.Any(char.IsDigit) || !PasswordInput.Text.Any(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider.SetError(PasswordInput, Messages.pass_err);
            }
            else
                errorProvider.SetError(PasswordInput, null);

        }


        private void CityComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(CityComboBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(CityComboBox, Messages.Required_Error);
            }
            else
                errorProvider.SetError(CityComboBox, null);
        }

        private void BirthDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(BirthDatePicker.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(BirthDatePicker, Messages.Required_Error);
            }
            else
                errorProvider.SetError(BirthDatePicker, null);
        }

     

        private void PhoneInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(PhoneInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(PhoneInput, Messages.Required_Error);
            }
            else
                errorProvider.SetError(PhoneInput, null);
        }
        #endregion

        private void SaveStudentButton_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                Student newStudent = new Student();
                newStudent.FirstName = FirstNameInput.Text;
                newStudent.LastName = LastNameInput.Text;
                newStudent.JMBG = JmbgInput.Text;
                newStudent.BirthDate = DateTime.Parse(BirthDatePicker.Text);


                newStudent.Address_ = AddressInput.Text;
                newStudent.Phone = PhoneInput.Text;

                newStudent.CityID = (int)CityComboBox.SelectedValue;

                newStudent.Username = UsernameInput.Text;
                newStudent.PasswordSalt = UIHelper.GenerateSalt();
                newStudent.PaswordHash = UIHelper.GenerateHash(newStudent.PasswordSalt, PasswordInput.Text);
                newStudent.Active = true;


                HttpResponseMessage response = studentService.PostResponse(newStudent);



                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(Messages.add_usr_succ, Messages.msg_succ, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string msg = response.ReasonPhrase;

                    if (!String.IsNullOrEmpty(Messages.ResourceManager.GetString(response.ReasonPhrase)))
                        msg = Messages.ResourceManager.GetString(response.ReasonPhrase);

                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + msg);
                }
            }
        }
    }
}
