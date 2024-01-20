using CruelMan.Modules;
using CruelMan.UI;
using UnityEngine;

namespace CruelMan {
    public class CM : MonoBehaviour {
        public static GameObject go;
        public static CMLoader loader;

        public static void Init(CMLoader loader) {
            CM.loader = loader;

            CM.go = new GameObject("CruelMan");
            Object.DontDestroyOnLoad(CM.go);

            go.AddComponent<MainUI>();
            go.AddComponent<ModuleManager>();
        }
    }
}
