namespace CruelMan.Modules.Settings {
    public abstract class Setting {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public Setting() {}
    }
}
