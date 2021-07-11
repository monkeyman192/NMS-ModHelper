using System.Collections.Generic;

namespace No_Mans_API.API.Player
{
    public class Player
    {
        public static Player main;

        const string baseAddress = "NMS.exe+032E7CF0,0x80";

        public MemoryAddress<string> Name { get; set; } = new MemoryAddress<string>(baseAddress + ",0x0");
        public MemoryAddress<int> Units { get; set; } = new MemoryAddress<int>(baseAddress + ",0x1BC");
        public MemoryAddress<int> Nanites { get; set; } = new MemoryAddress<int>(baseAddress + ",0x1C0");
        public MemoryAddress<int> QuickSilver { get; set; } = new MemoryAddress<int>(baseAddress + ",0x1C4");

        public List<InventoryItem> exosuitGeneralItems;

        // older attempt. Will remove once I'm confident I don't need the addresses
        /*public MemoryAddress<int> Units { get; set; } = new MemoryAddress<int>("NMS.exe+032F7548,0x60,0x8FC");
        public MemoryAddress<int> Nanites { get; set; } = new MemoryAddress<int>("NMS.exe+032F7548,0x60,0x900");
        public MemoryAddress<int> QuickSilver { get; set; } = new MemoryAddress<int>("NMS.exe+032F7548,0x60,0x904");*/

        public Player()
        {
            if (main == null)
                main = this;

            exosuitGeneralItems = GetInventory();
        }

        private List<InventoryItem> GetInventory()
        {
            List<InventoryItem> items = new List<InventoryItem>();
            int totalItems = MemoryManager.Read<int>(baseAddress + ",2CC");
            for (int i = 0; i < totalItems; i++)
            {
                InventoryItem item = new InventoryItem(baseAddress + ",2D0");
                items.Add(item);
                break;
            }

            return items;
        }
    }
}
