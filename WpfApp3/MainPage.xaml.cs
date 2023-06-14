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
using System.Windows.Threading;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace WpfApp3
{

    public partial class MainPage : Window
    {

        private int userId;
        private string loggedUserName;
        private DispatcherTimer timer;
        private int remainingSeconds;
        private bool isCodeGenerated;

        string login;
        string password;

        public MainPage(string login= "login", string password = "password")
        {
            LoadDataFromDatabase();
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            this.login = login;
            this.password = password;
        }










        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {



            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            InitializeTimer();
            GenerateAndDisplayBlikCode();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GenerateAndDisplayBlikCode();
            remainingSeconds--;

            if (remainingSeconds <= 0)
            {
                timer.Stop();
                isCodeGenerated = false;
            }
            else
            {
                countdownTextBlock.Text = remainingSeconds.ToString();
            }
        }

        private void GenerateAndDisplayBlikCode()
        {
            if (!isCodeGenerated)
            {
                string blikCode = GenerateBlikCode();
                blikCodeTextBlock.Text = blikCode;

                remainingSeconds = 60;
                countdownTextBlock.Text = remainingSeconds.ToString();

                timer.Start();

                isCodeGenerated = true;
            }
        }

        private string GenerateBlikCode()
        {
            Random random = new Random();
            int blikNumber = random.Next(100000, 999999);
            return blikNumber.ToString();
        }

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            Platnosci platnosci = new Platnosci();
            platnosci.Show();
            Close();
        }

        private void Other_Click(object sender, RoutedEventArgs e)
        {
            More more = new More();
            more.Show();
            Close();
        }

        private void Wiecej_Click(object sender, RoutedEventArgs e)
        {
            More more = new More();
            more.Show();
            Close();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            History history = new History();
            history.Show();
            Close();
        }

        private void Przelew_Click(object sender, RoutedEventArgs e)
        {
            Przelew przelew = new Przelew();
            przelew.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerateAndDisplayBlikCode();
        }
        private void LoadDataFromDatabase()
        {
            // Tworzenie połączenia z bazą danych
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=DataFile.db"))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Połączenie jest aktywne.");
                }

                string query = $"SELECT * From Users WHERE Name={login}";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Przykładowe ID użytkownika
                   // int userId = 1;

                   // command.Parameters.AddWithValue("@Id", userId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string imie = reader.GetString(0);
                            nameLabel.Content = imie;
                        }
                    }
                }
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            Close();
        }

    }
}