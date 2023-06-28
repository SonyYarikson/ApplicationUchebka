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
    /// Логика взаимодействия для MallDescription.xaml
    /// </summary>
    public partial class MallDescription : Page
    {
        public static MallsListView mall;
        public MallDescription()
        {
            InitializeComponent();
            DataContext = mall;
            DGPavilions.ItemsSource = PavilionsEntities.GetContext().PavilionsInMalls.Where(x => x.MallId == mall.MallId).ToList();
        }

        private void AddPavilion_Click(object sender, RoutedEventArgs e)
        {
            MallFrame.Navigate(new AddPavilions());
        }
    }
}
