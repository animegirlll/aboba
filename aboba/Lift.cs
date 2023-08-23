using System;
using UnityEngine;
using Exiled.API.Features;

namespace aboba
{
    public class Lift
    {
        public void Granate(Exiled.Events.EventArgs.Map.ExplodingGrenadeEventArgs granate)
        {
            var lift = Exiled.API.Features.Lift.Get(granate.Position);
            if (lift != null)
            {
                int level = lift.CurrentLevel;
                if (level == 1)
                {
                    level = 0;
                }
                else
                {
                    level = 1;
                }
                if (UnityEngine.Random.Range(0, 101) <= Plugin.plugin.Config.lift_chance)
                {
                    lift.TryStart(level, true);
                }
            }
        }
    }
}