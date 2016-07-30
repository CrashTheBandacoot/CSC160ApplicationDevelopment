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

namespace MeeCreator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Width = 500;
            myEllipse.Height = 100;
            myEllipse.Fill = Brushes.Fuchsia;
            FaceCanvas.Children.Add(myEllipse);
        }

        private void b_blue_Click(object sender, RoutedEventArgs e)
        {
            e_leftEye.Fill = Brushes.Aqua;
            e_rightEye.Fill = Brushes.Aqua;
        }

        private void b_green_Click(object sender, RoutedEventArgs e)
        {
            e_leftEye.Fill = Brushes.Chartreuse;
            e_rightEye.Fill = Brushes.Chartreuse;
        }

        private void b_brown_Click(object sender, RoutedEventArgs e)
        {
            e_leftEye.Fill = Brushes.Chocolate;
            e_rightEye.Fill = Brushes.Chocolate;
        }
    }












        public class InvertValueConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is double)
                {
                    double temp = (double)value;
                    temp *= -1;
                    value = temp;
                }
                return value;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is double)
                {
                    double temp = (double)value;
                    temp *= -1;
                    value = temp;
                }
                return value;
            }
        }
}