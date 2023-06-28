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
    /// Логика взаимодействия для AdminMainFrame.xaml
    /// </summary>
    public partial class AdminMainFrame : Page
    {
        public AdminMainFrame()
        {
            InitializeComponent();
            EmployeesFrame.Navigate(new EmployeesPage());
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesFrame.Navigate(new AddEmployee());
        }

        private void EmployeeList_Click(object sender, RoutedEventArgs e)
        {
            EmployeesFrame.Navigate(new EmployeesPage());
        }
    }
}
