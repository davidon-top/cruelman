namespace CruelMan.Modules {
    public class InfCarry : Module {
        public override string Name => "InfCarry";
        public override string Command => "infcarry";
        public override string Description => "Allows you to carry infinite weight";
        public override ModuleType Type => ModuleType.Movement;

        protected override void Init() {}
        protected override void OnDisable() {}
        protected override void OnEnable() {}
        protected override void OnUpdate() {
            Player.m_localPlayer.m_maxCarryWeight = 1000000;
        }
    }
}
