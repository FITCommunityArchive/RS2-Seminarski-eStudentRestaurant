﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eStudentRestaurant_Xamarin.Navigations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentNavigationMaster : ContentPage
    {
        public ListView ListView;

        public StudentNavigationMaster()
        {
            InitializeComponent();

            BindingContext = new StudentNavigationMasterViewModel();
            WelcomeLabel.Text = "Wellcome " + Global.loggedStudent.FirstName + " " + Global.loggedStudent.LastName; 
            ListView = MenuItemsListView;
        }

        class StudentNavigationMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<StudentNavigationMenuItem> MenuItems { get; set; }
            
            public StudentNavigationMasterViewModel()
            {
                MenuItems = new ObservableCollection<StudentNavigationMenuItem>(new[]
                {
                    new StudentNavigationMenuItem {Title = "Products" , Icon = "pizza-16.png", TargetType = typeof(StudentMainPage)},
                    new StudentNavigationMenuItem {Title = "Menus" , Icon = "menu-16.png", TargetType = typeof(Menus.MenuListPage)},
                    new StudentNavigationMenuItem {Title = "Orders" , Icon = "list.png", TargetType = typeof(Orders.OrdersListPage)},
                    new StudentNavigationMenuItem {Title = "Active order" , Icon = "border-color-16.png", TargetType = typeof(Orders.ActiveOrder)},
                    new StudentNavigationMenuItem {Title = "My profile" , Icon = "guest-16.png", TargetType = typeof(StudentProfilePage)},
                    new StudentNavigationMenuItem {Title = "Logut" , Icon = "logout-16.png", TargetType = typeof(LogoutActivity)},

                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}