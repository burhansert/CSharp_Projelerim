using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Pipes;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiveByteAndRespond();
            Console.ReadKey();
        }

        private static void ReceiveByteAndRespond()
        {
            using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream("test-pipe"))
            {
                namedPipeClient.Connect();
                Console.WriteLine(namedPipeClient.ReadByte());
                namedPipeClient.WriteByte(2);
            }
        }
    }
}
