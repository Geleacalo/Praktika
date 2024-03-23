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

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Text;
           
            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user is null) 
            {
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт!");
            
        }

        private void zareg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            reg reg = new reg();
            reg.Show();
        }

        private void glaz_Click(object sender, RoutedEventArgs e)
        {
            bool p = true;
            if (p)
            {
                PasswordBox.Visibility = Visibility.Collapsed;
                notpass.Visibility = Visibility.Visible;
                p = false;
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                notpass.Visibility = Visibility.Collapsed;
                p = false;
            }
        }
    }
   
}
