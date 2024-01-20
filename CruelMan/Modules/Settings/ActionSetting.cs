using UnityEngine;

namespace CruelMan.Modules.Settings {
    public abstract class ActionSetting : Setting {
        public KeyCode bind { get; set; } = KeyCode.None;

        public abstract void Run(Module module);
    }
}
