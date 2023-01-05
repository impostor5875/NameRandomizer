using System.Collections.Generic;
using HarmonyLib;

namespace NameRandomizer
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
    class ShipStatusPatch
    {
        public static int funnyNumber = 0;
        public static string[] bruhWhyCantYouRemoveItemsFromArraysThatIsTheDumbestThingEver = { "Who", "That", "Where", "What", "Sus", "Going2KillEveryoneStartingWithU", "I Don't Know", "Why", "When", "You", "You're", "I", "Everyone", "Lame", "Afk", "Skip Vote", "Nobody", "Somebody", "They" };
        public static List<string> nameList = new List<string>();
        public static void Postfix(ShipStatus __instance)
        {
            foreach (string i in bruhWhyCantYouRemoveItemsFromArraysThatIsTheDumbestThingEver)
                nameList.Add(i);

            if (AmongUsClient.Instance.AmHost)
            {
                foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                {
                    funnyNumber = UnityEngine.Random.Range(0, nameList.Count);
                    player.RpcSetName(nameList[funnyNumber]);
                    nameList.RemoveAt(funnyNumber);
                }
                nameList.Clear();
            }
        }
    }
}
