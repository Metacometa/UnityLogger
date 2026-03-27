using System;
using System.Text.RegularExpressions;
using Kiranchy.UnityLogger.Data.LogData;

namespace Kiranchy.UnityLogger.Formatters
{
    internal class DotFormatter : BaseFormatter
    {
        protected override string FormatCallback(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? "" : $"{text}.";
        }

        protected override string Build(LogData logData)
        {
            string context = $"[{logData.Class}] {logData.Callback}{logData.Method}"; 
            return $"{context} # {logData.Message.Token}";
        }

    }
}