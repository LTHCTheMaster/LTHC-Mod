using LTHCMod.Utils;
using System.Collections.Generic;
using HarmonyLib;
using Hazel;

namespace LTHCMod.System
{
    class Kill
    {
        public static bool isDead = false;

        public static void Update()
        {
            if (!isDead && PlayerControl.LocalPlayer.Data.IsDead)
            {
                isDead = true;
                PlayerButton.InitPlayerButton((PlayerControl) => {
                    PlayerControl.MurderPlayer(PlayerControl);
                    MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.LTHCKill, SendOption.None, -1);
                    messageWriter.Write(PlayerControl.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                }, false, new List<PlayerControl>());
            }
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    class PlayerUpdatePatch
    {
        public static void Postfix(PlayerControl __instance)
        {
            if (Helper.lthcPlayer(__instance.PlayerId))
            Kill.Update();
        }
    }
}
