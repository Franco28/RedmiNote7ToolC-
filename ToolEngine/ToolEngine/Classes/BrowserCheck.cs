// <copyright file=BrowserCheck>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 19/1/2020 18:01:53</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System.Diagnostics;

namespace Franco28Tool.Engine
{
    public class BrowserCheck
    {
        public static void StartBrowser(string Proc, string Args)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") == true)
                Process.Start(Proc, Args);
            else if (System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
                Process.Start(Proc, Args);
            else if (System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\MicrosoftEdge.exe") == false)
                Process.Start(Proc, Args);
            else if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\MicrosoftEdge.exe") == false)
                Process.Start(Proc, Args);
        }
    }
}
