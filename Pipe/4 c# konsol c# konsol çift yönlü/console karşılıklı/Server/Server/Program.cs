using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Pipes;
using System.Linq;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversationWithTheServer();
        }

        private static void ConversationWithTheServer()
        {
            using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream(".", "test-pipe", PipeDirection.InOut))
            {
                namedPipeClient.Connect();
                Console.WriteLine("<----------Server---------->\n");
                namedPipeClient.ReadMode = PipeTransmissionMode.Message;
                string messageFromServer = ProcessSingleReceivedMessage(namedPipeClient);
                Console.WriteLine("Client Mesaji> {0}", messageFromServer);
                Console.Write("Mesajiniz > ");
                string response = Console.ReadLine();
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                namedPipeClient.Write(responseBytes, 0, responseBytes.Length);
                while (response != "x")
                {
                    messageFromServer = ProcessSingleReceivedMessage(namedPipeClient);
                    Console.WriteLine("Client Mesaji> {0}", messageFromServer);
                    Console.Write("Mesajiniz > ");
                    response = Console.ReadLine();
                    responseBytes = Encoding.UTF8.GetBytes(response);
                    namedPipeClient.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }

        private static string ProcessSingleReceivedMessage(NamedPipeClientStream namedPipeClient)
        {
            StringBuilder messageBuilder = new StringBuilder();
            string messageChunk = string.Empty;
            byte[] messageBuffer = new byte[5];
            do
            {
                namedPipeClient.Read(messageBuffer, 0, messageBuffer.Length);
                messageChunk = Encoding.UTF8.GetString(messageBuffer);
                messageBuilder.Append(messageChunk);
                messageBuffer = new byte[messageBuffer.Length];
            }
            while (!namedPipeClient.IsMessageComplete);
            return messageBuilder.ToString();
        }
    }
}
