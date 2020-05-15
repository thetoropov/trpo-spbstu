using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeProject.Library.Server
{
    public class Server
    {
        TcpListener serverListener;
        int recievedFileNumber = 0;

        List<byte> clients = new List<byte>();
        int maxClients = 2;
        int idForNewClient = 1;

        enum MessageType { Message, File, NewClientID, Delete }

        public Server()
        {
            serverListener = new TcpListener(IPAddress.Loopback, 8081);
        }

        public bool TurnOffListener()
        {
            try
            {
                if (serverListener != null)
                    serverListener.Stop();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn off listener: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Runs server listener. Does actions depending on message processing result.
        /// </summary>
        /// <returns></returns>
        public async Task TurnOnListener()
        {
            try
            {
                if (serverListener != null)
                    serverListener.Start();
                while (true)
                {
                    OperationResult result = await ReceiveSmthFromClient();
                    if (result.Result == Result.Fail)
                    {
                        Console.WriteLine("Unexpected error: " + result.Message);
                        SendMessageToClient("Server error: " + result.Message);
                    }
                    else if (result.Result == Result.OK)
                    {
                        Console.WriteLine("New message from client " + result.Message);
                        SendMessageToClient("Server recieved message successfully!");
                    }
                    else if (result.Result == Result.ForbiddenUser)
                    {
                        Console.WriteLine("New client rejected: too many clients." + result.Message);
                        SendNewIDToClient(0);
                    }
                    else if (result.Result == Result.OkFile)
                    {
                        Console.WriteLine("New file from client " + result.Message);
                        SendMessageToClient("Server recieved file successfully!");
                    }
                    else // Deleted or new
                    {
                        Console.WriteLine(result.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn on listener: " + e.Message);
            }
        }

        /// <summary>
        /// Checks if clients list contains given ID, returns same ID if it exists, "0" if new ID was added and "-1" if no more place for new ID's.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns>gregr</returns>
        public int CheckClient(int clientID)
        {
            if (clientID == 0 && clients.Count < maxClients)
            {
                clients.Add((byte)idForNewClient);
                SendNewIDToClient((byte)idForNewClient);
                Interlocked.Increment(ref idForNewClient);
                return 0;
            }
            else if (clients.Contains((byte)clientID))
            {
                return clientID;
            }

            return -1;
        }

        /// <summary>
        /// Waits for client to send data. Decides if data is text message, file or disconnect message.
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult> ReceiveSmthFromClient()
        {
            try
            {
                Console.WriteLine("Waiting for connections...");
                TcpClient client = serverListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                int clientID = CheckClient(stream.ReadByte());

                if (clientID == -1)
                {
                    return new OperationResult(Result.ForbiddenUser, "");
                }
                else if (clientID == 0)
                {
                    return new OperationResult(Result.OkNewUser, "New client added. ID: " + clients[clients.Count - 1]);
                }

                OperationResult res = new OperationResult(Result.Fail, "Unknown message format.");

                var msgType = stream.ReadByte();

                if (msgType == (byte)MessageType.Message)
                {
                    res = await ReceiveMessageFromClient(stream);
                    res.Message = clientID + ": " + res.Message;
                }
                else if (msgType == (byte)MessageType.File)
                {
                    res = await ReceiveFileFromClient(stream);
                }
                else if (msgType == (byte)MessageType.Delete)
                {
                    clients.Remove((byte)clientID);
                    res.Result = Result.OkDeleted;
                    res.Message = "User " + clientID + " disconnected";
                }

                stream.Close();
                client.Close();

                return res;
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }

        }

        /// <summary>
        /// Converts byte data from stream to text.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public async Task<OperationResult> ReceiveMessageFromClient(NetworkStream stream)
        {
            StringBuilder recievedMessage = new StringBuilder();

            byte[] data = new byte[256];
            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return new OperationResult(Result.OK, recievedMessage.ToString());
        }

        /// <summary>
        /// Converts byte data from stream to file.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public async Task<OperationResult> ReceiveFileFromClient(NetworkStream stream)
        {
            try
            {
                string extension = getExtension(stream);

                string newDirectory = Directory.GetCurrentDirectory() + @"\" + DateTime.Today.ToString("yyyy-MM-dd");
                Directory.CreateDirectory(newDirectory);
                string newPath = newDirectory + @"\" + recievedFileNumber + extension;

                int recievedFileNumberTmp = recievedFileNumber;

                Interlocked.Increment(ref recievedFileNumber);

                FileStream file = new FileStream(newPath, FileMode.OpenOrCreate);

                byte[] data = new byte[256];
                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    file.Write(data, 0, bytes);
                }
                while (stream.DataAvailable);

                file.Close();

                return new OperationResult(Result.OkFile, " recieved and saved as " + recievedFileNumberTmp + extension);
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }


        }

        /// <summary>
        /// Gets file extension from file data stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private string getExtension(NetworkStream stream)
        {
            int exSize = stream.ReadByte();
            byte[] extention = new byte[exSize];

            stream.Read(extention, 0, exSize);

            return Encoding.UTF8.GetString(extention, 0, exSize);
        }

        /// <summary>
        /// Sends text message to client.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public OperationResult SendMessageToClient(string message)
        {
            try
            {
                TcpClient client = serverListener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                stream.WriteByte((byte)MessageType.Message);

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
            return new OperationResult(Result.OK, "");
        }

        /// <summary>
        /// Sends new ID to client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationResult SendNewIDToClient(byte id)
        {
            try
            {
                TcpClient client = serverListener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                stream.WriteByte((byte)MessageType.NewClientID);
                stream.WriteByte(id);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
            return new OperationResult(Result.OK, "");
        }
    }
}