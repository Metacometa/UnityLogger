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
            HandleCallback(logDataBuilder);
            BaseFormatter formatter = new DotFormatter();
            LogData logData = logDataBuilder.Build();

            Colorizer.Colorize(logData);
            string formattedLog = formatter.Format(logData);
            UnityEngine.Debug.Log(formattedLog);       
        }

        public static void Compare(LogDataBuilder logDataBuilder, object a, object b)
        {
            Message message = new Message();
            message.Add<VariableComponent<string>>(a.ToString());
            message.Add<TextComponent>("vs");    
            message.Add<VariableComponent<string>>(b.ToString());
            message.Add<TextComponent>("->");            
            message.Add<VariableComponent<bool>>(a.Equals(b).ToString());

            logDataBuilder.WithMessage(message);
            Log(logDataBuilder);
        }

        public static string GetClassFromStack()
        {
            var frame = new StackTrace().GetFrame(2);
            var method = frame.GetMethod();

            return method.DeclaringType?.Name ?? "None";
        }

        public static string GetClassFromObject(object callingObject)
        {
            return callingObject.GetType().ToString();
        }

        public static bool TryGetCallbackFromStack(out string callback, out int frameIndex)
        {
            callback = null;
            frameIndex = -1;

            var stackTrace = new StackTrace();
            for (int i = 1; i < stackTrace.FrameCount; ++i)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame.GetMethod();

                if (LoggerUnityCallbackHandler.IsUnityCallback(method.Name))
                {
                    callback = method.Name;
                    frameIndex = i;
                    return true;
                }
            }

            return false;
        }

        private static void HandleCallback(LogDataBuilder logDataBuilder)
        {
            LogData logData = logDataBuilder.Build();
            if (LoggerUnityCallbackHandler.IsUnityCallback(logData.Method))
                return;

            if (TryGetCallbackFromStack(out string callback, out int frameIndex) &&
                frameIndex > 1)
            {
                logDataBuilder.WithCallback(callback);                
            }
        }
    }
}