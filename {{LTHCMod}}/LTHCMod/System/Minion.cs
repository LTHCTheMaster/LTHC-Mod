using HarmonyLib;

namespace LTHCMod.Systems.Lighter
{

    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.CalculateLightRadius))]
    public class ShipStatusPatch
    {
        public static void Postfix(ref float __result, ShipStatus __instance, [HarmonyArgument(0)] GameData.PlayerInfo PlayerData)
        {
            if (GlobalVariables.lthcPlayer != null && Helper.lthcPlayer(PlayerData.PlayerId))
            {
                __result = __instance.MaxLightRadius * PlayerControl.GameOptions.CrewLightMod * 1.3f;
            }
        }
    }
}
