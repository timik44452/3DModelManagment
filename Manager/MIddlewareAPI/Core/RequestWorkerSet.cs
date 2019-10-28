using System.Collections.Generic;

namespace MiddlewareAPI.Core
{
    public class RequestWorkerSet
    {
        private List<RequestWorker> workers;

        public RequestWorkerSet()
        {
            workers = new List<RequestWorker>();
        }


        public void AddRequestWorkers(params RequestWorker[] workers)
        {
            this.workers.AddRange(workers);
        }

        public RequestWorker GetWorker(string name)
        {
            return workers.Find(x => x.Name == name);
        }
    }
}
