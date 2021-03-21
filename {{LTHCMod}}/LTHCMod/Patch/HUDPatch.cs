using HarmonyLib;
using UnityEngine;

namespace LTHCMod.Patch {

    public static class HudPatch {
        public static void UpdateMeetingHUD(MeetingHud __instance) {
            foreach (PlayerVoteArea player in __instance.playerStates) {
                if (player.NameText.Text == GlobalVariables.lthcPlayer.name && Helper.lthcPlayer(PlayerControl.LocalPlayer.PlayerId))
                    player.NameText.Color = new Color(1f, 0.866f, 0f, 1f);
            }
        }
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HudUpdatePatch {
        public static void Postfix(HudManager __instance) {
            if (MeetingHud.Instance != null)
                HudPatch.UpdateMeetingHUD(MeetingHud.Instance);

            if (PlayerControl.LocalPlayer != null) {
                if (GlobalVariables.lthcPlayer != null && Helper.lthcPlayer(PlayerControl.LocalPlayer.PlayerId))
                    PlayerControl.LocalPlayer.nameText.Color = new Color(1f, 0.866f, 0f, 1f);
            }
        }
    }
}