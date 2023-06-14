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
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using System.Data;
using SQLite;
using System.Reflection.Emit;

namespace WpfApp3
{
    public partial class Registry : Window
    {
        private int UserId;
        public Registry()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Password) || string.IsNullOrEmpty(txtImie.Text) || string.IsNullOrEmpty(intTelefon.Text))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Users temp = new Users(txtUsername.Text, txtPassword.Password, txtImie.Text, intTelefon.Text);
            using (var db = new SQLite.SQLiteConnection(@"C:\Users\Rafał\source\repos\WpfApp3\WpfApp3\bin\Debug\net6.0-windows\DataFile.db"))
            {
                db.Insert(temp);
            }

            MainPage main = new MainPage();
            main.Show();
            Close();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private bool IsAllowedKey(Key key)
        {
            return key >= Key.D0 && key <= Key.D9;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            Close();
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
    }
}

