using MiddlewareAPI.Core;
using MiddlewareAPI.Service;

namespace MiddlewareAPI.CommandSystem
{
    public class OnlyCommandPipeline : IRequestWorkPipeline
    {
        public void Run(DataContainer commandData, ICommand command, IResponseBuilder responseBuilder)
        {
           
            RequestWorkPipelineValidator.Validate(commandData, command, responseBuilder);

            command.Data.Integrate(commandData);
            command.Work();
        }
    }
}
