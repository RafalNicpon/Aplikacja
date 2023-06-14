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

    public partial class Przelew : Window
    {

        public Przelew()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Back || e.Key == Key.Delete) && string.IsNullOrEmpty(((TextBox)sender).SelectedText))
            {
                TextBox textBox = (TextBox)sender;
                int caretIndex = textBox.CaretIndex;
                if (e.Key == Key.Back && caretIndex > 0)
                {
                    
                    textBox.Text = textBox.Text.Remove(caretIndex - 1, 1);
                    textBox.CaretIndex = caretIndex - 1;
                }
                else if (e.Key == Key.Delete && caretIndex < textBox.Text.Length)
                {
                    
                    textBox.Text = textBox.Text.Remove(caretIndex, 1);
                }
                e.Handled = true; 
            }
        }

        private void TextBox_PreviewTextInputText(object sender, TextCompositionEventArgs e)
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
        private void TextBox_PreviewKeyDownText(object sender, KeyEventArgs e)
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



        private bool IsAllowedKey(Key key)
        {
            return key >= Key.D0 && key <= Key.D9;
        }

        private void Wyslij_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Twój przelew został wysłany!", "Przelew środków", MessageBoxButton.OK, MessageBoxImage.Information);
            MainPage main = new MainPage();
            main.Show();
            Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            Close();
        }
    }
}
