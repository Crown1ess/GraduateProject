using System;

namespace Models
{
    public class User
    {
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set => phoneNumber = value;
        }

        private string password;
        public string Password
        {
            get { return password; }
            set => password = value;
        }

        private string rank;
        public string Rank
        {
            get { return rank; }
            set => rank = value;
        }
    }
}
