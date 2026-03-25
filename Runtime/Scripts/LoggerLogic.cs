using System.Diagnostics;

namespace Kiranchy.UnityLogger
{
    internal class LoggerLogic
    {
        public static void Log(string className, string methodName, string message)
        {
            LogData logData = new LogData(
                className,
                methodName,
                message
            );

            // UnityEngine.Debug.Log();       
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

        public static void Compare(string className, string methodName, object a, object b)
        {
            string formattedA = LogFormatter.FormatVariable(a.ToString());
            string formattedB = LogFormatter.FormatVariable(b.ToString());

            string result = LogFormatter.FormatEquationResult(a.Equals(b));

            // Com

            string message = $"{formattedA} Compares to {formattedB} Equals {result}";
            Log(className, methodName, message);
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