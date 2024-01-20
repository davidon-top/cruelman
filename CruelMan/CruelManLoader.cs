using BepInEx;
using CruelMan.Modules;
using CruelMan.Utils;
using HarmonyLib;

namespace CruelMan {

    [BepInPlugin("top.davidon.valheim.cruelman", "CruelMan", "1.0.0")]
    public class CMLoader : BaseUnityPlugin {
        public readonly Harmony harmony = new Harmony("top.davidon.valheim.cruelman");

        public void Awake() {
            Log.Info("Awake CruelMan");
            harmony.PatchAll();
            UnityEngine.Object.DontDestroyOnLoad(this);

            CM.Init(this);
        }

        [HarmonyPatch(typeof(Player), "OnDeath")]
        class DeathPatch {
            static bool Prefix() {
                return !ModuleManager.instance.GetModule<NoDeath>().Enabled;
            }
        }

        [HarmonyPatch(typeof(Player), nameof(Player.InAttack))]
        class AttackPathh {
            static bool Prefix() {
                return !ModuleManager.instance.GetModule<NotInAttack>().Enabled;
            }
            static void Postfix(ref bool __result) {
                if (ModuleManager.instance.GetModule<NotInAttack>().Enabled) {
                    __result = false;
                }
            }
        }
    }
}
