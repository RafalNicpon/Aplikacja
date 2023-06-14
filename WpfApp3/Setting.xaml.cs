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
    /// Logika interakcji dla klasy Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            MainWindow Logowanie = new MainWindow();
            Logowanie.Show();
            Close();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            More more = new More();
            more.Show();
            Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {

            MainWindow Logowanie = new MainWindow();
            Logowanie.Show();
            Close();
        }

        private void Zmiana_Click(object sender, RoutedEventArgs e)
        {
            ZmianaHasla zmiana = new ZmianaHasla();
            zmiana.Show();
            Close();
        }

        private void Telefon_Click(object sender, RoutedEventArgs e)
        {
            ZmianaTelefonu zmianaTel = new ZmianaTelefonu();
            zmianaTel.Show();
            Close ();

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Logowanie = new MainWindow();
            Logowanie.Show();
            Close();
        }
    }
}
