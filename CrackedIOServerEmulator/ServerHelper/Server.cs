using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static CrackedIOServerEmulator.Program;

namespace CrackedIOServerEmulator.ServerHelper
{
    public class HttpsCacheSession : HttpsSession
    {
        private const int HTTPStatusCode = 200;
        public HttpsCacheSession(NetCoreServer.HttpsServer server) : base(server) { }

        protected override void OnReceivedRequest(HttpRequest Request)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Log($"Accepted request from: {Request.Url}", "SERVER", ConsoleColor.Magenta);
            var result = Request.ToString().Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in result)
            {
                Log(data, "SERVER", ConsoleColor.Green);
            }
            if (Request.Method == "HEAD")
                SendResponseAsync(Response.MakeHeadResponse());
            else if (Request.Method == "GET")
            {
                SendResponseAsync(Response.MakeErrorResponse(200, "[{DateTime.Now}] Cracked.io Server Emulator by https://t.me/CabboShiba & https://t.me/OfficialChaos || https://github.com/CabboShiba & https://github.com/FaxHack\n\nhttps://github.com/CabboShiba/Cracked.ioServerEmulator\nhttps://github.com/FaxHack/Cracked.ioServerEmulator"));
            }
            else if ((Request.Method == "POST") || (Request.Method == "PUT"))
            {
                string bypass = CrackedIOServerEmulator.ServerHelper.Emulator.AuthEmulator.Credentials.GetValidResponse();
                SendResponseAsync(Response.MakeErrorResponse(200, bypass));
            }
        }
    }

    class HttpsCacheServer : NetCoreServer.HttpsServer
    {
        public HttpsCacheServer(SslContext context, IPAddress address, int port) : base(context, address, port) { }

        protected override SslSession CreateSession() { return new HttpsCacheSession(this); }
    }

}
