using MiddlewareAPI.Core;
using MiddlewareAPI.CommandSystem;

namespace MiddlewareAPI.BaseRequestWorkers
{
    public static class BaseRequestWorkers
    {
        public static RequestWorkerSet GetFileWorker(System.Net.Sockets.Socket socket, ServiceAPI.ILogger logger)
        {
            if (fileWorker == null)
            {
                RequestWorker logWorker = new RequestWorker("log", new OnlyCommandPipeline(), new LogCommand(logger));

                fileWorker = new RequestWorkerSet();
                fileWorker.AddRequestWorkers(logWorker);
            }

            return fileWorker;
        }

        private static RequestWorkerSet fileWorker;
    }
}
