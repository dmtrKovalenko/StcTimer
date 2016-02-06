using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace StcTimer
{
    class Timer
    {
        public static double _progress;
        DispatcherTimer _timer = new DispatcherTimer();
        public Timer()
        {
            _progress = 0.5;
            _timer.Tick += timer_Tick;
            _timer.IsEnabled = true;
            _timer.Interval = new TimeSpan(0, 0, 0, 2);
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
           _progress  = 1;
        }
    }
}
