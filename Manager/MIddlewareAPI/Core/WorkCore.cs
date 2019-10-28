using MiddlewareAPI.Service;
using MiddlewareAPI.CommandSystem;

namespace MiddlewareAPI.Core
{
    public class WorkCore
    {
        private RequestWorkerSet workerSet;

        public WorkCore(RequestWorkerSet workerSet)
        {
            this.workerSet = workerSet;
        }

        public bool Run(Request request)
        {
            string commandName = RequestParser.GetCommandName(request);
            string[] commandArgs = RequestParser.GetCommandArgs(commandName, request);

            DataContainer data = new DataContainer();
            RequestWorker worker = workerSet.GetWorker(commandName);

            data.SetObject("Args", commandArgs);

            if (worker != null)
            {
                worker.Pipeline.Run(data, worker.Command, worker.ResponseBuilder);
            }

            return worker != null;
        }
    }
}
