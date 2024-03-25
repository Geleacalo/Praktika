using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var pass = PasswordBox1.Text;
            var Email = EmailBox.Text;
            var Mes = MesBox.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if ((!Regex.IsMatch(Email, @"^[a-zA-Z0-9_.+-]+@(mail\.ru|gmail\.com|yandex\.ru)$")))
            {
                MesBox.Text = "Указан неверный email!";
                error1.Visibility = Visibility.Visible;
            }
            
            else if (((!Regex.IsMatch(pass, @"[!,&%+_]"))))
            {
                error1.Visibility = Visibility.Collapsed;
                error2.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "В паролe требуются спец. символы!";

            }
            else if (PasswordBox1.Text.Length < 8)
            {
                error2.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "Данный пароль является ненадежным!";
            }

            else if (PasswordBox1.Text != PasswordBox2.Text)
            {
                error2.Visibility = Visibility.Collapsed;
                error3.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "Пароли не совпадают!";
            }
            else if (user_exists is not null)
            {
                error3.Visibility = Visibility.Collapsed;
                error4.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "Такой пользователь уже существует!";
                return;
            }
            else
            {
                error4.Visibility = Visibility.Collapsed;
                var user = new User { Login = login, Password = pass, Email = Email };
                context.Users.Add(user);
                context.SaveChanges();
                MesBox.Text = "Добро пожаловать!";
            }



           
            

        }

        private void avtor_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow  zareg = new MainWindow();
            zareg.Show();
        }
    }
}
