using CruelMan.Modules.Settings;
using UnityEngine;

namespace CruelMan.Modules {
    public class JumpHeight : Module {
        public override string Name { get; } = "JumpHeight";
        public override string Command { get; } = "jumpheight";
        public override string Description { get; } = "Changes your jump height";
        public override ModuleType Type { get; } = ModuleType.Movement;
        public float oldJumpHeight = 0f;

        protected override void Init() {
            AddSetting<JumpHeightVal>();
        }
        protected override void OnEnable() {
            oldJumpHeight = Player.m_localPlayer.m_jumpForce;
        }
        protected override void OnDisable() {
            Player.m_localPlayer.m_jumpForce = oldJumpHeight;
        }
        protected override void OnUpdate() {
            if (Input.GetKey(KeyCode.LeftShift)) {
                Player.m_localPlayer.m_jumpForce = GetSetting<JumpHeightVal>().Value;
            } else {
                Player.m_localPlayer.m_jumpForce = oldJumpHeight;
            }
        }
    }

    public class JumpHeightVal : NumberSetting {
        public override string Name => "Value";
        public override string Description => "Jump Height value";

        public override float Value { get; set; } = 10f;
        public override float Min { get; set; } = 0f;
        public override float Max { get; set; } = 100f;
    }
}
