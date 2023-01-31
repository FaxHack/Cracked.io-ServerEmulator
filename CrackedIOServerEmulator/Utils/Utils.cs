using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Resources;

namespace CrackedIOServerEmulator
{
    internal class Utils
    {
        public static void Leave()
        {
            Program.Log("Press enter to leave", "LEAVE", ConsoleColor.Red);
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }

        public static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string Logo = "                                _____                _            _ ____                            \r\n                               / ____|              | |          | |  _ \\                           \r\n                              | |     _ __ __ _  ___| | _____  __| | |_) |_   _ _ __   __ _ ___ ___ \r\n                              | |    | '__/ _` |/ __| |/ / _ \\/ _` |  _ <| | | | '_ \\ / _` / __/ __|\r\n                              | |____| | | (_| | (__|   <  __/ (_| | |_) | |_| | |_) | (_| \\__ \\__ \\\r\n                               \\_____|_|  \\__,_|\\___|_|\\_\\___|\\__,_|____/ \\__, | .__/ \\__,_|___/___/\r\n                                                                           __/ | |                  \r\n                                                                          |___/|_|                  ";
            Console.WriteLine(Logo);
            Console.ResetColor();
        }
    }
}
