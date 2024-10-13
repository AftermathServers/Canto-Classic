using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Usables.Scp330;
using UnityEngine;

namespace OldCola;

public class EventHandlers
{
    public static void Hurting(HurtingEventArgs ev)
    {
        if (ev.DamageHandler.CustomBase.Type == DamageType.Scp207)
        {
            ev.Amount *= Plugin.Instance.Config.ColaDamageMultiplier;
        }
    }

    public static void UsingItemCompleted(UsingItemCompletedEventArgs ev)
    {
        if (ev.Item.Type == ItemType.SCP500) ev.Player.DisableEffect(EffectType.MovementBoost);
    }
}