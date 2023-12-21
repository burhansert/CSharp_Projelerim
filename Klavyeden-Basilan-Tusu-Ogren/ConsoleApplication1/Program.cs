using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tusBilgisi;   // string veya int değil değişkenmizi "ConsoleKeyInfo"
                                         // türünden tanımlamamız gerekmektedir.
            while (true)
            {
                tusBilgisi = Console.ReadKey(true);
                Console.WriteLine("Bastığınız Tuş: " + tusBilgisi.Key);
            }
        }
    }
}
