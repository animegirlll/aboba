using Exiled.Events.EventArgs.Player;

namespace aboba
{
    public class TeslaTrigger
    {
        public void TeslaCheck(TriggeringTeslaEventArgs tesla)
        {
            bool has_item = false;
            foreach (ItemType item in Plugin.plugin.Config.items)
            {
                if (tesla.Player.CurrentItem != null && tesla.Player.CurrentItem.Type == item)
                {
                    has_item = true;
                }
            }
            tesla.DisableTesla = has_item;
        }
    }
}