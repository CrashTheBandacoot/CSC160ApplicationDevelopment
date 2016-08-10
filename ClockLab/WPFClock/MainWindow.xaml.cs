using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ClockWithEvents;
using System.Windows.Threading;

namespace WPFClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Clock ticker;

        private delegate void NoArg();

        public MainWindow()
        {
            
            InitializeComponent();

            ticker = new Clock();

            /*
             * We could also use the Action type instead of NoArg and save some code.  
             * But then we'd need to understand Generics...
             * so I'll stick with NoArg for now.
            */
            NoArg start = ticker.Start;


            /*
             *  .NET prevents us from updating UI elements from another thread.
             *  Our clock uses Thread.Sleep which would make our app look like it crashed.
             *  We'll use a separate thread for the clock.Start method, then use the Dispatcher
             *  to update the UI in its own sweet time on its own sweet thread.  Think of 
             *  queing up a message that is then processed by the UI thread when it's able.
             *  
             *  Importantly, we don't have to change the Clock class to take advantage of threading.
             *  All the Dispatch/BeginInvoke magic happens here in the client code.
             * 
             */
            ticker.MillisecondsChanged += Ticker_MillisecondsChangedOnDifferentThread;
            ticker.SecondsChanged += Ticker_SecondsChangedOnDifferentThread;
            ticker.MinutesChanged += Ticker_MinutesChangedOnDifferentThread;
            ticker.HoursChanged += Ticker_HoursChangedOnDifferentThread;
            ticker.DaysChanged += Ticker_DaysChangedOnDifferentThread;
            start.BeginInvoke(null, null);
            
        }

        private void Ticker_MillisecondsChangedUIThread(int currentTime)
        {
            if (currentTime >= 1000)
            {
                currentTime %= 1000;
            }
            tb_milliseconds.Content = currentTime;
        }

        private void Ticker_MillisecondsChangedOnDifferentThread(int currentTime)
        {
            tb_milliseconds.Dispatcher.BeginInvoke(new Action<int>(Ticker_MillisecondsChangedUIThread), currentTime);
        }
        private void Ticker_SecondsChangedUIThread(int currentTime)
        {
            /*
             * This method is executed by the UI thread, and so can modify the label directly.
             */
            if (currentTime >= 10)
            {
                currentTime %= 10;
            }
            tb_seconds.Content = currentTime;        
        }

        private void Ticker_SecondsChangedOnDifferentThread(int currentTime)
        {
            /*
             * Here's where the Clock's thread will put a message on the UI thread's queue of work,
             * again, through the use of a delegate
             */
            tb_seconds.Dispatcher.BeginInvoke(new Action<int>(Ticker_SecondsChangedUIThread), currentTime);
        }
        private void Ticker_MinutesChangedUIThread(int currentTime)
        {
            if (currentTime >= 3)
            {
                currentTime %= 3;
            }
            tb_minutes.Content = currentTime;
        }

        private void Ticker_MinutesChangedOnDifferentThread(int currentTime)
        {
            tb_minutes.Dispatcher.BeginInvoke(new Action<int>(Ticker_MinutesChangedUIThread), currentTime);
        }
        private void Ticker_HoursChangedUIThread(int currentTime)
        {
            if (currentTime >= 3)
            {
                currentTime %= 3;
            }
            tb_hours.Content = currentTime;
        }

        private void Ticker_HoursChangedOnDifferentThread(int currentTime)
        {
            tb_hours.Dispatcher.BeginInvoke(new Action<int>(Ticker_HoursChangedUIThread), currentTime);
        }
        private void Ticker_DaysChangedUIThread(int currentTime)
        {
            tb_days.Content = currentTime;
        }

        private void Ticker_DaysChangedOnDifferentThread(int currentTime)
        {
            tb_days.Dispatcher.BeginInvoke(new Action<int>(Ticker_DaysChangedUIThread), currentTime);
        }

        private void cb_milliseconds_Checked(object sender, RoutedEventArgs e)
        {
            try { ticker.MillisecondsChanged += Ticker_MillisecondsChangedOnDifferentThread; }
            catch (NullReferenceException) { }
        }
        private void cb_milliseconds_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.MillisecondsChanged -= Ticker_MillisecondsChangedOnDifferentThread;
        }
        private void cb_Seconds_Checked(object sender, RoutedEventArgs e)
        {
            try { ticker.SecondsChanged += Ticker_SecondsChangedOnDifferentThread; }
            catch (NullReferenceException) { }
        }
        private void cb_Seconds_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.SecondsChanged -= Ticker_SecondsChangedOnDifferentThread;
        }
        private void cb_Minutes_Checked(object sender, RoutedEventArgs e)
        {
            try { ticker.MinutesChanged += Ticker_MinutesChangedOnDifferentThread; }
            catch (NullReferenceException) { }
        }
        private void cb_Minutes_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.MinutesChanged -= Ticker_MinutesChangedOnDifferentThread;
        }
        private void cb_Hours_Checked(object sender, RoutedEventArgs e)
        {
            try { ticker.HoursChanged += Ticker_HoursChangedOnDifferentThread; }
            catch (NullReferenceException) { }
        }
        private void cb_Hours_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.HoursChanged -= Ticker_HoursChangedOnDifferentThread;
        }
        private void cb_Days_Checked(object sender, RoutedEventArgs e)
        {
            try { ticker.DaysChanged += Ticker_DaysChangedOnDifferentThread; }
            catch (NullReferenceException) { }
        }
        private void cb_Days_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.DaysChanged -= Ticker_DaysChangedOnDifferentThread;
        }
    }
}
