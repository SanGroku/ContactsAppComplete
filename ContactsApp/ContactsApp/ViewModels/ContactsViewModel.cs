using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        private Contact _selectedItem;

        public ObservableCollection<Contact> Contacts { get; }
        public Command LoadContactsCommand { get; }
        public Command AddContactCommand { get; }
        public Command<Contact> ContactTapped { get; }

        public ContactsViewModel()
        {
            Title = "Contacts";
            Contacts = new ObservableCollection<Contact>();
            LoadContactsCommand = new Command(async () => await ExecuteLoadContactsCommand());

            ContactTapped = new Command<Contact>(OnContactSelected);

            AddContactCommand = new Command(OnAddContact);
        }

        async Task ExecuteLoadContactsCommand()
        {
            IsBusy = true;

            try
            {
                Contacts.Clear();
                var contacts = await DataStore.GetItemsAsync(true);
                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedContact = null;
        }

        public Contact SelectedContact
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnContactSelected(value);
            }
        }

        private async void OnAddContact(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewContactPage));
        }

        async void OnContactSelected(Contact contact)
        {
            if (contact == null)
                return;

            // This will push the ContactDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ContactDetailPage)}?{nameof(ContactDetailViewModel.ContactId)}={contact.Id}");
        }
    }
}