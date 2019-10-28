using MiddlewareAPI.Core;
using System.Collections.Generic;


namespace MiddlewareAPI.Service
{
    public static class RequestParser
    {
        // Command example:
        // rcf:filename.extension

        public static IEnumerator<Request> GetSubRequests(Request request)
        {
            foreach (string sub_request in request.Value.Split(';'))
                yield return new Request(sub_request);
        }

        public static string GetCommandName(Request request)
        {
            string text = request.Value;

            return text.Split(':')[0].Trim();
        }

        public static string[] GetCommandArgs(string commandName, Request request)
        {
            string text = request.Value;
            string text_without_command = text.Replace($"{ commandName}:", string.Empty);

            return text_without_command.Split(',');
        }
    }
}
