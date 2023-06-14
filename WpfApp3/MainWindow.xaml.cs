using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp3
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {

            var Username = txtUsername.Text;
            var Password = txtPassword.Password;
            


            using(UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user => user.Name == Username && user.Password == Password);

                if(userfound)
                {
                    GrantAccess();
                    Close();


                }
                else
                {
                    MessageBox.Show("Błędny login lub hasło");
                }

            }


        }
        public class MyViewModel : INotifyPropertyChanged
        {
            private string _text;

            public string Text
            {
                get { return _text; }
                set
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void GrantAccess()
        {


            MainPage main = new MainPage();
            main.Show();
            Close();

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Registry rej = new Registry();
            rej.Show();
            Close();
           
        }
    }
}
