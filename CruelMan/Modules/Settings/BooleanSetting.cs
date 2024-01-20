namespace CruelMan.Modules.Settings {
    public abstract class BooleanSetting : Setting {
        public bool Value = false;

        public void Toggle() {
            Value = !Value;
        }
    }
}
