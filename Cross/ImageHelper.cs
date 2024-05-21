using System;
using System.IO;

namespace Cross
{
    public static class ImageHelper
    {
        private static readonly string _wwwRootPath = Cross.AppSettings.GetPathWWWRoot();

        public static string SaveImageFromBase64(string base64String)
        {
            try
            {
                int commaIndex = base64String.IndexOf(",");
                if (commaIndex >= 0)
                {
                    base64String = base64String.Substring(commaIndex + 1);
                }

                string fileName = Guid.NewGuid().ToString() + ".svg";

                byte[] imageBytes = Convert.FromBase64String(base64String);

                string imagePath = Path.Combine(_wwwRootPath, fileName);

                File.WriteAllBytes(imagePath, imageBytes);

                return imagePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar a imagem: {ex.Message}");
            }
        }

        public static string GetImageAsBase64(string? fileName)
        {
            string imagePath = Path.Combine(_wwwRootPath, fileName ?? string.Empty);

            if (File.Exists(imagePath))
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    string base64String = Convert.ToBase64String(imageBytes);

                    return base64String;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao ler a imagem: {ex.Message}");
                }
            }
            else
            {
                return "";
            }
        }
    }
}
