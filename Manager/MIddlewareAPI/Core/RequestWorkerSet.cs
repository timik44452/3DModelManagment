using System.Linq;
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
            foreach (RequestWorker worker in workers)
            {
                int Index = this.workers.FindIndex(x => x.Name == worker.Name);

                if (Index == -1)
                    this.workers.Add(worker);
                else
                    this.workers[Index] = worker;
            }
        }

        public static RequestWorkerSet Combine(params RequestWorkerSet[] workerSets)
        {
            RequestWorkerSet requestWorkerSet = new RequestWorkerSet();

            foreach (RequestWorkerSet workerSet in workerSets)
            {
                requestWorkerSet.AddRequestWorkers(workerSet.workers.ToArray());
            }

            return requestWorkerSet;
        }

        public RequestWorker GetWorker(string name)
        {
            return workers.Find(x => x.Name == name);
        }
    }
}
