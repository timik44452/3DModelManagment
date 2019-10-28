using MiddlewareAPI.CommandSystem;
using MiddlewareAPI.Core;

namespace MiddlewareAPI.Service
{
    public static class RequestWorkPipelineValidator
    {
        public static void Validate(DataContainer commandData, ICommand command, IResponseBuilder builder)
        {
            if (command != null && command.Data == null)
            {
                throw new System.Exception("Command data container hasn't been initialized");
            }
        }
    }
}
