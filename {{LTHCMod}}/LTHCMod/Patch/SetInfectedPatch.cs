using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Hazel;
using UnhollowerBaseLib;

namespace LTHCMod.Patch {
   [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.RpcSetInfected))]
    class SetInfectedPatch {

        public static void Postfix([HarmonyArgument(0)] Il2CppReferenceArray<GameData.PlayerInfo> infected) {
            List<PlayerControl> playersSelections = PlayerControl.AllPlayerControls.ToArray().ToList();
            List<PlayerControl> crewmateList = playersSelections.FindAll(x => !x.Data.IsImpostor).ToArray().ToList();
            if (playersSelections != null && playersSelections.Count > 0) {
                Random random = new Random();
                GlobalVariables.lthcPlayer = crewmateList[random.Next(0, crewmateList.Count)];
                byte playerId = GlobalVariables.lthcPlayer.PlayerId;
                MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.SetLTHC, SendOption.None, -1);
                messageWriter.Write(playerId);
                AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
            }        
        }
    }
}
