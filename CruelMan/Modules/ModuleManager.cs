using System.Collections.Generic;
using UnityEngine;

namespace CruelMan.Modules {
    public class ModuleManager : MonoBehaviour {
        public static ModuleManager instance;
        public List<Module> modules = new List<Module>();

        public void Awake() {
            instance = this;
            AddModules();
            new Terminal.ConsoleCommand($"cmbind", "binds a module to a key", delegate (Terminal.ConsoleEventArgs args) {
                if (args.Args.Length < 2) {
                    args.Context.AddString("Usage: cmbind <module> <key>");
                    return;
                }
                string module = args.Args[1];
                string key = args.Args[2];
                foreach (Module m in modules) {
                    if (m.Command == module.ToLower()) {
                        m.bind = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
                        args.Context.AddString($"Bound {module} to {key}");
                        return;
                    }
                }
                args.Context.AddString($"Module {module} not found");
            });
        }

        public void Update() {
            foreach (Module module in modules) {
                module.Update();
            }
        }

        private void AddModules() {
            AddModule<NoDeath>();
            AddModule<Menu>();
            AddModule<AddStamina>();
            AddModule<InfCarry>();
            AddModule<GuardianPowers>();
            AddModule<NotInAttack>();
            AddModule<Speed>();
            AddModule<JumpHeight>();
            AddModule<InstantDmg>();
            AddModule<SwimSpeed>();
        }

        private void AddModule<T>() where T : Module, new() {
            T module = new T();
            module.Register();
        }

        public T GetModule<T>() where T : Module, new() {
            foreach (Module module in modules) {
                if (module is T) {
                    return (T)module;
                }
            }
            throw new System.Exception("Module not found");
        }
    }
}
