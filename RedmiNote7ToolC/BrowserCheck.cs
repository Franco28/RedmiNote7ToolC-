// <copyright file=BrowserCheck>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 1/1/2020 16:57:11</date>
// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>




using System.Diagnostics;

namespace RedmiNote7ToolC
{
    class BrowserCheck
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
