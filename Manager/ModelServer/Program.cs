using System;
using ServiceAPI;
using MiddlewareAPI;

namespace ModelServer
{
    public class Program
    {
        private static FileStreamer server;
        private static ILogger logger;

        private static void Main(string[] args)
        {
            logger = new ConsoleLogger();

            try
            {
                server = new FileStreamer(logger);
                server.StartServer(67);
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
        }
    }
}