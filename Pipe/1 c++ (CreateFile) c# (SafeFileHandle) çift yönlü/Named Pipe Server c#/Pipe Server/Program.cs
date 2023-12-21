using System;
using System.Collections.Generic;
using System.Text;

namespace Pipe_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<----------C# Programına Hoşgeldiniz---------->\n");
            NamedPipeServer PServer1 = new NamedPipeServer(@"\\.\pipe\myNamedPipe1", 0);
            NamedPipeServer PServer2 = new NamedPipeServer(@"\\.\pipe\myNamedPipe2", 1);

            PServer1.Start();
            PServer2.Start();

            string Ms = "Start";
            do
            {
                Console.Write("C# Programı>> ");
                Ms = Console.ReadLine();
                PServer2.SendMessage(Ms, PServer2.clientse);
            } while (Ms != "quit");

            PServer1.StopServer();
            PServer2.StopServer();
        }
    }
}
