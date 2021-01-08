using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Employee : NotifyPropertyChange
    {
        private string passportData;

        public string PassportData
        {
            get { return passportData; }
            set 
            { 
                passportData = value;
                OnPropertyChanged("PassportData");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set 
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string patronymic;

        public string Patronymic
        {
            get { return patronymic; }
            set 
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

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


    }
}
