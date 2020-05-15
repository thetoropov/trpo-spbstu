using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;

namespace SomeProject.Library.Client
{
    public class Client
    {
        public TcpClient tcpClient;

        public byte clientSessionID = 0;

        int port = 8081;

        enum MessageType { Message, File, NewClientID, Delete }

        /// <summary>
        /// Initializes a new instance of Client class.
        /// </summary>
        /// <param name="ID"></param>
        public Client(byte ID)
        {
            clientSessionID = ID;
        }

        /// <summary>
        /// Waits for a message from server. Can accept text messages and new ID.
        /// </summary>
        /// <returns></returns>
        public OperationResult ReceiveMessageFromServer()
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", port);
                StringBuilder recievedMessage = new StringBuilder();
                byte[] data = new byte[256];
                NetworkStream stream = tcpClient.GetStream();

                if (stream.ReadByte() == (byte)MessageType.NewClientID)
                {
                    clientSessionID = (byte)stream.ReadByte();

                    if (clientSessionID == 0)
                    {
                        return new OperationResult(Result.Fail, "Connection rejected: too many clients.");
                    }

                    return new OperationResult(Result.OK, "Connected to server.");
                }
                else
                {
                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    stream.Close();
                    tcpClient.Close();

                    return new OperationResult(Result.OK, recievedMessage.ToString());
                }
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.ToString());
            }
        }

        /// <summary>
        /// Sends text message to server.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public OperationResult SendMessageToServer(string message)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                stream.WriteByte(clientSessionID);
                stream.WriteByte((byte)MessageType.Message);

                stream.Write(data, 0, data.Length);
                stream.Close();
                tcpClient.Close();
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Sends disconnection code to server.
        /// </summary>
        public void DisconnectFromServer()
        {

            tcpClient = new TcpClient("127.0.0.1", port);
            NetworkStream stream = tcpClient.GetStream();

            stream.WriteByte(clientSessionID);
            stream.WriteByte((byte)MessageType.Delete);

            stream.Close();
            tcpClient.Close();

        }

        /// <summary>
        /// Sends file to server.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public OperationResult SendFileToServer(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new Exception(message: "File not found.");

                tcpClient = new TcpClient("127.0.0.1", port);
                NetworkStream stream = tcpClient.GetStream();

                byte[] extention = System.Text.Encoding.UTF8.GetBytes(Path.GetExtension(path));
                byte[] data = File.ReadAllBytes(path);

                stream.WriteByte(clientSessionID);
                stream.WriteByte((byte)MessageType.File);

                stream.WriteByte(Convert.ToByte(extention.Length));

                stream.Write(extention, 0, extention.Length);
                stream.Write(data, 0, data.Length);

                stream.Close();
                tcpClient.Close();
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

    }
}
