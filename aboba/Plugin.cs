using Exiled.API.Features;
using PlayerEvent = Exiled.Events.Handlers.Player;
using MapEvet = Exiled.Events.Handlers.Map;
using ServerEvent = Exiled.Events.Handlers.Server;

namespace aboba
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin = new Plugin();

        public static TeslaTrigger teslaTrigger = new TeslaTrigger();

        public static Report report = new Report();

        public static Lift lift = new Lift();

        public static Kills kills = new Kills();

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            PlayerEvent.TriggeringTesla += teslaTrigger.TeslaCheck;
            ServerEvent.LocalReporting += report.SendReport;
            MapEvet.ExplodingGrenade += lift.Granate;
            PlayerEvent.Died += kills.Died;
            ServerEvent.EndingRound += kills.EndingRound;
        }

        public void UnRegisterEvents()
        {
            PlayerEvent.TriggeringTesla -= teslaTrigger.TeslaCheck;
            ServerEvent.LocalReporting -= report.SendReport;
            MapEvet.ExplodingGrenade -= lift.Granate;
            PlayerEvent.Died -= kills.Died;
            ServerEvent.EndingRound -= kills.EndingRound;
        }
    }
}
