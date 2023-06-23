using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesToDb
{
    public static class ImageLoader
    {
        public static byte[] LoadPhoto(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
