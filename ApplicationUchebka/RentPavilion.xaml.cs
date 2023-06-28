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
    /// Логика взаимодействия для RentPavilion.xaml
    /// </summary>
    public partial class RentPavilion : Page
    {
        public RentPavilion()
        {
            InitializeComponent();
            TenantsComboBox.ItemsSource = PavilionsEntities.GetContext().Tenants.ToList();
            PavilionsComboBox.ItemsSource = PavilionsEntities.GetContext().Pavilions.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Tenants selectedTenant = (Tenants)TenantsComboBox.SelectedItem;
            Pavilions selectedPavilion = (Pavilions)PavilionsComboBox.SelectedItem;
            DateTime? leaseStartDate = LeaseStartDatePicker.SelectedDate;
            DateTime? leaseEndDate = LeaseEndDatePicker.SelectedDate;


            // Проверка, что все данные выбраны
            if (selectedTenant != null && selectedPavilion != null && leaseStartDate != null && leaseEndDate != null && leaseEndDate >= leaseStartDate)
            {
                // Создание новой записи аренды
                PavilionsLease newLease = new PavilionsLease
                {
                    TenantId = selectedTenant.TenantId,
                    EmployeeId = 2,
                    PavilionId = selectedPavilion.PavilionId,
                    LeaseStart = leaseStartDate.Value,
                    C_LeaseEnd = leaseEndDate.Value
                };

                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@TenantId", newLease.TenantId);
                System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@EmpId", newLease.EmployeeId);
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@PavilionId", newLease.PavilionId);
                System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@LeaseStart", newLease.LeaseStart);
                System.Data.SqlClient.SqlParameter param4 = new System.Data.SqlClient.SqlParameter("@LeaseEnd", newLease.C_LeaseEnd);

                System.Data.SqlClient.SqlParameter[] sqlParameters = { param2, param3, param4, param, param1 };

                try
                {
                    PavilionsEntities.GetContext().Database.ExecuteSqlCommand("EXEC RentPavilion @PavilionId, @LeaseStart, @LeaseEnd, @TenantId, @EmpId", sqlParameters);
                    MessageBox.Show("Вы арендовали павильон");

                    log newLog = new log
                    {
                        EmployeeId = newLease.EmployeeId,
                        RentId = newLease.LeaseId,
                        ThenantId = newLease.TenantId,
                        MallId = newLease.Pavilions.MallId,
                        PavilionId = newLease.PavilionId,
                        StatusId = newLease.Pavilions.Malls.MallStatusId,
                        RentalStart = newLease.LeaseStart,
                        RentalEnd = newLease.C_LeaseEnd
                    };
                    PavilionsEntities.GetContext().log.Add(newLog);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                TenantsComboBox.SelectedItem = null;
                PavilionsComboBox.SelectedItem = null;
                LeaseStartDatePicker.SelectedDate = null;
                LeaseEndDatePicker.SelectedDate = null;
                LeaseStartDatePicker.BlackoutDates.Clear();
                LeaseEndDatePicker.BlackoutDates.Clear();
            }
        }
    }
}
