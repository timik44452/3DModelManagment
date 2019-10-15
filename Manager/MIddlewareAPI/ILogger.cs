using System;
using System.Collections.Generic;
using System.Text;

namespace MiddlewareAPI
{
    public interface ILogger
    {
        void LogMessage(object msg);
        void WarningMessage(object msg);
        void ErrorMessage(object msg);
    }
}
