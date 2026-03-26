using System.Runtime.CompilerServices;
using Kiranchy.UnityLogger.Data.LogData;
using Kiranchy.UnityLogger.Data.MessageComponents;

namespace Kiranchy.UnityLogger
{
    public class UnityLogger
    {
        public static void AutoLog(object callingObject, string text, [CallerMemberName] string methodName = "")
        {
            string className = LoggerLogic.GetClassFromObject(callingObject);

            Message message = new Message(text);
            LogDataBuilder logDataBuilder = new LogDataBuilder()
                .WithClass(className)
                .WithMethod(methodName)
                .WithMessage(message);

            LoggerLogic.Log(logDataBuilder);
        }

        public static void AutoCompare(object callingObject, object a, object b, [CallerMemberName] string methodName = "")
        {
            string className = LoggerLogic.GetClassFromObject(callingObject);
            LogDataBuilder logDataBuilder = new LogDataBuilder()
                .WithClass(className)
                .WithMethod(methodName);

            LoggerLogic.Compare(logDataBuilder, a, b);
        }
    }
}