using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
 public   interface IFileHelper
    {
        string Upload(List<IFormFile> file, string root);
        void Delete(string filePath);
        string Update(List<IFormFile> file, string filePath, string root);

    }
}
