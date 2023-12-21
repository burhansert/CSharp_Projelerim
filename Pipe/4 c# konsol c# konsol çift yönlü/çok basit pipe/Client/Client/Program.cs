using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Pipes;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SendByteAndReceiveResponse();
            Console.ReadKey();
        }

        private static void SendByteAndReceiveResponse()
        {
            using (NamedPipeServerStream namedPipeServer = new NamedPipeServerStream("test-pipe"))
            {
                namedPipeServer.WaitForConnection();
                namedPipeServer.WriteByte(1);
                int byteFromClient = namedPipeServer.ReadByte();
                Console.WriteLine(byteFromClient);
            }
        }
    }


}
