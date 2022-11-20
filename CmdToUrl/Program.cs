using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CmdToUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Missing arguments, please provide an URL in the first argument. Excecution aborted!");
                Console.ReadKey();
            }

            var url = args[0];

            try
            {
                var request = WebRequest.Create(url);
                request.Method = "GET";
                Console.WriteLine("Send HTTP GET request: " + url);

                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var reader = new StreamReader(webStream);
                Console.WriteLine("Response:");
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Excecution aborted!");
                Console.ReadKey();
            }
            Thread.Sleep(3000);
        }
    }
}
