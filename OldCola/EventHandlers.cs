using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
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
}