using System;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace NameRandomizer
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("Among Us.exe")]
    [BepInProcess("Among Us2.exe")]
    [BepInProcess("Among Us3.exe")]
    [BepInProcess("Among Us4.exe")]
    public class HarmonyMain : BasePlugin
    {
        public const string GUID = "com.github.impostor5875.namerandomizer", NAME = "Name Randomizer", VERSION = "1.0.0";

        public Harmony Harmony { get; } = new Harmony(GUID);

        public static HarmonyMain Instance;

        public override void Load()
        {
            Harmony.PatchAll();

            SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, loadscenemode) =>
            {
                if (scene.name == "MainMenu") // main menu never existed it was fake
                    ModManager.Instance.ShowModStamp();
            }));
        }
    }
}
