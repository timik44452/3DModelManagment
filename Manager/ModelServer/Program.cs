using System;
using ServiceAPI;
using MiddlewareAPI;
using MiddlewareAPI.BaseRequestWorkers;

namespace ModelServer
{
    public class Program
    {
        private static NetworkCommunicator communicator;
        private static ILogger logger;

        private static void Main(string[] args)
        {
            logger = new ConsoleLogger();

            try
            {
                communicator = new NetworkCommunicator(logger, BaseRequestWorkers.GetFileWorker(null, logger));
                communicator.Listen(67);
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
                WaitKey();
            }

            WaitKey();
        }

        private static void WaitKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}