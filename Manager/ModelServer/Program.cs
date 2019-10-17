﻿using System;
using MiddlewareAPI;

namespace ModelServer
{
    public class Program
    {
        private static FileServer server;
        private static ConsoleLogger logger;

        private static void Main(string[] args)
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