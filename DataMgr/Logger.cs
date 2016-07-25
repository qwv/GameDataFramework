using UnityEngine;

namespace Assets.Scripts.Data.Internal
{
    public class Logger
    {
        private const string TAG = "Data: ";

        private const string DEFAULT_COLOR = "cyan";

        private const string ERROR_COLOR = "red";

        public static void Assert(bool condition, string message)
        {
            Debug.Assert(!condition, message);
        }

        public static void Log(string message)
        {
            string format = "<color=" + DEFAULT_COLOR + ">" + TAG + message + "</color>";
            Debug.Log(format);
        }

        public static void LogError(string message)
        {
            string format = "<color=" + ERROR_COLOR + ">" + TAG + message + "</color>";
            Debug.Log(format);
        }
    }
}
