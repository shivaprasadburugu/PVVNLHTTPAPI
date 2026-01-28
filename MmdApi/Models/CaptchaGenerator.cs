using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.IO;

namespace MdmApi.Models
{
    public class CaptchaGenerator
    {
        public static string GenerateText(int length = 5)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var rnd = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public static byte[] GenerateImage(string captchaText)
        {
            using var bmp = new Bitmap(150, 50);
            using var graphics = Graphics.FromImage(bmp);
            using var font = new Font("Arial", 24, FontStyle.Bold);
            using var ms = new MemoryStream();

            graphics.Clear(Color.White);
            graphics.DrawString(captchaText, font, Brushes.Black, 10, 5);

            bmp.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
