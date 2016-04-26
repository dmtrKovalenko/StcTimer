using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace StcTimer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;
        private readonly SoundPlayer _player;
        private TimeSpan _remaining;
        private Storyboard _countDownAnimation;
        private Storyboard _blinkingTextAnimation;
        private DateTime _startCountdown;
        private TimeSpan _timeToEnd;
        private DateTime _pauseTime;
        private Duration _duration;
        private SolidColorBrush _fillBrush;

        public MainWindow()
        {
            InitializeComponent();
            _player = new SoundPlayer();
            _timer = new DispatcherTimer();

            _timer.Tick += countdown_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            _countDownAnimation = this.FindResource("CountdownAnimation") as Storyboard;
            _blinkingTextAnimation = this.FindResource("BlinkingTextAnimate") as Storyboard; 
            _player.SoundLocation = "Loud-alarm-clock-sound.wav";
            _player.Load();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public Duration Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public TimeSpan TimeToEnd
        {
            get
            {
                return _timeToEnd;
            }
            set
            {
                _timeToEnd = value;
                if (value.TotalMilliseconds <= 0)
                {
                    TimeToEnd = _remaining;
                    _timer.Stop();
                    _player.PlayLooping();

                    ColorAnimation animation = new ColorAnimation();
                    animation.RepeatBehavior = RepeatBehavior.Forever;
                    animation.AutoReverse = true;
                    animation.Duration = new Duration(TimeSpan.FromSeconds(0.7));

                    _blinkingTextAnimation.Begin(this, true);
    
                    this.WindowState = WindowState.Normal;
                }
                OnPropertyChanged(nameof(StringCountdown));
            }
        }

        public string StringCountdown
        {
            get
            {
                var frmt = TimeToEnd.Minutes < 1 ? "ss\\.ff" : "mm\\:ss";
                return _timeToEnd.ToString(frmt);
            }
        }

        public void Start(TimeSpan remaining)
        {
            button.IsEnabled = true;
            restartbtn.IsEnabled = true;

            _remaining = remaining;
            Duration = remaining;

            if (progressBar.Percentage > 0)
            {
                restart(progressBar.Percentage);
            }
            else
            {
                progressBar.SegmentColor = _fillBrush;
                _countDownAnimation.Begin(this, true);
                _startCountdown = DateTime.Now;
                _timer.IsEnabled = true;
            }
        }

        private void countdown_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var elapsed = now.Subtract(_startCountdown);
            TimeToEnd = _remaining.Subtract(elapsed);
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if (_countDownAnimation.GetIsPaused(this))
            {
                var now = DateTime.Now;
                var elapsed = now.Subtract(_pauseTime);
                _startCountdown = _startCountdown.Add(elapsed);

                _countDownAnimation.Resume(this);
                _timer.Start();
            }
            else if (progressBar.Percentage == 1)
            {
                _player.Stop();
                _blinkingTextAnimation.Stop(this);
            }
            else
            {
                _pauseTime = DateTime.Now;

                _countDownAnimation.Pause(this);
                _timer.Stop();
            }
        }

        private void restart(double percentage)
        {
            _timer.Stop();
            _player.Stop();
            _blinkingTextAnimation.Stop(this);

            TimeToEnd = _remaining;
            restartbtn.IsEnabled = false;
            DoubleAnimation restartAnimate = new DoubleAnimation(percentage, 0, new Duration(TimeSpan.FromSeconds(0.5)));
            restartAnimate.Completed += (s, e) =>
            {
                restartbtn.IsEnabled = true;
                Start(_remaining);
            };
            progressBar.BeginAnimation(DesignInControl.CircularProgressBar.PercentageProperty, restartAnimate);
        }

        private void recoilTo20_Click(object sender, RoutedEventArgs e)
        {
            _fillBrush = this.FindResource("Fill_blue") as SolidColorBrush;
            Start(new TimeSpan(0, 0, 20, 0));
        }

        private void recoilTo30_Click(object sender, RoutedEventArgs e)
        {
            _fillBrush = this.FindResource("Fill_orange") as SolidColorBrush;
            Start(new TimeSpan(0, 0, 30, 0));
        }

        private void recoilTo60_Click(object sender, RoutedEventArgs e)
        {
            _fillBrush = this.FindResource("Fill_green") as SolidColorBrush;
            Start(new TimeSpan(0, 0, 60, 0));
        }

        private void restartbtn_Click(object sender, RoutedEventArgs e)
        {
            restart(progressBar.Percentage);
        }
    }
}
