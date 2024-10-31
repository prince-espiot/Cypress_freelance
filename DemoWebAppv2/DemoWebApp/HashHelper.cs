using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp
{
    public static class HashHelper
    {
        public static string CreateHash(string str)
            => string.Concat(SHA512.HashData(Encoding.UTF8.GetBytes(str)).Select(x => x.ToString("x2")));
    }
}
