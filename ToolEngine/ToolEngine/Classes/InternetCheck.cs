// <copyright file=InternetCheck>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 20/1/2020 17:44:26</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

namespace Franco28Tool.Engine
{
    public class InternetCheck
    {
        public static bool Ping(string host)
        {
            System.Net.NetworkInformation.Ping pp = new System.Net.NetworkInformation.Ping();
            if (pp.Send(host, 500).Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
