using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Webmaster.Application.Extentions
{
    public static class IFileFormExtentions
    {
        public static async Task<string> SaveToAsync(this IFormFile formFile, string path)
        {
            string fileName = $"{GetTimeStamp()}_{formFile.FileName}";
            string filePath = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return filePath;
        }

        private static string GetTimeStamp()
        {
            string stamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            return stamp;
        }
    }
}
