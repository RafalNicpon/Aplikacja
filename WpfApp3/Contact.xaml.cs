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
    /// Logika interakcji dla klasy Contact.xaml
    /// </summary>
    public partial class Contact : Window
    {
        public Contact()
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
            More more = new More();
            more.Show();
            Close();
        }
        private void TextBox_PreviewTextInputText(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
        private void TextBox_PreviewKeyDownText(object sender, KeyEventArgs e)
        {
            if (!IsAllowedKey(e.Key))
            {
                e.Handled = true;
            }
        }


        private bool IsAllowedKey(Key key)
        {
            return key >= Key.D0 && key <= Key.D9; 
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (char.IsDigit(ch))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            bool isValidNumber = IsNumericFormatValid(text);

            if (!isValidNumber)
            {
            }
        }

        private bool IsNumericFormatValid(string text)
        {

            int commaCount = text.Count(c => c == ',');
            return commaCount <= 1;
        }


        private void Wyslij_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Twoja prośba o kontakt została wysłana!", "Prośba o kontakt", MessageBoxButton.OK, MessageBoxImage.Information);
            MainPage main = new MainPage();
            main.Show();
            Close();
        }
    }
}
