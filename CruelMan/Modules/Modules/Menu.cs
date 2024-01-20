using CruelMan.UI;
using UnityEngine;

namespace CruelMan.Modules {
    public class Menu : Module {
        public override string Name { get; } = "Menu";
        public override string Command { get; } = "menu";
        public override string Description { get; } = "Opens the main mod menu";
        public override ModuleType Type { get; } = ModuleType.Misc;

        protected override void Init() {
            bind = KeyCode.End;
        }

        protected override void OnEnable() {
            CM.go.GetComponent<MainUI>().menuOpen = true;
        }

        protected override void OnDisable() {
            CM.go.GetComponent<MainUI>().menuOpen = false;
        }

        protected override void OnUpdate() {}
    }
}
