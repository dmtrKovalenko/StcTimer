using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StcTimer.Models
{
    class TimerModel : INotifyPropertyChanged
    {
        public double _Progress;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public double Progress
        {
            get { return _Progress; }
            set
            {
                if (_Progress != value)
                {
                    _Progress = value;
                    OnPropertyChanged("Progress");
                }
            }
        }

    }
}
