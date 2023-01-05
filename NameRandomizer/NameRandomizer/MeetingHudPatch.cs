using HarmonyLib;

namespace NameRandomizer
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Awake))]
    class MeetingHudPatch
    {
        public static void Postfix(MeetingHud __instance)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                player.RpcSetName("");
        }
    }

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.OnDestroy))]
    class MeetingHudClosePatch
    {
        public static void Postfix(MeetingHud __instance)
        {
            foreach (string i in ShipStatusPatch.bruhWhyCantYouRemoveItemsFromArraysThatIsTheDumbestThingEver)
                ShipStatusPatch.nameList.Add(i);

            if (AmongUsClient.Instance.AmHost)
            {
                foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                {
                    ShipStatusPatch.funnyNumber = UnityEngine.Random.Range(0, ShipStatusPatch.nameList.Count);
                    player.RpcSetName(ShipStatusPatch.nameList[ShipStatusPatch.funnyNumber]);
                    ShipStatusPatch.nameList.RemoveAt(ShipStatusPatch.funnyNumber);
                }
                ShipStatusPatch.nameList.Clear();
            }
        }
    }
}
