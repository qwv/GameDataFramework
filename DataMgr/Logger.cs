#define __DATA_LOG__

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
#if __DATA_LOG__
            Debug.Assert(!condition, message);
#endif
        }

        public static void Log(string message)
        {
#if __DATA_LOG__
            string format = "<color=" + DEFAULT_COLOR + ">" + TAG + message + "</color>";
            Debug.Log(format);
#endif
        }

        public static void LogError(string message)
        {
#if __DATA_LOG__
            string format = "<color=" + ERROR_COLOR + ">" + TAG + message + "</color>";
            Debug.Log(format);
#endif
        }
    }
}
