using Exiled.API.Features;
using System.Collections.Generic;

namespace aboba
{
    public class Kills
    {
        public Dictionary<string, int> kills_count = new Dictionary<string, int>() { };

        public string max;

        public void Died(Exiled.Events.EventArgs.Player.DiedEventArgs ev)
        {
            if(ev.Attacker != null)
            {
                string nick = ev.Attacker.Nickname;
                if(kills_count.ContainsKey(nick))
                {
                    kills_count[nick]++;
                }
                else
                {
                    kills_count.Add(nick, 1);
                }
                max = nick;
            }
        }

        public void EndingRound(Exiled.Events.EventArgs.Server.EndingRoundEventArgs ev)
        {
            foreach (Player player in Player.List)
            {
                if (kills_count.ContainsKey(player.Nickname) && kills_count[max] < kills_count[player.Nickname])
                {
                    max = player.Nickname;
                }
            }
            foreach (Player player in Player.List)
            {
                player.Broadcast(10, $"Игрок {max} убил {kills_count[max]} игроков"); ;
            }
        }
    }
}
