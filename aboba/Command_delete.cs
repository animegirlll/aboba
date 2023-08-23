using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using System;
using UnityEngine;

namespace aboba
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class clear : ICommand
    {
        public string Command => "delete";

        public string[] Aliases => new string[] { "del" };

        public string Description => "Удаляет трупы в указанном радиусе";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (float.TryParse(string.Join("", arguments), out float dis))
            {
                Vector3 position = Player.Get(sender).Position;
                int rc = 0;
                int pc = 0;
                foreach (var doll in Ragdoll.List)
                {
                    if (Vector3.Distance(doll.Position, position) <= dis)
                    {
                        doll.Destroy();
                        rc++;
                    }
                }
                foreach (var item in Pickup.List)
                {
                    if (Vector3.Distance(item.Position, position) <= dis)
                    {
                        item.Destroy();
                        pc++;
                    }
                }
                response = $"Удалено {rc} трупов и {pc} предметов в {dis} радиусе";
                return true;
            }
            else
            {
                response = "delete [радиус]";
                return false;
            }
        }
    }
}
