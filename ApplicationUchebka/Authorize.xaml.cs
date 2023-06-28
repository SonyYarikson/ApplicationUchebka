using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    public partial class Authorize : Page
    {
        int IncorrectPassword = 0;
        public Authorize()
        {
            InitializeComponent();
            GenerateCaptcha();
            Captcha.Visibility = Visibility.Hidden;
        }
        public static Employees Employee;
        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Captcha.IsVisible)
            {
                var CurrentUser = PavilionsEntities.GetContext().Employees.FirstOrDefault(a => a.Login == Login.Text && a.Password == Password.Password);
                if (IncorrectPassword <= 3)
                {
                    if (CurrentUser != null)
                    {
                        Employee = PavilionsEntities.GetContext().Employees.Where(y => y.Login == Login.Text).FirstOrDefault();
                        if (Employee.RoleId != 1)
                        {
                            AuthorizePage.Navigate(new MainFrame());
                        }
                        else AuthorizePage.Navigate(new AdminMainFrame());
                    }
                    else
                    {
                        MessageBox.Show("Данного пользователя не существует");
                        IncorrectPassword++;
                    }
                }
                else
                {
                    Captcha.Visibility = Visibility.Visible;
                    IncorrectPassword = 0;

                }


            }
            else MessageBox.Show("Пожалуйста, пройдите капчу");
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private string captchaText;
        private void GenerateCaptcha()
        {
            // Генерация текста капчи
            captchaText = GenerateRandomText();

            // Создание изображения капчи
            BitmapImage captchaBitmap = GenerateCaptchaImage(captchaText);

            // Отображение изображения капчи
            captchaImage.Source = captchaBitmap;
        }

        private string GenerateRandomText()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = 6; // Длина случайного текста

            // Генерация случайного текста
            string randomText = new string(Enumerable.Repeat(chars, length)
                                          .Select(s => s[random.Next(s.Length)])
                                          .ToArray());

            return randomText;
        }

        private BitmapImage GenerateCaptchaImage(string text)
        {
            int width = 200; // Ширина изображения
            int height = 100; // Высота изображения

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Определение параметров текста
                Typeface typeface = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
                double fontSize = 20;
                Brush textBrush = Brushes.Black;

                // Определение позиции текста на изображении
                Point textPosition = new Point((width - text.Length * fontSize) / 2, (height - fontSize) / 2);

                // Отображение текста на изображении
                drawingContext.DrawText(new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, typeface, fontSize, textBrush), textPosition);
            }

            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingVisual);

            BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmapEncoder.Save(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Важно заморозить изображение для корректного отображения в UI
                return bitmapImage;
            }
        }

        private void CheckCaptcha(object sender, RoutedEventArgs e)
        {
            string userInput = captchaTextBox.Text;

            if (userInput == captchaText)
            {
                MessageBox.Show("Верно! Капча пройдена.");
                Captcha.Visibility = Visibility.Hidden;
                GenerateCaptcha();
                captchaTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Неверно! Попробуйте еще раз.");
                GenerateCaptcha();
            }
        }
    }
}
