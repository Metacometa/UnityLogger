using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kiranchy.UnityLogger
{
    internal class LogFormatter
    {
        public static string Format(LogData logData)
        {
            string className = Colorize(logData.Class, "cyan");
            string unityCallbackName = Colorize(logData.Callback, "cyan");
            string methodName = Colorize(logData.Method,
                LoggerUnityCallbackHandler.IsUnityCallback(
                    logData.Method) ?
                        "cyan" : 
                        "white"
            );

            // logData
            return null;
        }

        public static string FormatVariable(string text)
        {
            return Colorize(text, "yellow");
        }

        public static string FormatPunctuation(string text)
        {
            return Colorize(text, "white");
        }

        public static string FormatEquationResult(bool result)
        {
            return result ? Colorize(result.ToString(), "green") : Colorize(result.ToString(), "red");
        }

        public static string FormatMethodName(string text)
        {
            if (LoggerUnityCallbackHandler.IsUnityCallback(text))
                text = FormatUnityCallback(text);

            return Colorize(text, "white");
        }

        public static string FormatClassName(string text)
        {
            return Colorize(text, "cyan");
        }

        public static string FormatUnityCallback(string text)
        {
            return Colorize(text, "cyan");
        }

        private static string Colorize(string text, string color)
        {
            return $"<color={color}>{text}</color>";
        }
    }
}