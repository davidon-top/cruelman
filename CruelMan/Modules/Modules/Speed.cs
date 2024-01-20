using CruelMan.Modules.Settings;

namespace CruelMan.Modules {
    public class Speed : Module {
        public override string Name { get; } = "Speed";
        public override string Command { get; } = "speed";
        public override string Description { get; } = "Fast as fuck boiii";
        public override ModuleType Type { get; } = ModuleType.Movement;
        public float oldSpeed = 0f;

        protected override void Init() {
            AddSetting<SpeedVal>();
        }
        protected override void OnEnable() {
            oldSpeed = Player.m_localPlayer.m_runSpeed;
        }
        protected override void OnDisable() {
            Player.m_localPlayer.m_runSpeed = oldSpeed;
        }
        protected override void OnUpdate() {
            Player.m_localPlayer.m_runSpeed = GetSetting<SpeedVal>().Value;
        }
    }

    public class SpeedVal : NumberSetting
    {
        public override string Name => "Value";
        public override string Description => "Run Speed value";

        public override float Value { get; set; } = 20f;
        public override float Min { get; set; } = 0f;
        public override float Max { get; set; } = 500f;
    }
}
