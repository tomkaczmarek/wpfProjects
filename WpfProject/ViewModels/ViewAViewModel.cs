using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using WpfProject.Events;

namespace WpfProject.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly string _defaultName = "Podaj imię";
        private readonly string _defaultSurName = "Podaj nazwisko";
        private string _name, _surName, _result, _name2;

        public ICommand ValidateCommand { get; set; }

        private IEventAggregator _eventAggregator;

        public ViewAViewModel(IEventAggregator events )
        {
            _eventAggregator = events;
            ValidateCommand = new DelegateCommand(ValidateAction, CanExecuteButtonAction).ObservesProperty(() => Name).ObservesProperty(() => Surname);
        }

        private bool CanExecuteButtonAction()
        {
            return Name != _defaultName && Surname != _defaultSurName;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public string Surname
        {
            get
            {
                return _surName;
            }
            set
            {
                _surName = value;
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


        public string Name2
        {
            get { return _name2; }
            set
            {
                _name2 = value;
                OnPropertyChanged(() => Name2);
            }
        }

        private void ValidateAction()
        {
            bool validationResult = Name != _defaultName && Surname != _defaultSurName;
            if (!validationResult)
            {
                Result = "Błąd";
                return;
            }
            Result = "OK";

            _eventAggregator.GetEvent<UpdateEvents>().Publish(Result);
        }
    }
}
