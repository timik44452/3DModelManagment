using System;
using ServiceAPI;
using System.Net;
using System.Net.Sockets;

namespace MiddlewareAPI.Network
{
    public class Client : INetworkUnit
    {
        public bool IsWork => socket != null && socket.Connected;

        private Socket socket;
        private ILogger logger;


        public Client(ILogger logger)
        {
            this.logger = logger;
        }

        public void Connect(string address, int port)
        {
            if (socket == null)
            {
                socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            }

            try
            {
                socket.ConnectAsync(address, port);
            }
            catch (Exception e)
            {
                logger?.ErrorMessage(e.Message);
            }
        }

        public string Recieve()
        {
            throw new NotImplementedException();
        }

        public void Send(string value)
        {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(value);

            SocketAsyncEventArgs eventArgs = new SocketAsyncEventArgs();
            eventArgs.SetBuffer(buffer, 0, buffer.Length);
            socket.SendAsync(eventArgs);
        }
    }
}
