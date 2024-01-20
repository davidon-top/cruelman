namespace CruelMan.Modules {
    public class NotInAttack : Module {
        public override string Name { get; } = "NoAttackCooldown";
        public override string Command { get; } = "nodattack";
        public override string Description { get; } = "Always sets that your not in an attack";
        public override ModuleType Type { get; } = ModuleType.Combat;

        protected override void Init() {}
        protected override void OnDisable() {}
        protected override void OnEnable() {}
        protected override void OnUpdate() {}
    }
}
