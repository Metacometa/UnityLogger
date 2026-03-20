using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kiranchy.UnityLogger
{
    public class UnityLogger
    {
        public static void AutoLog(string message, [CallerMemberName] string methodName = "")
        {
            string className = LoggerLogic.GetClassFromStack();
            LoggerLogic.Log(className, methodName, message);
        }

        public static void AsyncLog(object callingObject, string message, [CallerMemberName] string methodName = "")
        {
            string className = LoggerLogic.GetClassFromObject(callingObject);
            LoggerLogic.Log(className, methodName, message);
        }

        public static void AutoCompare(object a, object b, [CallerMemberName] string methodName = "")
        {
            string className = LoggerLogic.GetClassFromStack();
            LoggerLogic.Compare(className, methodName, a, b);            
        }

        public static void AsyncCompare(object callingObject, object a, object b, [CallerMemberName] string methodName = "")
        {
            string className = LoggerLogic.GetClassFromObject(callingObject);
            LoggerLogic.Compare(className, methodName, a, b);
        }
    }
}