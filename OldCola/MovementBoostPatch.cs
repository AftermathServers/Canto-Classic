using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using Scp207 = InventorySystem.Items.Usables.Scp207;

namespace OldCola;

[HarmonyPatch(typeof(Scp207), nameof(Scp207.OnEffectsActivated))]
public class MovementBoostPatch
{
    public static void Postfix(Scp207 __instance)
    {
        Log.Info("Postfix started");
        Player player = Player.Get(__instance.Owner);
        __instance.Owner.playerEffectsController.TryGetEffect<CustomPlayerEffects.Scp207>(
            out CustomPlayerEffects.Scp207 effect);
        int colaIntensity = effect.Intensity;
        if (Plugin.Instance.Config.SpeedIntensityPerCola.Count < 4)
        {
            Log.Info("Returning");
            return;
        }

        int intensity = Plugin.Instance.Config.SpeedIntensityPerCola[colaIntensity - 1];
        if (intensity < 0)
            player.EnableEffect(EffectType.Slowness, (byte)Math.Abs(intensity));
        else if (intensity > 0)
            player.EnableEffect(EffectType.MovementBoost, (byte)intensity);
        Log.Info("Postfix ended");
    }
}