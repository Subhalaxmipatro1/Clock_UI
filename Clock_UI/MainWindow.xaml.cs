using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Clock_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private bool is24hours = false;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTime();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            //is24hours = !is24hours;
            //ColonText.Visibility = is24hours ? Visibility.Visible : Visibility.Hidden;
            UpdateTime();
        }

        private void UpdateTime()
        {
            var now = DateTime.Now;
            if(is24hours)
            {
                leftClockText.Text = now.ToString("HH");
                rightClockText.Text = now.ToString("mm");
                AmPmText.Visibility = Visibility.Collapsed;
            }
            else
            {
                leftClockText.Text = now.ToString("hh");
                rightClockText.Text = now.ToString("mm" );
                AmPmText.Text = now.ToString("tt").ToUpper(); 
                AmPmText.Visibility = Visibility.Visible;
            }
            
        }
        private void FormatToggle_Checked(object sender, RoutedEventArgs e)
        {
            is24hours = true;
            UpdateTime();
        }

        private void FormatToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            is24hours = false;
            UpdateTime();
        }
        //string format = viewcolon ? "HH:mm" : "HH mm";
        //ClockText.Text = DateTime.Now.ToString(format);

        //ClockText.Text = DateTime.Now.ToString("HH:mm");
    }
}
