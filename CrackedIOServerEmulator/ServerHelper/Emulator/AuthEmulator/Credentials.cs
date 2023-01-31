using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackedIOServerEmulator.ServerHelper.Emulator.AuthEmulator
{
    internal class Credentials
    {
        private const int SupremeID = 12;
        private const bool Authenticated = true;
        public static string GetValidResponse()
        {
            string Response = $"{{\"auth\":{Authenticated},\"uid\":\"{GetRandomNumber(100000, 500000)}\",\"username\":\"{GetRandomString(8)}\",\"posts\":\"{GetRandomNumber(40, 120)}\",\"likes\":\"{GetRandomNumber(100, 200)}\",\"group\":\"{SupremeID}\",\"hash\":\"{GetRandomString(64)}\",\"vars\":\"\",\"blacklist\":0}}";
            return Response;
        }

        private static Random ran = new Random();
        private static int GetRandomNumber(int Min, int Max)
        {
            if(Min >= Max)
            {
                Min = Max - 1;
            }
            return ran.Next(Min, Max);
        }

        private static string GetRandomString(int length)
        {
            const string chars = "qwertyuioplkjhgfdsazxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[ran.Next(s.Length)]).ToArray());
        }
    }
}
