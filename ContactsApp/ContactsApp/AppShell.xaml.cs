using ContactsApp.ViewModels;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContactsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactDetailPage), typeof(ContactDetailPage));
            Routing.RegisterRoute(nameof(NewContactPage), typeof(NewContactPage));
        }

    }
}
