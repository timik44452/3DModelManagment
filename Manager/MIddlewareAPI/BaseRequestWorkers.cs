using ServiceAPI.Log;
using MiddlewareAPI.Core;
using MiddlewareAPI.CommandSystem;

namespace MiddlewareAPI
{
    public static class BaseRequestWorkers
    {
        public static RequestWorkerSet GetDefaultWorker(DataContainer data, ILogger logger)
        {
            RequestWorker logWorker = new RequestWorker("log", new OnlyCommandPipeline(), new LogCommand(logger));
            RequestWorkerSet defaultWorkerSet = new RequestWorkerSet();

            defaultWorkerSet.AddRequestWorkers(logWorker);

            return defaultWorkerSet;
        }
    }
}
