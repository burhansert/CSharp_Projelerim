using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

//mesaji bu program aliyor

namespace pipe_server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NamedPipeServerStream pipeStream = new NamedPipeServerStream("mypipe"))
            {
                Console.WriteLine("Server calisiyor. Client'i aciniz.");
                pipeStream.WaitForConnection();
                StreamReader sr = new StreamReader(pipeStream);

                string tmp;
                while ((tmp = sr.ReadLine()) != null)
                {
                    Console.WriteLine("(Mesaj Geldi) "+ tmp);
                }

            }
            Console.ReadKey();
        }
    }
}
