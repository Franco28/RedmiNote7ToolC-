
using System.IO;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class CheckFileSize
    {
        public static void checkingfilesSize(string fileNameName, int sizebb)
        {

            decimal sizeb = sizebb;

            string fileName = fileNameName;
            FileInfo fi = new FileInfo(fileName);

            if (fileNameName == @"C:\adb\TWRP\OrangeFox-R10.1_01-Stable-lavender.zip")
            {
                System.Threading.Thread.Sleep(2000);

                if (fi.Length < sizeb)
                {
                    MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    checkingfilesSize(@"TWRP\OrangeFox-R10.1_01-Stable-lavender.zip", 50077781);
                    Franco28Tool.Engine.Unzip.Unzippy(@"TWRP\OrangeFox-R10.1_01-Stable-lavender.zip", @"TWRP", true);
                }
            }
        }

        public static long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories);
            long size = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }
            size /= 1000000;
            return size;
        }
    }
}
