using System;
using System.Linq;
using Exiled.API.Features;
using HarmonyLib;

namespace OldCola
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Canto-Classic";

        public override string Author => "6hundred9";

        public override string Prefix => "coke";

        public override Version RequiredExiledVersion => new(8, 11, 0);

        public override bool IgnoreRequiredVersionCheck => true;

        public static Plugin Instance;

        private readonly Harmony _harmony = new("com.Aftermath.OldCola");

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            _harmony.PatchAll();
            Exiled.Events.Handlers.Player.Hurting += EventHandlers.Hurting;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Instance = null;
            _harmony.UnpatchAll();
            Exiled.Events.Handlers.Player.Hurting -= EventHandlers.Hurting;
        }
    }
}