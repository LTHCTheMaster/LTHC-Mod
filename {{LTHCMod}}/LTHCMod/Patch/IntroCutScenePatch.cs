using HarmonyLib;
using UnityEngine;

namespace LTHCMod.Patch {

    [HarmonyPatch(typeof(IntroCutscene.CoBegin__d), nameof(IntroCutscene.CoBegin__d.MoveNext))]
    public static class IntroCutScenePatch {
        public static void Postfix(IntroCutscene.CoBegin__d __instance) {
            byte localPlayerId = PlayerControl.LocalPlayer.PlayerId;
            bool isImpostor = PlayerControl.LocalPlayer.Data.IsImpostor;

            // LTHC's minion
            if (Helper.lthcPlayer(localPlayerId)) {
                __instance.__this.Title.Text = "LTHC minion";
                __instance.__this.Title.scale /= 1.4f;
                __instance.__this.Title.Color = new Color(1f, 0.866f, 0f, 1f);
                __instance.__this.ImpostorText.Text = "When you died you kill another player";
                __instance.__this.BackgroundBar.material.color = new Color(1f, 0.866f, 0f, 1f);
            }
        }
    }
}
