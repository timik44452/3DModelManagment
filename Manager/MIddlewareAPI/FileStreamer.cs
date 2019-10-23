using System;
using System.IO;
using ServiceAPI;
using System.Net;
using System.Net.Sockets;


namespace MiddlewareAPI
{
    public enum WorkMode
    {
        None,
        Server,
        Client
    }

    public class FileStreamer
    {
        public bool IsConnected
        {
            get => socket != null && socket.Connected;
        }

        public WorkMode WorkMode 
        { 
            get => workMode; 
        }

        private WorkMode workMode = WorkMode.None;
        private ILogger logger;
        private Socket socket;

        private int maximalConnectionCount = 16;


        public FileStreamer(ILogger logger)
        {
            this.logger = logger;
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ip, int port)
        {
            if (socket == null)
            {
                socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            }

            try
            {
                socket.Connect(ip, port);
                workMode = WorkMode.Client;
            }
            catch (Exception e)
            {
                logger?.ErrorMessage(e.Message);
            }
        }

        public void StartServer(int port)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

            try
            {
                socket.Bind(endPoint);

                socket.Listen(maximalConnectionCount);
                workMode = WorkMode.Server;

                logger.LogMessage($"Server was started successful");

                byte[] recieveBuffer = new byte[2048];

                while (true)
                {
                    Socket handler = socket.Accept();

                    logger.LogMessage($"Incoming user {handler.RemoteEndPoint}");

                    int recievedBytes = 0;
                    int allRecieved = 0;

                    using (var stream = new StreamWriter(@"temp.FBX"))
                    {
                        do
                        {
                            recievedBytes = handler.Receive(recieveBuffer);

                            stream.BaseStream.Write(recieveBuffer, 0, recievedBytes);

                            allRecieved += recievedBytes;
                        }
                        while (handler.Available > 0);
                    }

                    logger.LogMessage($"Recieved {allRecieved} bytes");
                    logger.LogMessage($"Recieved {allRecieved / 1024 / 1024} Mb");
                }
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
        }

        public void Close()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public PackageHeader[] GetFiles()
        {
            return new PackageHeader[0];
        }

        public void Send(string path)
        {
            throw new NotImplementedException();
            //if (!File.Exists(path))
            //{
            //    logger.ErrorMessage($"File {path} hasn't find");
            //    return;
            //}

            //try
            //{
            //    PackageHeader header = new PackageHeader();

                
            //    socket.Send(header.Data);
            //}
            //catch (Exception e)
            //{
            //    logger.ErrorMessage(e.Message);
            //}
        }

        public T Recieve<T>(string Name)
        {
            throw new NotImplementedException();
        }
    }
}