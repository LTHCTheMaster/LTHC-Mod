using HarmonyLib;
using System;
using System.Diagnostics;
using UnityEngine;

namespace LTHCMod.Patch {

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetTasks))]
    class TasksPatch {
        public static void Postfix(PlayerControl __instance) {
            if (PlayerControl.LocalPlayer != null) {
                if (GlobalVariables.lthcPlayer != null && Helper.lthcPlayer(PlayerControl.LocalPlayer.PlayerId)) {
                    ImportantTextTask ImportantTasks = new GameObject("LTHCTasks").AddComponent<ImportantTextTask>();
                    ImportantTasks.transform.SetParent(__instance.transform, false);
                    ImportantTasks.Text = "[FFDD00FF]You are an LTHC's minion, \nYour death isn't alone.[]";
                    __instance.myTasks.Insert(0, ImportantTasks);
                }
            }
        }
    }
}
