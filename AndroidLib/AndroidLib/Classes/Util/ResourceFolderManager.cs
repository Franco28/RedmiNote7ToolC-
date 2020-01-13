/*
 * ResourceFolderManager.cs - Developed by Dan Wager for AndroidLib.dll - 04/12/12
 */

using System.Collections.Generic;
using System.IO;

namespace RegawMOD
{

    public static class ResourceFolderManager
    {
        private static readonly DirectoryInfo REGAWMOD_DIRECTORY;
        private static Dictionary<string, DirectoryInfo> controlledFolders;

        static ResourceFolderManager()
        {
            REGAWMOD_DIRECTORY = new DirectoryInfo("C:\\");
            controlledFolders = new Dictionary<string, DirectoryInfo>();

            if (!REGAWMOD_DIRECTORY.Exists)
                REGAWMOD_DIRECTORY.Create();

            foreach (DirectoryInfo d in REGAWMOD_DIRECTORY.GetDirectories("*", SearchOption.TopDirectoryOnly))
                controlledFolders.Add(d.Name, d);
        }

        public static DirectoryInfo GetRegisteredFolder(string folder)
        {
            return (controlledFolders.ContainsKey(folder) ? controlledFolders[folder] : null);
        }

        public static string GetRegisteredFolderPath(string folder)
        {
            return (controlledFolders.ContainsKey(folder) ? controlledFolders[folder].FullName : null);
        }

        public static bool Register(string name)
        {
            if (controlledFolders.ContainsKey(name))
                return false;

            controlledFolders.Add(name, new DirectoryInfo(REGAWMOD_DIRECTORY + name));

            if (!controlledFolders[name].Exists)
                controlledFolders[name].Create();

            return true;
        }

        public static bool Unregister(string name)
        {
            if (!controlledFolders.ContainsKey(name))
                return false;

            try { controlledFolders[name].Delete(true); }
            catch { return false; }

            return controlledFolders.Remove(name);
        }
    }
}