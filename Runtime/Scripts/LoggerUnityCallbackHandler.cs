using System.Collections.Generic;

namespace Kiranchy.UnityLogger
{
    internal class LoggerUnityCallbackHandler
    {
        private static HashSet<string> _unityCallbacks = new()
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

        public static bool IsUnityCallback(string text)
        {
            return _unityCallbacks.Contains(text);
        }
    }
}