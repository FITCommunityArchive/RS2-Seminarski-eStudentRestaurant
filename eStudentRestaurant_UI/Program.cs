﻿using eStudentRestaurant_UI.Login;
using eStudentRestaurant_UI.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStudentRestaurant_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm frm = new LoginForm();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
                Application.Run(new MainForm());
        }
    }
}
