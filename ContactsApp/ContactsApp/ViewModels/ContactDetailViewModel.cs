using ContactsApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    [QueryProperty(nameof(ContactId), nameof(ContactId))]
    public class ContactDetailViewModel : BaseViewModel
    {
        private string contactId;
        private string firstName;
        private string lastName;
        private string description;



        public ContactDetailViewModel()
        {
           
        }

        public string Id { get; set; }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        
                
            

        

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ContactId
        {
            get
            {
                return contactId;
            }
            set
            {
                contactId = value;
                LoadContactId(value);
            }
        }

        public async void LoadContactId(string contactId)
        {
            try
            {
                var contact = await DataStore.GetItemAsync(contactId);
                Id = contact.Id;
                FirstName = contact.FirstName;
                LastName= contact.LastName;
                Description = contact.Description;

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    Title = firstName + " " + lastName;
                }
                else
                {
                    Title = "contact name error";
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Contact");
            }
        }
    }
}
