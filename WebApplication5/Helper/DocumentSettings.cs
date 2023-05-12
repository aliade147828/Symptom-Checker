using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace WebApplication5.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",folderName);

            var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            var filePath = Path.Combine(folderPath,fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);


            return fileName;
        }

        public static void DeleteFile(string filName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, filName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
