using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using WpfProject.Events;

namespace WpfProject.ViewModels
{
    public class ViewBViewModel : BindableBase
    {
        private string _message;

        public ViewBViewModel(IEventAggregator eventsAggregator)
        {
            eventsAggregator.GetEvent<UpdateEvents>().Subscribe(Update);
        }

        private void Update(string obj)
        {
            Message = obj;
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(() => Message);
            }
        }
    }
}
