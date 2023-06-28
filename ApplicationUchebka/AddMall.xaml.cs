using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace ApplicationUchebka
{
    /// <summary>
    /// Логика взаимодействия для AddMall.xaml
    /// </summary>
    public partial class AddMall : Page
    {
        Malls mall = new Malls();
        public AddMall()
        {
            InitializeComponent();
            MallStatusCB.ItemsSource = PavilionsEntities.GetContext().MallStatuses.ToList();
            CityCB.ItemsSource = PavilionsEntities.GetContext().Cities.ToList();
        }

        private void SaveMall_Click(object sender, RoutedEventArgs e)
        {
            var status = MallStatusCB.SelectedItem as MallStatuses;
            var city = CityCB.SelectedItem as Cities;
            if (MallImageBtn.IsVisible != true)
            {
                if (int.TryParse(PavilionsCountTB.Text, out int ParcedPavilionsCost) && int.TryParse(BuildingCostTB.Text, out int ParcedBuildingCost) && double.TryParse(ValueAddedFactorTB.Text, out double ParcedValueAddedFactor) && int.TryParse(LevelsCountTB.Text, out int ParcedLevelsCount))
                {
                    mall.MallName = MallNameTB.Text;
                    mall.MallStatusId = status.MallStatusId;
                    mall.PavilionsCount = ParcedPavilionsCost;
                    mall.CityId = city.CityId;
                    mall.BuildingCost = ParcedBuildingCost;
                    mall.ValueAddedFactor = ParcedValueAddedFactor;
                    mall.LevelsCount = ParcedLevelsCount;
                    PavilionsEntities.GetContext().Malls.Add(mall);
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
            else MessageBox.Show("Добавьте картинку");
        }

        private void MallImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(imagePath);

                mall.MallPicture = imageData;
            }
            MallImageBtn.Visibility = Visibility.Hidden;
        }
    }
}
