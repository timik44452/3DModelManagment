using ServiceAPI;
using MiddlewareAPI.Network;
using MiddlewareAPI.Core;

namespace MiddlewareAPI
{
    public class NetworkCommunicator
    {
        public bool IsConnected => networkUnit != null && networkUnit.IsWork;

        private ILogger logger;
        private WorkCore workCore;
        private INetworkUnit networkUnit;

        private const int MAXIMUM_CONNECTIONS = 16;
        private const int RECIEVE_INTERVAL_MS = 500;

        public NetworkCommunicator(ILogger logger, RequestWorkerSet workerSet)
        {
            workCore = new WorkCore(workerSet);
            this.logger = logger;

            Timer.RegisterNewAction(new TimerTask(RECIEVE_INTERVAL_MS, Reciever, loop: true));
        }

        public void Listen(int port)
        {
            var server = new Server(logger);
            server.StartServer(port, MAXIMUM_CONNECTIONS);
            networkUnit = server;
        }

        public void Connect(string address, int port)
        {
            var client = new Client(logger);
            client.Connect(address, port);
            networkUnit = client;
        }

        public void Send(object sender, Request request)
        {
            if (networkUnit != null)
            {
                networkUnit.Send(request.Value);
            }
            else
            {
                logger.ErrorMessage($"Network communicator hasn't been initialized, but {sender.ToString()} trying sending data");
            }
        }

        private void Reciever()
        {
            if (networkUnit != null && networkUnit.IsWork)
            {
                Request request = new Request(networkUnit.Recieve());

                workCore.Run(request);
            }
        }
    }
}
