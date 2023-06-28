using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для RIOCost.xaml
    /// </summary>
    public partial class RIOCost : Page
    {
        public RIOCost()
        {
            InitializeComponent();
            MallsNameCB.ItemsSource = PavilionsEntities.GetContext().MallsListView.ToList();


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void MallsNameCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ROIDataGrid.mall = MallsNameCB.SelectedItem as MallsListView;
            RIOFrame.Navigate(new ROIDataGrid());
        }
    }
}
