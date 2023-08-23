using Exiled.API.Features;
using System.Collections.Generic;

namespace aboba
{
    public class Report
    {
        public List<string> reports = new List<string>();

        public void SendReport(Exiled.Events.EventArgs.Player.LocalReportingEventArgs report)
        {
            string rep = $"Игрок [{report.Player.Id}] {report.Player.Nickname} отправил репорт на игрока [{report.Target.Id}] {report.Target.Nickname}. Причина: {report.Reason}";
            foreach (var player in Player.List)
            {
                if (player.RemoteAdminAccess)
                {
                    player.Broadcast(5, rep);
                }
            }
            reports.Add(rep);
        }
    }
}
