using CommandSystem;
using System;

namespace aboba
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class list : ICommand
    {
        public string Command => "reportlist";

        public string[] Aliases => new string[] { "replist", "rlist" };

        public string Description => "Показывает все репорты, отправленные за этот раунд";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = string.Join("\n", Plugin.report.reports);
            return true;
        }
    }
}