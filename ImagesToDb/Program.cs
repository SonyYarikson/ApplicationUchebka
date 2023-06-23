using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using ApplicationUchebka;

namespace ImagesToDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            string dirPath = "";

            try
            {
                foreach (var m in PavilionsEntities.GetContext().Malls)
                {
                    dirPath = $"C:\\Users\\yaros\\OneDrive\\Рабочий стол\\Image ТЦ\\{i}.jpg";
                    m.MallPicture = ImageLoader.LoadPhoto(dirPath);
                    i++;
                }

                i = 1;
                foreach (var e in PavilionsEntities.GetContext().Employees)
                {
                    dirPath = $"C:\\Users\\yaros\\OneDrive\\Рабочий стол\\Image Сотрудники\\{i}.jpg";
                    e.EmployeePhoto = ImageLoader.LoadPhoto(dirPath);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                PavilionsEntities.GetContext().SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                    Console.WriteLine("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.WriteLine(err.ErrorMessage + "");
                    }
                }
            }

        }
    }

}
