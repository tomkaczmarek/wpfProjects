using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.ViewModelsWithoutPrism.VievModels
{
    public class MainWindowViemModel : WindowBaseProperty
    {
        private string _name;
        private string _name2;

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
    }
}
