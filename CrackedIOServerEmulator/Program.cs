using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using NetCoreServer;

namespace CrackedIOServerEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"[{DateTime.Now}] Cracked.io Server Emulator by https://t.me/CabboShiba & https://t.me/OfficialChaos || https://github.com/CabboShiba & https://github.com/FaxHack";
            Console.SetWindowSize(134, 30);
            Utils.Logo();
            Console.WriteLine("\n");
            Log("Starting Server Emulator. Be sure you have previously installed SSL Certificate. Password is \"shiba\".", "CONFIG", ConsoleColor.Cyan);
            Log("Editing Hosts File...", "CONFIG", ConsoleColor.Cyan);
            if(Host.HostEditor.Edit() == true)
            {
                Log("Succesfully edited Hosts File. Now Server Emulator will be able to run without problem.", "BYPASS", ConsoleColor.Cyan);
            }
            else
            {
                Utils.Leave();
            }
            try
            {
                var context = new SslContext(SslProtocols.Tls12, new X509Certificate2(Environment.CurrentDirectory + @"\CertificateBypass.pfx", "shiba"));
                var server = new CrackedIOServerEmulator.ServerHelper.HttpsCacheServer(context, IPAddress.Parse("127.0.0.1"), 443);
                server.Start();
                Log("Succesfully started Server Emulator...", "SUCCESS", ConsoleColor.Green);
            }
            catch(Exception ex)
            {
                Log($"Could not start Server Emulator.\nError: {ex.Message}", "ERROR", ConsoleColor.Red);
            }
            for(;;)
            {

            }
        }



        public static void Log(string Data, string Type, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"[{DateTime.Now} - {Type}] {Data}");
            Console.ResetColor();
        }
    }
}