using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Pipes;
using System.Linq;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversationWithTheClient();
        }

        private static void ConversationWithTheClient()
        {
            using (NamedPipeServerStream namedPipeServer = new NamedPipeServerStream("test-pipe", PipeDirection.InOut,
                1, PipeTransmissionMode.Message))
            {
                Console.WriteLine("< ----------Client---------->\n");
                namedPipeServer.WaitForConnection();
                Console.Write("Mesajiniz > ");
                string message = Console.ReadLine();
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                namedPipeServer.Write(messageBytes, 0, messageBytes.Length);

                string response = ProcessSingleReceivedMessage(namedPipeServer);
                Console.WriteLine("Server Mesaji > {0}", response);
                while (response != "x")
                {
                    Console.Write("Mesajiniz > ");
                    message = Console.ReadLine();
                    messageBytes = Encoding.UTF8.GetBytes(message);
                    namedPipeServer.Write(messageBytes, 0, messageBytes.Length);
                    response = ProcessSingleReceivedMessage(namedPipeServer);
                    Console.WriteLine("Client Mesaji > {0}", response);
                }

                Console.WriteLine("The client has ended the conversation.");
            }
        }

        private static string ProcessSingleReceivedMessage(NamedPipeServerStream namedPipeServer)
        {
            StringBuilder messageBuilder = new StringBuilder();
            string messageChunk = string.Empty;
            byte[] messageBuffer = new byte[5];
            do
            {
                namedPipeServer.Read(messageBuffer, 0, messageBuffer.Length);
                messageChunk = Encoding.UTF8.GetString(messageBuffer);
                messageBuilder.Append(messageChunk);
                messageBuffer = new byte[messageBuffer.Length];
            }
            while (!namedPipeServer.IsMessageComplete);
            return messageBuilder.ToString();
        }
    }


}
