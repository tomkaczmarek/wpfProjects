using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly string _defaultName = "Podaj imię";
        private readonly string _defaultSurName = "Podaj nazwisko";
        private string _name, _surName, _result;

        public ICommand ValidateCommand { get; set; }

        public MainWindowViewModel()
        {
            ValidateCommand = new DelegateCommand(ValidateAction);
        }

        public string Name
        {
            get
            {
                return !string.IsNullOrEmpty(_name) ? _name : _defaultName;
            }
            set
            {
                _name = value == string.Empty ? _defaultName : value;
                OnPropertyChanged(() => Name);
            }
        }

        public string Surname
        {
            get
            {
                return !string.IsNullOrEmpty(_surName) ? _surName : _defaultSurName;
            }
            set
            {
                _surName = value == string.Empty ? _defaultSurName : value;
                OnPropertyChanged(() => Surname);
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged(() => Result);
            }
        }

        private void ValidateAction()
        {
            bool validationResult = Name != _defaultName && Surname != _defaultSurName;
            if(!validationResult)
            {
                Result = "Błąd";
                return;
            }
            Result = "OK";
        }
    }
}
