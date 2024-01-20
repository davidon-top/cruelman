using System.Reflection;
using CruelMan.Modules.Settings;

namespace CruelMan.Modules {
    public class AddStamina : Module {
        public override string Name => "Add Stamina";
        public override string Command => "addstamina";
        public override string Description => "Adds stamina to the player";
        public override ModuleType Type => ModuleType.Stats;

        protected override void Init() {
            AddSetting<NoChange>();
            AddSetting<Stamina>();
            AddSetting<SetStamina>();
        }
        protected override void OnDisable() {}
        protected override void OnEnable() {}
        protected override void OnUpdate() {
            if (GetSetting<NoChange>().Value) {
                FieldInfo fi = typeof(Player).GetField("m_stamina", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(Player.m_localPlayer, GetSetting<Stamina>().Value);
            }
        }
    }

    public class NoChange : BooleanSetting {
        public override string Name => "No Change";
        public override string Description => "Prevents stamina from changing";
    }

    public class Stamina : NumberSetting {
        public override string Name => "Stamina";
        public override string Description => "The amount of stamina to add";
        public override float Min {get;set;} = 0;
        public override float Max {get;set;} = 300;
        public override float Value {get;set;} = 0;
    }

    public class SetStamina : ActionSetting {
        public override string Name => "Set Stamina";
        public override string Description => "Sets the stamina to the value";

        public override void Run(Module module) {
            FieldInfo fi = typeof(Player).GetField("m_stamina", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(Player.m_localPlayer, module.GetSetting<Stamina>().Value);
        }
    }
}
