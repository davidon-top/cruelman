namespace CruelMan.Modules {
    public class NoDeath : Module {
        public override string Name { get; } = "NoDeath";
        public override string Command { get; } = "nodeath";
        public override string Description { get; } = "Prevents you from dying";
        public override ModuleType Type { get; } = ModuleType.Combat;

        protected override void Init() {}
        protected override void OnDisable() {}
        protected override void OnEnable() {}
        protected override void OnUpdate() {}
    }
}
