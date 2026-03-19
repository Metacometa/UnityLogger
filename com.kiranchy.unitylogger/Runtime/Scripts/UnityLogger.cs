using UnityEngine;

namespace Kiranchy.UnityLogger
{
    public class UnityLogger
    {
        private string _className = "";

        public UnityLogger(object classObject)
        {
            _className = classObject.GetType().ToString();
        }

        public UnityLogger(string className)
        {
            _className = className;
        }

        public void Log(string message)
        {
            Debug.Log($"[{_className}] {message}");
        }
    }
}