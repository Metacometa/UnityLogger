using System.Diagnostics;
using Kiranchy.UnityLogger.Colorizers;
using Kiranchy.UnityLogger.Data.LogData;
using Kiranchy.UnityLogger.Data.MessageComponents;
using Kiranchy.UnityLogger.Formatters;

namespace Kiranchy.UnityLogger
{
    internal class LoggerLogic
    {
        public static void Log(LogDataBuilder logDataBuilder)
        {
            LogData logData = logDataBuilder.Build();
            LogColorizer.Colorize(logData);
            string formattedLog = LogFormatter.Format(logData);

            UnityEngine.Debug.Log(formattedLog);       
            return;

            // string formattedClassName = FormatClassName(className);
            // string formattedMethodName = FormatMethodName(methodName);

            // // string log = $"[{formattedClassName}] [{formattedMethodName}]: {message}";
            // string sl = FormatPunctuation("//");
            // string colon = FormatPunctuation(":");
            // string log = $"{sl}{formattedClassName}{sl}{formattedMethodName}{sl}{colon} {message}";

            // if (!_unityCallbacks.Contains(methodName) &&
            //     TryGetUnityCallbackFromStack(out string unityCallback, out int frameIndex))
            // {
            //     string formattedUnityCallback = FormatUnityCallback(unityCallback);

            //     string methodDistance = frameIndex == 1 ? " " : FormatPunctuation("...");
            //     // log = $"[{formattedClassName}] [{formattedUnityCallback}]{methodDistance}[{formattedMethodName}]: {message}";
            //     log = $"{sl}{formattedClassName}{sl}{formattedUnityCallback}{sl}{methodDistance}{sl}{formattedMethodName}{sl}{colon} {message}";
            // }

            // UnityEngine.Debug.Log(log);            
        }

        public static void Compare(LogDataBuilder logDataBuilder, object a, object b)
        {
            // string formattedA = LogColorizer.FormatVariable(a.ToString());
            // string formattedB = LogColorizer.FormatVariable(b.ToString());

            // string result = LogColorizer.FormatEquationResult(a.Equals(b));
            
            Message message = new Message();
            message.Add<VariableComponent>(a.ToString());
            message.Add<TextComponent>("Compares to");
            message.Add<VariableComponent>(b.ToString());
            message.Add<TextComponent>("Equals");            

            logDataBuilder.WithMessage(message);
            // string message = $"{formattedA} Compares to {formattedB} Equals {result}";
            Log(logDataBuilder);
        }

        public static string GetClassFromStack()
        {
            var frame = new StackTrace().GetFrame(1);
            var method = frame.GetMethod();

            return method.DeclaringType?.Name ?? "None";
        }

        public static string GetClassFromObject(object callingObject)
        {
            return callingObject.GetType().ToString();
        }

        public static bool TryGetUnityCallbackFromStack(out string unityCallback, out int frameIndex)
        {
            unityCallback = null;
            frameIndex = -1;

            var stackTrace = new StackTrace();
            for (int i = 1; i < stackTrace.FrameCount; ++i)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame.GetMethod();

                if (LoggerUnityCallbackHandler.IsUnityCallback(method.Name))
                {
                    unityCallback = method.Name;
                    frameIndex = i;
                    return true;
                }
            }

            return false;
        }
    }
}