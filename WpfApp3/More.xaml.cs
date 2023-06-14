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
    /// <summary>
    /// Logika interakcji dla klasy More.xaml
    /// </summary>
    public partial class More : Window
    {
        public More()
        {
            InitializeComponent();
        }

        private void Oddzial_Click(object sender, RoutedEventArgs e)
        {
            Oddzialy oddzialy = new Oddzialy();
            oddzialy.Show();
            Close();
        }

        private void Bankomat_Click(object sender, RoutedEventArgs e)
        {
            Bankomaty bankomaty = new Bankomaty();
            bankomaty.Show();
            Close();
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();
            contact.Show();
            Close();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
           Setting setting = new Setting();
            setting.Show();
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            MainWindow Logowanie= new MainWindow();
            Logowanie.Show();
            Close();
        }

        private void My_product_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
            Close();
        }
    }
}
