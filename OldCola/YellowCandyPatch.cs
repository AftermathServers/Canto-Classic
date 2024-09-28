using System.Linq;
using HarmonyLib;
using InventorySystem.Items.Usables.Scp330;

namespace OldCola;

[HarmonyPatch(typeof(CandyYellow), nameof(CandyYellow.ServerApplyEffects))]
public class YellowCandyPatch
{
    public static bool Prefix(ReferenceHub hub)
    {
        hub.playerEffectsController.TryGetEffect(out CustomPlayerEffects.Scp207 scp207);
        if (!scp207) return true;
        return !scp207.IsEnabled;
    }
}