using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SWEHubAPI.Service1Client api = new SWEHubAPI.Service1Client();
            
            api.Crime("AZ");
            Console.WriteLine(api.test(5));
            Console.WriteLine(api.Crime("AZ"));
            Console.WriteLine();
            Console.Write(api.Weather("AZ"));
            //Console.Write(api.Weather("Tempe"));
            Console.ReadKey();
        }
    }
}
