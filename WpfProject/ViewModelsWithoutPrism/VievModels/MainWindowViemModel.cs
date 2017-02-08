using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProject.ViewModelsWithoutPrism.VievModels
{
    public class MainWindowViemModel : WindowBaseProperty
    {
        private string _name;
        private string _name2;
        private int _result;

        public ICommand ButtonCommand { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public string Name2
        {
            get { return _name2; }
            set
            {
                _name2 = value;
                OnPropertyChangedCallerMember();
            }
        }

        public int Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(() => Result);
            }
        }
    }
}
