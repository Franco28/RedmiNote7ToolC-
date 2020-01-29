// <copyright file=Strings>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 29/1/2020 13:16:41</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class Strings
    {
        public static void MSGBOXFileCorrupted()
        {
           DialogResult msg = MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
