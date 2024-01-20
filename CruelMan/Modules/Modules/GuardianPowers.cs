using System.Reflection;
using CruelMan.Modules.Settings;

namespace CruelMan.Modules {
    public class GuardianPowers : Module {
        public override string Name => "Guardian Powers";
        public override string Command => "guardian";
        public override string Description => "Enable guardian power";
        public override ModuleType Type => ModuleType.Misc;

        protected override void Init() {
            AddSetting<NoCooldown>();
            AddSetting<Activate>();
            AddSetting<SetEikthyr>();
            AddSetting<SetTheElder>();
            AddSetting<SetBonemass>();
            AddSetting<SetModer>();
            AddSetting<SetYagluth>();
            AddSetting<SetQueen>();
            AddSetting<SetAshlands>();
            AddSetting<SetDeepNorth>();
        }
        protected override void OnDisable() {}
        protected override void OnEnable() {}
        protected override void OnUpdate() {
            if (GetSetting<NoCooldown>().Value) {
                Player.m_localPlayer.m_guardianPowerCooldown = 0f;
            }
        }
        public void SetGP(string name) {
            FieldInfo fi = typeof(Player).GetField("m_guardianPower", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(Player.m_localPlayer, name);

            int hash = ((!string.IsNullOrEmpty(name)) ? StringExtensionMethods.GetStableHashCode(name) : 0);
            FieldInfo fi2 = typeof(Player).GetField("m_guardianPowerHash", BindingFlags.NonPublic | BindingFlags.Instance);
            fi2.SetValue(Player.m_localPlayer, hash);

            FieldInfo fi3 = typeof(Player).GetField("m_guardianSE", BindingFlags.NonPublic | BindingFlags.Instance);
            fi3.SetValue(Player.m_localPlayer, ObjectDB.instance.GetStatusEffect(hash));
        }
    }

    public class NoCooldown : BooleanSetting {
        public override string Name => "No Cooldown";
        public override string Description => "Enable no cooldown";
    }

    public class Activate : ActionSetting {
        public override string Name => "Activate";
        public override string Description => "Activate guardian power";

        public override void Run(Module module) {
            Player.m_localPlayer.ActivateGuardianPower();
        }
    }

    public class SetEikthyr : ActionSetting {
        public override string Name => "Set Eikthyr";
        public override string Description => "Set guardian power to Eikthyr";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_Eikthyr");
        }
    }

    public class SetTheElder : ActionSetting {
        public override string Name => "Set The Elder";
        public override string Description => "Set guardian power to The Elder";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_TheElder");
        }
    }

    public class SetBonemass : ActionSetting {
        public override string Name => "Set Bonemass";
        public override string Description => "Set guardian power to Bonemass";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_Bonemass");
        }
    }

    public class SetModer : ActionSetting {
        public override string Name => "Set Moder";
        public override string Description => "Set guardian power to Moder";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_Moder");
        }
    }

    public class SetYagluth : ActionSetting {
        public override string Name => "Set Yagluth";
        public override string Description => "Set guardian power to Yagluth";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_Yagluth");
        }
    }

    public class SetQueen : ActionSetting {
        public override string Name => "Set Queen";
        public override string Description => "Set guardian power to Queen";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_Queen");
        }
    }

    public class SetAshlands : ActionSetting {
        public override string Name => "Set Ashlands";
        public override string Description => "Set guardian power to Ashlands";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_Ashlands");
        }
    }

    public class SetDeepNorth : ActionSetting {
        public override string Name => "Set Deep North";
        public override string Description => "Set guardian power to Deep North";

        public override void Run(Module module) {
            ((GuardianPowers)module).SetGP("GP_DeepNorth");
        }
    }

}
