using MiddlewareAPI.CommandSystem;

namespace MiddlewareAPI.Core
{
    public interface IResponseBuilder
    {
        void BuildResponse(DataContainer data);
        Request GetResponse();
    }
}
