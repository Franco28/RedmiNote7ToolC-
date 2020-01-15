// <copyright file=copyright>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <summary>A basic code to </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Copyright
{
    public partial class copyright : Form
    {
        public copyright()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList copylist = new ArrayList();
            copylist.Add(@"// <copyright file=" + @"");
            copylist.Add("// Copyright (c) 2019-2020 All Rights Reserved");
            copylist.Add("// </copyright>");
            copylist.Add("// <author>Franco28</author>");
            copylist.Add("// <date> " + DateTime.Now + @"</date>");
            copylist.Add("// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>");               
            listBox1.DataSource = copylist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string file in Directory.GetFiles(@"C:\Users\Franco28\Desktop\VisualStudio\RedmiNote7ToolC\RedmiNote7ToolC\", "*.cs"))
            {

                label1.Text = "Adding Copyright...";

                string tempFile = Path.GetFullPath(file) + ".tmp";

                using (StreamReader reader = new StreamReader(file))
                {
                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {
                        writer.WriteLine(@"// <copyright file=" + Path.GetFileNameWithoutExtension(file) + @">
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> " + DateTime.Now + @"</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>");
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                File.Delete(file);
                File.Move(tempFile, file);
            }



            foreach (string file2 in Directory.GetFiles(@"C:\Users\Franco28\Desktop\VisualStudio\ToolEngine\ToolEngine\Classes\", "*.cs"))
            {

                label1.Text = "Adding Copyright...";

                string tempFile2 = Path.GetFullPath(file2) + ".tmp";

                using (StreamReader reader = new StreamReader(file2))
                {
                    using (StreamWriter writer = new StreamWriter(tempFile2))
                    {
                        writer.WriteLine(@"// <copyright file=" + Path.GetFileNameWithoutExtension(file2) + @">
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> " + DateTime.Now + @"</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>");
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                File.Delete(file2);
                File.Move(tempFile2, file2);
            }

            MessageBox.Show("Info: Copyright added! ", "Copyright (C)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string file in Directory.GetFiles(@"C:\Users\Franco28\Desktop\VisualStudio\RedmiNote7ToolC\RedmiNote7ToolC\", "*.cs"))
                {
                    string tempFile = Path.GetFullPath(file) + ".tmp";

                    label1.Text = "Removing old Copyright...";

                    TextLineRemover.OnRemovedLine += (o, removedLineArgs) => Console.WriteLine(string.Format("Removed \"{0}\" at line {1}", removedLineArgs.RemovedLine, removedLineArgs.RemovedLineNumber));
                    TextLineRemover.OnFinished += (o, finishedArgs) => Console.WriteLine(string.Format("{0} of {1} lines removed. Time used: {2}", finishedArgs.LinesRemoved, finishedArgs.TotalLines, finishedArgs.TotalTime.ToString()));
                    TextLineRemover.RemoveTextLines(new List<string> {
                    @"// <copyright file=" + Path.GetFileNameWithoutExtension(file) + @">",
                    "// Copyright (c) 2019-2020 All Rights Reserved",
                    "// </copyright>",
                    "// <author>Franco28</author>",
                    "// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>",
                    "// <date> ",}, file, file + ".tmp");
                }

                foreach (string file2 in Directory.GetFiles(@"C:\Users\Franco28\Desktop\VisualStudio\ToolEngine\ToolEngine\Classes\", "*.cs"))
                {
                    string tempFile2 = Path.GetFullPath(file2) + ".tmp";

                    label1.Text = "Removing old Copyright...";

                    TextLineRemover.OnRemovedLine += (o, removedLineArgs) => Console.WriteLine(string.Format("Removed \"{0}\" at line {1}", removedLineArgs.RemovedLine, removedLineArgs.RemovedLineNumber));
                    TextLineRemover.OnFinished += (o, finishedArgs) => Console.WriteLine(string.Format("{0} of {1} lines removed. Time used: {2}", finishedArgs.LinesRemoved, finishedArgs.TotalLines, finishedArgs.TotalTime.ToString()));
                    TextLineRemover.RemoveTextLines(new List<string> {
                    @"// <copyright file=" + Path.GetFileNameWithoutExtension(file2) + @">",
                    "// Copyright (c) 2019-2020 All Rights Reserved",
                    "// </copyright>",
                    "// <author>Franco28</author>",
                    "// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>",
                    "// <date> ",}, file2, file2 + ".tmp");
                }

                MessageBox.Show("Info: Copyright removed! ", "Copyright (C)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Text = "Copyright Remover";
            } 
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er, "Copyright (C) - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
