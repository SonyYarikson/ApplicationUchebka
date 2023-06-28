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
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        public MainFrame()
        {
            InitializeComponent();
            MallList.Navigate(new MallList());
        }

        private void Mallbut_Click(object sender, RoutedEventArgs e)
        {
            MallList.Navigate(new MallList());
        }

        private void CreateMall_Click(object sender, RoutedEventArgs e)
        {
            MallList.Navigate(new AddMall());
        }

        private void RentPavilion_Click(object sender, RoutedEventArgs e)
        {
            MallList.Navigate(new RentPavilion());
        }

        private void RIO_Click(object sender, RoutedEventArgs e)
        {
            MallList.Navigate(new RIOCost());
        }
    }
}

