using ContactsApp.Models;
using ContactsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp.Views
{
    public partial class NewContactPage : ContentPage
    {
        public Item Item { get; set; }

        public NewContactPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}