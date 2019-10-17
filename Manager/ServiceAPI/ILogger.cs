namespace ServiceAPI
{
    public interface ILogger
    {
        void LogMessage(object msg);

        void WarningMessage(object msg);

        void ErrorMessage(object msg);
    }
}