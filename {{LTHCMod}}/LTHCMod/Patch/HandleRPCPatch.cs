using HarmonyLib;
using Hazel;
using LTHCMod.Utils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LTHCMod.Patch {
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.HandleRpc))]
    class HandleRpcPatch {

        public static bool Prefix([HarmonyArgument(0)] byte callId, [HarmonyArgument(1)] MessageReader reader) {

            if (callId == (byte) CustomRPC.SetLTHC) {
                GlobalVariables.lthcPlayer = null;
                byte readByte = reader.ReadByte();
                GlobalVariables.lthcPlayer = PlayerControlUtils.FromPlayerId(readByte);

                return false;
            }
            if (callId == (byte)CustomRPC.LTHCKill)
            {
                PlayerControl playerTargeted = PlayerControlUtils.FromPlayerId(reader.ReadByte());
                playerTargeted.MurderPlayer(playerTargeted);

                return false;
            }

            return true;
        }
    }
}
