using System;
using System.IO;
using System.Net.Sockets;
using ServiceAPI;

namespace MiddlewareAPI
{
    public class FileSender
    {
        public bool IsConnected
        {
            get => socket != null && socket.Connected;
        }

        private ILogger logger;
        private Socket socket;

        public FileSender(ILogger logger)
        {
            this.logger = logger;
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
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
        }

        public void Send(string path)
        {
            if (!File.Exists(path))
            {
                logger.ErrorMessage($"File {path} hasn't find");
                return;
            }

            try
            {
                byte[] data = File.ReadAllBytes(path);
                socket.Send(data);
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
        }
    }
}