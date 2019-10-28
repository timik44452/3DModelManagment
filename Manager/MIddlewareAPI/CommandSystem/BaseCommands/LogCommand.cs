using ServiceAPI;

namespace MiddlewareAPI.CommandSystem
{
    public class LogCommand : ICommand
    {
        public string Name => "log";

        public DataContainer Data { get; set; }

        public LogCommand(ILogger logger)
        {
            Data = new DataContainer();
            Data.SetObject("Logger", logger);
        }

        public DataContainer Work()
        {
            ILogger logger = Data.GetObject<ILogger>("Logger");

            foreach (string text in Data.GetObject<string[]>("Args"))
                logger.LogMessage(text);

            return null;
        }
    }
}
