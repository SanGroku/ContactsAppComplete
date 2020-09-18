using ContactsApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ContactsApp.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage()
        {
            InitializeComponent();
            BindingContext = new ContactDetailViewModel();
        }
    }
}