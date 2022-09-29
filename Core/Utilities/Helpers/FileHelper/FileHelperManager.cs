using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {

        public string Upload(List<IFormFile> file, string root)
        {
            StringBuilder builder = new StringBuilder();
            

            if (file.Count > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                foreach (var item in file)
                {
                    var extension = Path.GetExtension(item.FileName);
                    string guid = Guid.NewGuid().ToString();
                    var path = guid + extension;

                    builder.Append(path + ";");
                    using FileStream fileStream = File.Create(root + path);
                    item.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            return builder.ToString();
        }
        public void Delete(string filePath)//Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı 
        {
            if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }

        
        public string Update(List<IFormFile> file, string filePath, string root)//Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        {
            if (File.Exists(filePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }


    }
}
