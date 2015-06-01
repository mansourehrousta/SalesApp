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

namespace SalesApp
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
            txtresult.Content = "1200$";
            btncontact.Visibility = System.Windows.Visibility.Visible;
            btnorder.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 4;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 6;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 8;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex = 4;
            txtname.Visibility = System.Windows.Visibility.Hidden;
            txtfamily.Visibility = System.Windows.Visibility.Hidden;
            txtvalid.Visibility = System.Windows.Visibility.Hidden;
            btnsubmit.Visibility = System.Windows.Visibility.Hidden;
            btnsave.Visibility = System.Windows.Visibility.Hidden;
            btnorder.Visibility = System.Windows.Visibility.Hidden;
            btncontact.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            txtname.Visibility = System.Windows.Visibility.Visible;
            txtfamily.Visibility = System.Windows.Visibility.Visible;
            txtvalid.Visibility = System.Windows.Visibility.Visible;
            btnsubmit.Visibility = System.Windows.Visibility.Visible;
            btnsave.Visibility = System.Windows.Visibility.Visible;
        }

      

      

     

     

       
       

       

      
    }
}
