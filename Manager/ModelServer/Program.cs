using System;
using MiddlewareAPI;

namespace ModelServer
{
    public class Program
    {
        static FileServer server;
        static ConsoleLogger logger;

        static void Main(string[] args)
        {
            logger = new ConsoleLogger();

            try
            {
                server = new FileServer(67, logger);
                server.Start();
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
        }
    }
}
