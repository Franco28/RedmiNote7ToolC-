/*
 * Adb.cs - Developed by Dan Wager for AndroidLib.dll
 */

using System;
using System.IO;

namespace RegawMOD.Android
{
    public class AdbCommand
    {
        private string command;
        private int timeout;
        internal string Command { get { return this.command; } }
        internal int Timeout { get { return this.timeout; } }
        internal AdbCommand(string command) { this.command = command; this.timeout = RegawMOD.Command.DEFAULT_TIMEOUT; }
        public AdbCommand WithTimeout(int timeout) { this.timeout = timeout; return this; }
    }

    public static class Adb
    {
        private static Object _lock = new Object();
        internal const string ADB = "adb";
        internal const string ADB_EXE = "adb.exe";
        internal const string ADB_VERSION = "1.0.39";

        public static AdbCommand FormAdbCommand(string command, params object[] args)
        {
            string adbCommand = (args.Length > 0) ? command + " " : command;

            for (int i = 0; i < args.Length; i++)
                adbCommand += args[i] + " ";

            return new AdbCommand(adbCommand);
        }

        public static AdbCommand FormAdbCommand(Device device, string command, params object[] args)
        {
            return FormAdbCommand("-s " + device.SerialNumber + " " + command, args);
        }

        public static AdbCommand FormAdbShellCommand(Device device, bool rootShell, string executable, params object[] args)
        {
            string shellCommand = string.Format("-s {0} shell \"", device.SerialNumber);

            if (rootShell)
                shellCommand += "su -c \"";

            shellCommand += executable;

            for (int i = 0; i < args.Length; i++)
                shellCommand += " " + args[i];

            if (rootShell)
                shellCommand += "\"";

            shellCommand += "\"";

            return new AdbCommand(shellCommand);
        }

        [Obsolete("Method is deprecated, please use ExecuteAdbShellCommandInputString(Device, int, string...) instead.")]
        public static void ExecuteAdbShellCommandInputString(Device device, params string[] inputLines)
        {
            lock (_lock)
            {
                Command.RunProcessWriteInput(AndroidController.Instance.ResourceDirectory + ADB_EXE, "shell", inputLines);
            }
        }

        public static void ExecuteAdbShellCommandInputString(Device device, int timeout, params string[] inputLines)
        {
            lock (_lock)
            {
                Command.RunProcessWriteInput(AndroidController.Instance.ResourceDirectory + ADB_EXE, "shell", timeout, inputLines);
            }
        }

        public static string ExecuteAdbCommand(AdbCommand command, bool forceRegular = false)
        {
            string result = "";

            lock (_lock)
            {
                result = Command.RunProcessReturnOutput(AndroidController.Instance.ResourceDirectory + ADB_EXE, command.Command, forceRegular, command.Timeout);
            }

            return result;
        }

        public static void ExecuteAdbCommandNoReturn(AdbCommand command)
        {
            lock (_lock)
            {
                Command.RunProcessNoReturn(AndroidController.Instance.ResourceDirectory + ADB_EXE, command.Command, command.Timeout);
            }
        }

        public static int ExecuteAdbCommandReturnExitCode(AdbCommand command)
        {
            int result = -1;

            lock (_lock)
            {
                result = Command.RunProcessReturnExitCode(AndroidController.Instance.ResourceDirectory + ADB_EXE, command.Command, command.Timeout);
            }

            return result;
        }

        public static bool ServerRunning
        {
            get { return Command.IsProcessRunning(Adb.ADB); }
        }

        internal static void StartServer()
        {
            ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("start-server"));
        }

        internal static void KillServer()
        {
            ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("kill-server"));
        }

        internal static string Devices()
        {
            return ExecuteAdbCommand(Adb.FormAdbCommand("devices"));
        }

        public static bool PortForward(Device device, int localPort, int remotePort)
        {
            bool success = false;

            AdbCommand adbCmd = Adb.FormAdbCommand(device, "forward", "tcp:" + localPort, "tcp:" + remotePort);
            using (StringReader r = new StringReader(ExecuteAdbCommand(adbCmd)))
            {
                if (r.ReadToEnd().Trim() == "")
                    success = true;
            }

            return success;
        }
    }
}