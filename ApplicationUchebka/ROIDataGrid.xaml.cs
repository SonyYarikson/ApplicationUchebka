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
    /// Логика взаимодействия для ROIDataGrid.xaml
    /// </summary>
    public partial class ROIDataGrid : Page
    {
        public static MallsListView mall;
        public ROIDataGrid()
        {
            InitializeComponent();

            using (var dbcontext = new PavilionsEntities())
            {
                RIODG.ItemsSource = PavilionsEntities.GetContext().Database.SqlQuery<MallsListView>(
                "EXEC CalculateROI @TCName, @City, @Pt, @Pa",
                new SqlParameter("@TCName", mall.MallName),
                new SqlParameter("@City", mall.CityName),
                new SqlParameter("@Pt", mall.BuildingCost),
                new SqlParameter("@Pa", 3000)
                ).ToList();
            }
        }
    }
}

