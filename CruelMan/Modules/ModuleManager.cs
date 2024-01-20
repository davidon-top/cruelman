using System.Collections.Generic;
using UnityEngine;

namespace CruelMan.Modules {
    public class ModuleManager : MonoBehaviour {
        public static ModuleManager instance;
        public List<Module> modules = new List<Module>();

        public void Awake() {
            instance = this;
            AddModules();
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
