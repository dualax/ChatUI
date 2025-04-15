using ChatUI.MVVM.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatUI.MVVM.Model
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }
        public RelayCommand SendCommand { get; set; }
        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();
            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });

            Messages.Add(new MessageModel
            {
                UserName = "Test_0",
                UserNameColor = "#409AFF",
                ImageSource = "https://cdn-icons-png.flaticon.com/512/1205/1205526.png",
                Message = "Test_0",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    UserName = "Test_0",
                    UserNameColor = "#409AFF",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/1205/1205526.png",
                    Message = "Test_0",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    UserName = "Test_1",
                    UserNameColor = "#409AFF",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/1205/1205526.png",
                    Message = "Test_0",
                    Time = DateTime.Now,
                    IsNativeOrigin = true
                });
            }

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    UserName = $"Test {i}",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/1205/1205526.png",
                    Messages = Messages
                });
            }
        }
    }
}