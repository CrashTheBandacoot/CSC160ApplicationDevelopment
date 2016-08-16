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

namespace UIThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private delegate void DoWorkDelegate();
        private void ActButton_Click(object sender, RoutedEventArgs e)
        {
            DoWorkDelegate d = new DoWorkDelegate(DoSlowWork);
            
            DoSlowWork();
            Output.Content = "Changed!";
        }
        private void DoSlowWork()
        {
            System.Threading.Thread.Sleep(10 * 1000);
        }
    }
}
