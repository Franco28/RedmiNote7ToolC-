namespace RegawMOD.Android
{

    public class FastbootCommand
    {
        private string command;
        private int timeout;
        internal string Command { get { return this.command; } }
        internal int Timeout { get { return this.timeout; } }
        internal FastbootCommand(string command) { this.command = command; this.timeout = RegawMOD.Command.DEFAULT_TIMEOUT; }

        public FastbootCommand WithTimeout(int timeout) { this.timeout = timeout; return this; }
    }

    public static class Fastboot
    {
        private const string FASTBOOT_EXE = "fastboot.exe";

        internal static string Devices()
        {
            return ExecuteFastbootCommand(FormFastbootCommand("devices"));
        }

        public static FastbootCommand FormFastbootCommand(string command, params string[] args)
        {
            string fbCmd = (args.Length > 0) ? command + " " : command;

            for (int i = 0; i < args.Length; i++)
                fbCmd += args[i] + " ";

            return new FastbootCommand(fbCmd);
        }

        public static FastbootCommand FormFastbootCommand(Device device, string command, params string[] args)
        {
            string fbCmd = "-s " + device.SerialNumber + " ";

            fbCmd += (args.Length > 0) ? command + " " : command;

            for (int i = 0; i < args.Length; i++)
                fbCmd += args[i] + " ";

            return new FastbootCommand(fbCmd);
        }

        public static string ExecuteFastbootCommand(FastbootCommand command)
        {
            return Command.RunProcessReturnOutput(AndroidController.Instance.ResourceDirectory + FASTBOOT_EXE, command.Command, command.Timeout);
        }

        public static void ExecuteFastbootCommandNoReturn(FastbootCommand command)
        {
            Command.RunProcessNoReturn(AndroidController.Instance.ResourceDirectory + FASTBOOT_EXE, command.Command, command.Timeout);
        }
    }
}