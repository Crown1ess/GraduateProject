using System;

namespace Models
{
    public class User : NotifyPropertyChange
    {
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set 
            { 
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string rank;
        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }
}
