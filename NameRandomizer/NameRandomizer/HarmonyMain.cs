using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace NameRandomizer
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("Among Us.exe")]
    public class HarmonyMain : BasePlugin
    {
        public const string GUID = "com.github.impostor5875.namerandomizer", NAME = "Name Randomizer", VERSION = "1.0.0";

        public Harmony Harmony { get; } = new Harmony(GUID);

        public static HarmonyMain Instance;

        public override void Load()
        {
            Harmony.PatchAll();
        }
    }
}
