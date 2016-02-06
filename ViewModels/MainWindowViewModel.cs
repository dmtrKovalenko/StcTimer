using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StcTimer.Models;

namespace StcTimer.ViewModels
{
    class MainWindowViewModel
    {
        public TimerModel TimerProperty { get; set; }
        Timer timer = new Timer();
       
        public MainWindowViewModel()
        {
            TimerProperty = new TimerModel
            { 
                _Progress = Timer._progress
            };
  //          TimerProperty.PropertyChanged += TimerProperty_PropertyChanged;
        }

   /*     private void TimerProperty_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimerProperty = new TimerModel
            {
                _Progress = Timer._progress
            };
        }*/
    }
}
