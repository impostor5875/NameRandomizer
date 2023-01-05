using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace NameRandomizer
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
    class ShipStatusPatch
    {
        public static void Postfix(ShipStatus __instance)
        {
            if (AmongUsClient.Instance.AmHost)
                PlayerControl.LocalPlayer.RpcSetName("Going2KillEveryoneStartingWithU");
        }
    }
}
