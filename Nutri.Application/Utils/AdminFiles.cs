using System.Net;
using System.Drawing;
using Twilio.Rest.Api.V2010.Account.Usage.Record;

namespace Nutri.Application.Utils
{
    public static class AdminFiles
    {
        public static void AdminImage(string url,string fullPath,string fileName = null)
        {
            try
            {
                DownLoadImage(url, fullPath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void DownLoadImage(string url,string fullPath)
        {
            var uri = new Uri(url);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            Stream stream = response.GetResponseStream();
            Image img = Image.FromStream(stream);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                System.IO.File.WriteAllBytes(fullPath, ms.ToArray());
            }
            stream.Dispose();
        }

        public static bool ValidateImageExists(string url, out string fullPath,out string fileName)
        {
            string folder = @"C:\NutriAppImages\";
            string[] arrUrlImage = url.Split('/');
            fileName = arrUrlImage[arrUrlImage.Length - 1];
            fullPath = Path.Combine(folder, $"{fileName}");
            if (File.Exists(fullPath))
                return true;
            return false;
        }
    }
}
