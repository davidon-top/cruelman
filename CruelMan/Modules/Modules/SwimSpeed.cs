using CruelMan.Modules.Settings;

namespace CruelMan.Modules {
    public class SwimSpeed : Module {
        public override string Name => "Swim Speed";
        public override string Command => "swimspeed";
        public override string Description => "Sets the swim speed of the player";
        public override ModuleType Type => ModuleType.Movement;
        public float oldSpeed = 0f;

        protected override void Init() {
            AddSetting<SSpeed>();
        }

        protected override void OnEnable() {
            oldSpeed = Player.m_localPlayer.m_swimSpeed;
        }
        protected override void OnDisable() {
            Player.m_localPlayer.m_swimSpeed = oldSpeed;
        }
        protected override void OnUpdate() {
            Player.m_localPlayer.m_swimSpeed = GetSetting<SSpeed>().Value;
        }
    }

    public class SSpeed : NumberSetting {
        public override string Name => "Speed";
        public override string Description => "The speed to set the player to";
        public override float Min {get;set;} = 0;
        public override float Max {get;set;} = 100;
        public override float Value {get;set;} = 0;
    }
}
