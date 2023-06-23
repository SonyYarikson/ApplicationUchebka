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

namespace ApplicationUchebka
{
    /// <summary>
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    public partial class Authorize : Page
    {
        public Authorize()
        {
            InitializeComponent();
        }
        public static Employees Employee;
        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = PavilionsEntities.GetContext().Employees.FirstOrDefault(a => a.Login == Login.Text && a.Password == Password.Password);

            if (CurrentUser != null)
            {
                Employee = PavilionsEntities.GetContext().Employees.Where(y => y.Login == Login.Text).FirstOrDefault();
                AuthorizePage.Navigate(new MainFrame());
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует");
            }

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
