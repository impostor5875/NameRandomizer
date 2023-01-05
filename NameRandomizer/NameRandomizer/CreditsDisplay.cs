using HarmonyLib;
using UnityEngine;

namespace NameRandomizer
{
    [HarmonyPatch]
    public class CreditsDisplay //dill pickle made this stuff
    {
        [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
        public static class VersionShowerPatch
        {
            public static void Postfix(VersionShower __instance)
            {
                __instance.text.text += $"\n<#F6FF00>https://www.youtube.com/watch?v=l2jhTthCZuI but it's a real thing</color>"; 
                // HarmonyMain.Instance.Log.LogInfo("pos" + __instance.transform.position);
                __instance.transform.position = new Vector3(__instance.transform.position.x,
                                                            __instance.transform.position.y - 0.15f, __instance.transform.position.z);
            }
        }

        [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
        public static class PingPatch
        {
            public static void Postfix(PingTracker __instance)
            {
                __instance.text.text += $"\n<#F6FF00>{HarmonyMain.NAME}</color> v{HarmonyMain.VERSION}\n<#3AA3D9>github.com/impostor5875</color>";
            }
        }
    }
}