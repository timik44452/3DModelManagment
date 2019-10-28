using MiddlewareAPI.CommandSystem;

namespace MiddlewareAPI.Core
{
    public class RequestWorker
    {
        public string Name { get; set; }
        public ICommand Command { get; set; }
        public IResponseBuilder ResponseBuilder { get; set; }
        public IRequestWorkPipeline Pipeline { get; set; }

        public RequestWorker(string name, IRequestWorkPipeline pipeline, ICommand command = null, IResponseBuilder builder = null)
        {
            Name = name;
            Command = command;
            ResponseBuilder = builder;
            Pipeline = pipeline;
        }
    }
}
