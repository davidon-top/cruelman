using System.Collections.Generic;
using CruelMan.Modules.Settings;
using CruelMan.Utils;
using UnityEngine;

namespace CruelMan.Modules {
    public enum ModuleType {
        Movement = 0,
        Stats = 1,
        Combat = 2,
        Misc = 3
    }

    public abstract class Module {
        public abstract string Name { get; }
        public abstract string Command { get; }
        public abstract string Description { get; }
        public abstract ModuleType Type { get; }
        public bool Enabled { get; set; } = false;
        public KeyCode bind { get; set; } = KeyCode.None;
        public List<Setting> Settings = new List<Setting>();

        public void Register() {
            ModuleManager.instance.modules.Add(this);
            new Terminal.ConsoleCommand($"cm{Command}", Description, delegate (Terminal.ConsoleEventArgs args) {
                Toggle();
                args.Context.AddString($"Toggled {Name}");
            });
            Init();
            Log.Info($"Registered module {Name}");
        }

        public void Toggle() {
            if (Enabled) {
                Disable();
            } else {
                Enable();
            }
        }

        public void Enable() {
            Enabled = true;
            Log.Info($"{Name} enabled");
            OnEnable();
        }

        public void Disable() {
            Enabled = false;
            Log.Info($"{Name} disabled");
            OnDisable();
        }

        public void Update() {
            if (Input.GetKeyDown(bind)) {
                Toggle();
            }
            foreach (Setting s in Settings) {
                if (s is ActionSetting) {
                    ActionSetting a = (ActionSetting)s;
                    if (Input.GetKeyDown(a.bind)) {
                        a.Run(this);
                    }
                }
            }
            if (Enabled) {
                OnUpdate();
            }
        }

        protected abstract void Init();

        protected abstract void OnEnable();
        protected abstract void OnDisable();

        protected abstract void OnUpdate();
        public virtual void Refresh() {}

        protected void AddSetting<T>() where T : Setting, new() {
            T setting = new T();
            Settings.Add(setting);
        }

        public T GetSetting<T>() where T : Setting, new() {
            foreach (Setting s in Settings) {
                if (s is T) {
                    return (T)s;
                }
            }
            throw new System.Exception("Setting not found");
        }
    }
}
