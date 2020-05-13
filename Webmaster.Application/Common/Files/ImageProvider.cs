using System;
using System.IO;
using System.Reflection;

namespace Webmaster.Application.Common.Files
{
    public class ImageProvider
    {
        private const string DEFAULT_IMAGE_NAME = "_default.jpg";
        private const string IMAGES_FOLDER = "Images";


        public string ImagesPath => Path.Combine(Directory.GetCurrentDirectory(), IMAGES_FOLDER);

        public string DefaultImageFilePath
        {
            get
            {
                string exDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string exDirImages = Path.Combine(exDir, IMAGES_FOLDER);

                return Path.Combine(exDirImages, DEFAULT_IMAGE_NAME);
            }
        }

        public byte[] GetDefaultImageBytes => File.ReadAllBytes(this.DefaultImageFilePath);

        public string GetBase64ImageFromPath(string path)
        {
            bool exists = File.Exists(path);
            byte[] imageBytes;
            if (!exists)
                imageBytes = this.GetDefaultImageBytes;
            else
                imageBytes = File.ReadAllBytes(path);

            string base64Image = Convert.ToBase64String(imageBytes);

            return base64Image;
        }
    }
}
