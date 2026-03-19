using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kiranchy.UnityLogger
{
    public class UnityLogger
    {
        private string _className = "";

        public UnityLogger(object classObject) : this(classObject.GetType().ToString()) {}
        public UnityLogger(string className)
        {
            _className = className;
        }

        public static void AutoLog(string message, [CallerMemberName] string methodName = "")
        {
            var frame = new StackTrace().GetFrame(1);
            var method = frame.GetMethod();
            var className = method.DeclaringType?.Name ?? "UnknownClass";
            // var methodName = method.Name;            

            UnityEngine.Debug.Log($"[{className}] [{methodName}]: {message}");
        }

        public static void AsyncLog(object obj, string message, [CallerMemberName] string methodName = "")
        {
            UnityEngine.Debug.Log($"[{obj.GetType()}] [{methodName}]: {message}");
        }
    }
}