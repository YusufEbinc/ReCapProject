using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
   public static class PathConstants
    {
        private static string imagesPath = "wwwroot\\Uploads\\Images\\";

        public static string GetImagesPath()
        {
            return imagesPath;
        }

        public static void SetImagesPath(string value)
        {
            imagesPath = value;
        }
    }
}
