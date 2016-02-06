using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StcTimer.ViewModels;


namespace StcTimer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };

            mw.Show();
        }
    }
}