namespace MiddlewareAPI.CommandSystem
{
    public interface ICommand
    {
        DataContainer Data { get; set; }

        DataContainer Work();
    }
}
