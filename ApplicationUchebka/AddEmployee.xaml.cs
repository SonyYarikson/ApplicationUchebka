using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Win32;

namespace ApplicationUchebka
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        Employees employee = new Employees();
        public AddEmployee()
        {
            InitializeComponent();
            EmployeeRoleCB.ItemsSource = PavilionsEntities.GetContext().Roles.ToList();
        }
        private void EmployeePhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(imagePath);

                employee.EmployeePhoto = imageData;
            }
            EmployeePhotoBtn.Visibility = Visibility.Hidden;
        }

        private void SaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (IsPasswordValid(EmployeePasswordTB.Text))
            {

                if (!EmployeePhotoBtn.IsVisible)
                {

                    var role = EmployeeRoleCB.SelectedItem as Roles;
                    employee.Surname = EmployeeSurnameTB.Text;
                    employee.Name = EmployeeNameTB.Text;
                    employee.Patronymic = EmployeePatronymicTB.Text;
                    employee.Login = EmployeeLoginTB.Text;
                    employee.Password = EmployeePasswordTB.Text;
                    employee.RoleId = role.RoleId;
                    employee.PhoneNumber = EmployeePhoneTB.Text;
                    employee.Gender = EmployeeGenderCB.Text;
                    PavilionsEntities.GetContext().Employees.Add(employee);
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
                else MessageBox.Show("Добавьте картинку");
            }
            else MessageBox.Show("Слишком легкий пароль, ваш пароль должен содержать не менее 8 и не более 20 символов, иметь цифру, спецсимвол, заглавную и строчную букву");
        }
        private bool IsPasswordValid(string password)
        {
            // Проверка длины пароля
            if (password.Length < 8 || password.Length > 20)
            {
                return false;
            }

            // Проверка наличия цифр
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // Проверка наличия спецсимволов
            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
            {
                return false;
            }

            // Проверка наличия прописных и строчных букв
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                return false;
            }

            return true;
        }
    }
}

