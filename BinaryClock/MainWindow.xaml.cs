using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BinaryClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += new EventHandler(dispatcherTimer_Tick);
            
            InitializeComponent();

            dt.Start();
        }

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime moment = DateTime.Now;

            if (moment.Hour > 12) moment = moment.AddHours(-12);

            H8.IsChecked = (moment.Hour & 8) == 8;
            H4.IsChecked = (moment.Hour & 4) == 4;
            H2.IsChecked = (moment.Hour & 2) == 2;
            H1.IsChecked = (moment.Hour & 1) == 1;

            M32.IsChecked = (moment.Minute & 32) == 32;
            M16.IsChecked = (moment.Minute & 16) == 16;
            M8.IsChecked = (moment.Minute & 8) == 8;
            M4.IsChecked = (moment.Minute & 4) == 4;
            M2.IsChecked = (moment.Minute & 2) == 2;
            M1.IsChecked = (moment.Minute & 1) == 1;

            S32.IsChecked = (moment.Second & 32) == 32;
            S16.IsChecked = (moment.Second & 16) == 16;
            S8.IsChecked = (moment.Second & 8) == 8;
            S4.IsChecked = (moment.Second & 4) == 4;
            S2.IsChecked = (moment.Second & 2) == 2;
            S1.IsChecked = (moment.Second & 1) == 1;
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Environment.Exit(0);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
            window.BringIntoView();
        }

        private void CloseLabel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
