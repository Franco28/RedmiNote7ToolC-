
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using System;
using System.IO;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Splash());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " +ex, "Tool: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            var paths = new[] { "C:\\adb", "C:\\adb\\StockRom", "C:\\adb\\.settings", "C:\\adb\\TWRP", "C:\\adb\\MIFlash", "C:\\adb\\MIUnlock", "C:\\adb\\xiaomiglobalfastboot\\MI", "C:\\adb\\xiaomieu", "C:\\adb\\xiaomiglobalrecovery" };

            foreach (var path in paths)
            {
                try
                {
                    if (Directory.Exists(path))
                    {
                        Directory.SetCurrentDirectory(@"C:\adb");
                        continue;
                    }

                    var di = Directory.CreateDirectory(path);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er, "Creating Folders: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
