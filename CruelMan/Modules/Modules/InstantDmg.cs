using System.Reflection;
using CruelMan.Modules.Settings;
using UnityEngine;

namespace CruelMan.Modules {
    public class InstantDmg : Module {
        public override string Name { get; } = "InstantDmg"; 
        public override string Command { get; } = "instantdmg";
        public override string Description { get; } = "Instantly kills the target";
        public override ModuleType Type { get; } = ModuleType.Combat;

        protected override void Init() {
            AddSetting<InstantDmgDo>();
            AddSetting<Damage>();
            GetSetting<InstantDmgDo>().bind = KeyCode.Delete;
        }
        protected override void OnDisable() {}
        protected override void OnEnable() {}
        protected override void OnUpdate() {}
    }

    public class InstantDmgDo : ActionSetting {
        public override string Name { get; } = "InstantDmg";
        public override string Description { get; } = "Instantly kills the target";

        public override void Run(Module module) {
            HitData hd = new HitData();
            hd.m_damage.m_damage = module.GetSetting<Damage>().Value;
            hd.m_dodgeable = false;
            hd.m_blockable = false;
            hd.m_ignorePVP = true;
            hd.m_pushForce = 0;
            hd.m_point = Player.m_localPlayer.transform.position;
            hd.m_dir = Player.m_localPlayer.transform.forward;
            hd.m_hitType = HitData.HitType.PlayerHit;
            hd.SetAttacker(Player.m_localPlayer);

            FieldInfo fi = typeof(Player).GetField("m_hoveringCreature", BindingFlags.NonPublic | BindingFlags.Instance);
            Character target = (Character)fi.GetValue(Player.m_localPlayer);
            if (target == Player.m_localPlayer) {
                target = null;
            }
            if (target == null) {
                return;
            }
            target.Damage(hd);
        }
    }

    public class Damage : NumberSetting {
        public override string Name { get; } = "Damage";
        public override string Description { get; } = "The amount of damage to deal";
        public override float Min { get; set; } = 0;
        public override float Max { get; set; } = 1000;
        public override float Value { get; set; } = 0;
    }
}
