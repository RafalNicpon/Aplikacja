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
using System.Windows.Shapes;

namespace WpfApp3
{
    public partial class ZmianaHasla : Window
    {
        public ZmianaHasla()
        {
            InitializeComponent();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            Close();
        }
        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
            Close();
        }
        private void Zmień_Click(object sender, RoutedEventArgs e)
        {


            MessageBox.Show("Twoje hasło zostało zmienione!", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Information);
            MainPage main = new MainPage();
            main.Show();
            Close();
        }

    }
}
