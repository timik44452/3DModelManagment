using MiddlewareAPI.Core;
using MiddlewareAPI.CommandSystem;

namespace MiddlewareAPI.CommandSystem
{
    public interface IRequestWorkPipeline
    {
        void Run(DataContainer commandData, ICommand command, IResponseBuilder responseBuilder);
    }
}
