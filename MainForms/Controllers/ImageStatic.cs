using System.Drawing;
using System.IO;

namespace MainForms.Controllers
{
    public class ImageStatic
    {
        public static byte[] ConvertImg2Binary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static Image ConvertBinary2Img(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }
    }
}
