namespace CruelMan.Utils {
    public static class Log {
        public static void Info(string message) {
#if DEBUG
            UnityEngine.Debug.Log($"[CruelMan] {message}");
#endif
        }

        public static void Warn(string message) {
#if DEBUG
            UnityEngine.Debug.LogWarning($"[CruelMan] {message}");
#endif
        }

        public static void Error(string message) {
#if DEBUG
            UnityEngine.Debug.LogError($"[CruelMan] {message}");
#endif
        }
    }
}
