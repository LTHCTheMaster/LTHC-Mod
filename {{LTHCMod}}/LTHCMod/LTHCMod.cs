using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;

namespace LTHCMod
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class LTHCMod : BasePlugin
    {
        public const string Id = "fr.lthc.lthcmod";

        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load()
        {
            

            Harmony.PatchAll();
        }
    }
}
