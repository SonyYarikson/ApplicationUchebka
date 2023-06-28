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
    /// Логика взаимодействия для MallList.xaml
    /// </summary>
    public partial class MallList : Page
    {
        public MallList()
        {
            InitializeComponent();
            MallsLV.ItemsSource = PavilionsEntities.GetContext().MallsListView.ToList();
            CBFilter.ItemsSource = PavilionsEntities.GetContext().MallStatuses.Select(x => x.MallStatus).ToList();
            CBFilterCity.ItemsSource = PavilionsEntities.GetContext().Cities.Select(x => x.CityName).ToList();
        }

        private void CBFilter_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();
            MallsLV.ItemsSource = PavilionsEntities.GetContext().MallsListView.Where(x => x.MallStatus == selectedValue).ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void CBFilterCity_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem.ToString();
            MallsLV.ItemsSource = PavilionsEntities.GetContext().MallsListView.Where(x => x.CityName == selectedValue).ToList();
        }


        private void OpenMall_Click(object sender, RoutedEventArgs e)
        {
            MallsListView mall = (sender as Button).DataContext as MallsListView;
            MallDescription.mall = mall;
            Malllistframe.Navigate(new MallDescription());

        }
    }
}
