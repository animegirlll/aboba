using Exiled.API.Interfaces;

namespace aboba
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public ItemType[] items { get; set; } = new ItemType[] { ItemType.KeycardO5 };
        public int lift_chance { get; set; } = 50;
    }
}
