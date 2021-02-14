using Employees.Services.DialogService;
using Employees.ViewModels.Base;
using System;
using System.IO;

namespace Employees.ViewModels
{
    public class AddEmployeeWindowViewModel : BaseViewModel
    {
        #region fields
        IDialogService dialogService;
        IFileService fileService;
        private string imagePath;

        #endregion

        #region properties
        private string lastName;

        public string LastName
        {
            get => lastName;
            set 
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        private int _SNILS;
        public int SNILS
        {
            get => _SNILS;
            set
            {
                _SNILS = value;
                OnPropertyChanged("SNILS");
            }
        }

        private int _INN;
        public int INN
        {
            get => _INN;
            set
            {
                _INN = value;
                OnPropertyChanged("INN");
            }
        }

        private int phoneNumber;
        public int PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string address;
        public string Address 
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string passport;
        public string Passport
        {
            get => passport;
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }

        private string gettingPlace;
        public string GettingPlace
        {
            get => gettingPlace;
            set
            {
                gettingPlace = value;
                OnPropertyChanged("GettingPlace");
            }
        }

        private string gettingDate;
        public string GettingDate 
        {
            get => gettingDate;
            set
            {
                gettingDate = value;
                OnPropertyChanged("GettingDate");
            }
        }

        private string profession;
        public string Professin 
        {
            get => profession;
            set
            {
                profession = value;
                OnPropertyChanged("Profession");
            }
        }

        private string birthDate;
        public string BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }
        //надо сделать float, потому что в string могут все что угодно вписать
        private string workExperience;
        public string WorkExperience
        {
            get => workExperience;
            set
            {
                workExperience = value;
                OnPropertyChanged("WorkExperience");
            }
        }

        #endregion

        #region commands
        private readonly RelayCommand openFileCommand;
        public RelayCommand OpenFileCommand => openFileCommand;
        #endregion

        public AddEmployeeWindowViewModel()
        {
            
            openFileCommand = new RelayCommand(c => openFile(), c => true); 
        }

        private void openFile()
        {
            dialogService = new DefaultDialogService();
            fileService = new StringFileService();

            try
            {
                if (dialogService.OpenFileDialog())
                {
                    imagePath = Path.GetFullPath(fileService.Open(dialogService.FilePath));
                    dialogService.ShowMessage("Image selected");
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        } 
    }
}
