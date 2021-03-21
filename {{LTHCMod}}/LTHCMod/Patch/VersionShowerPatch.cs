using HarmonyLib;

namespace LTHCMod.Patch {

    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionShowerPatch {
        public static void Postfix(VersionShower __instance) {
            Reactor.Patches.ReactorVersionShower.Text.Text += "\n[FFDD00FF]LTHC Mod[] by LTHC & Hardel";
        }
    }
}
