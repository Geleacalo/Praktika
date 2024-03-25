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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
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

        public void vhod_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = TextBox1.Text;
           
            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user is null) 
            {
                MesBox1.Text = "Неправильный логин или пароль!";
                return;
            }

            MesBox1.Text = "Вы успешно вошли в аккаунт!";
            this.Hide();
            PRIVET pRIVET = new PRIVET();
            pRIVET.Show();
            pRIVET.PrivBox.Text = "Зравствуйте, " + LoginBox.Text;
            
            
            
        }

        private void zareg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            reg reg = new reg();
            reg.Show();
        }
        bool p = true;
        private void glaz_Click(object sender, RoutedEventArgs e)
        {           
            
            if (p)
            {
                
                PasswordBox.Visibility = Visibility.Collapsed;
                Glazik.Source = new BitmapImage(new Uri("Recourses/7.png", UriKind.Relative));
                TextBox1.Text = PasswordBox.Password;
                TextBox1.Visibility = Visibility.Visible;

                p = false;
            }
            else
            {
                
                PasswordBox.Visibility = Visibility.Visible;
                Glazik.Source = new BitmapImage(new Uri("Recourses/5.png", UriKind.Relative));               
                PasswordBox.Password = TextBox1.Text;
                TextBox1.Visibility = Visibility.Collapsed;
                p = true;
            }
        }

        private void glaz_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
   
}
