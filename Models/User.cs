using System.ComponentModel;
using System.Runtime.CompilerServices;


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

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName]string properties = null)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(properties));
        //}

    }
}
