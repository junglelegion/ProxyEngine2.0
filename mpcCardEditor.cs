using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyEngine
{
    public class mpcCardEditor
    {
        public static void make(string original, string path)
        {
            using (Image newImage = new Bitmap(816, 1110))
            {
                Graphics graphics = Graphics.FromImage(newImage);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(24, 21, 16)), 0, 0, 816, 1110);
                graphics.DrawImage(new Bitmap(original), 35, 35, 745, 1040);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(24, 21, 16)), 475, 1027, 257, 20);
                newImage.Save(Path.Combine(path,Path.GetFileName(original)), ImageFormat.Png);
            }

        }
    }
}
