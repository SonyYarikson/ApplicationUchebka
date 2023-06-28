using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationUchebka
{
    /// <summary>
    /// Логика взаимодействия для AddPavilions.xaml
    /// </summary>
    public partial class AddPavilions : Page
    {
        Pavilions pavilion = new Pavilions();
        public AddPavilions()
        {
            InitializeComponent();
            PavilionStatusCB.ItemsSource = PavilionsEntities.GetContext().PavilionStatuses.ToList();
        }

        private void SavePavilion_Click(object sender, RoutedEventArgs e)
        {
            var status = PavilionStatusCB.SelectedItem as PavilionStatuses;
            if (int.TryParse(LevelNumberTB.Text, out int ParcedLevelNumber) && int.TryParse(AreaTB.Text, out int ParcedArea) && double.TryParse(ValueAddedFactorTB.Text, out double ParcedValueAddedFactor) && int.TryParse(SquareMeterCostTB.Text, out int ParcedSquareMeterCost))
            {
                pavilion.PavilionNumber = PavilionNumberTB.Text;
                pavilion.MallId = MallDescription.mall.MallId;
                pavilion.LevelNumber = ParcedLevelNumber;
                pavilion.PavilionStatusId = status.PavilionStatusId;
                pavilion.Area = ParcedArea;
                pavilion.SquareMeterCost = ParcedSquareMeterCost;
                pavilion.ValueAddedFactor = ParcedValueAddedFactor;

                PavilionsEntities.GetContext().Pavilions.Add(pavilion);
                try
                {
                    PavilionsEntities.GetContext().SaveChanges();
                    MessageBox.Show("ИНФОРМАЦИЯ СОХРАНЕНА");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                        MessageBox.Show("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage + "");
                        }
                    }
                }
            }
            else MessageBox.Show("Ошибка ввода. Убедитесь, что поля числа павильонов, цены постройки, коэффицента добавочной стоимости и количества этажей имеют числовые значения");
        }
    }
}
