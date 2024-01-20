namespace CruelMan.Modules.Settings {
    public abstract class NumberSetting : Setting {
        public abstract float Value { get; set; }
        public abstract float Min {get; set; }
        public abstract float Max {get;set;}
    }
}
