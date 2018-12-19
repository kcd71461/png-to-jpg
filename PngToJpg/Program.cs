using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PngToJpg
{
    /**
     * https://docs.microsoft.com/ko-kr/dotnet/framework/winforms/advanced/how-to-set-jpeg-compression-level
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            StartCommandLineTool();
        }

        private static void StartCommandLineTool()
        {
            var deletePng = true;
            Console.Write("Delete origin PNG file? (y of n, default: y)");
            var line = Console.ReadLine();
            deletePng = line.Trim().ToUpper() != "NO" && line.Trim().ToUpper() != "N";


            foreach (string file in System.IO.Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                ConvertPngToJpg(file,deletePng);
            }
        }

        private static void ConvertPngToJpg(string file, bool deletePng)
        {
            string extension = System.IO.Path.GetExtension(file);
            if (extension == ".png")
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(file);
                var ret = file.Substring(0, file.LastIndexOf(".")) + ".jpg";
                if (File.Exists(ret)) File.Delete(ret);
                img.Save(ret, System.Drawing.Imaging.ImageFormat.Jpeg);
                img.Dispose();
                img = null;

                if (deletePng)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
