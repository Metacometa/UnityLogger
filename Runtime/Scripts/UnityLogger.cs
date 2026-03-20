using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kiranchy.UnityLogger
{
    public class UnityLogger
    {
        public static void AutoLog(string message, [CallerMemberName] string methodName = "")
        {
            string className = GetClassFromStack();
            Log(className, methodName, message);
        }

        public static void AsyncLog(object callingObject, string message, [CallerMemberName] string methodName = "")
        {
            string className = GetClassFromObject(callingObject);
            Log(className, methodName, message);
        }

        public static void AutoCompare(object a, object b, [CallerMemberName] string methodName = "")
        {
            string className = GetClassFromStack();
            Compare(className, methodName, a, b);            
        }

        public static void AsyncCompare(object callingObject, object a, object b, [CallerMemberName] string methodName = "")
        {
            string className = GetClassFromObject(callingObject);
            Compare(className, methodName, a, b);
        }

        private static void Log(string className, string methodName, string message)
        {
            string formattedMethodName = FormatMethodName(methodName);
            UnityEngine.Debug.Log($"[{className}] [{formattedMethodName}]: {message}");            
        }

        private static void Compare(string className, string methodName, object a, object b)
        {
            string formattedA = FormatVariable(a.ToString());
            string formattedB = FormatVariable(b.ToString());
            string message = $"{formattedA} Compares to {formattedB}";
            Log(className, methodName, message);
        }

        private static string GetClassFromStack()
        {
            var frame = new StackTrace().GetFrame(1);
            var method = frame.GetMethod();

            return method.DeclaringType?.Name ?? "None";
        }

        private static string GetClassFromObject(object callingObject)
        {
            return callingObject.GetType().ToString();
        }
    
        private static string FormatVariable(string text)
        {
            return FormatColor(text, "yellow");
        }

        private static string FormatMethodName(string text)
        {
            HashSet<string> unityCallbacks = new()
            {
                "Awake",
                "Start",
                "Update",
                "FixedUpdate",
                "LateUpdate",

                "OnEnable",
                "OnDisable",
                "OnDestroy",

                "OnTriggerEnter2D",
                "OnTriggerEnter",
                "OnTriggerStay2D",
                "OnTriggerStay",
                "OnTriggerExit2D",
                "OnTriggerExit",

                "OnCollisionEnter2D",
                "OnCollisionEnter",
                "OnCollisionStay2D",
                "OnCollisionStay",
                "OnCollisionExit2D",
                "OnCollisionExit"
            };

            if (unityCallbacks.Contains(text))
                text = FormatUnityCallback(text);

            return text;
        }

        private static string FormatUnityCallback(string text)
        {
            return FormatColor(text, "white");
        }

        private static string FormatColor(string text, string color)
        {
            return $"<color={color}>{text}</color>";
        }
    }
}