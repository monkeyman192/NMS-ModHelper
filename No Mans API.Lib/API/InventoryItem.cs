namespace No_Mans_API.API
{
    public class InventoryItem
    {
        private string baseAddress;
        public MemoryAddress<string> TechType { get; set; }
        public MemoryAddress<int> StackSize { get; set; }
        public MemoryAddress<int> MaxStackSize { get; set; }

        public InventoryItem(string baseAddress)
        {
            this.baseAddress = baseAddress;
            TechType = new MemoryAddress<string>(baseAddress + ",0x8");
            StackSize = new MemoryAddress<int>(baseAddress + ",0x18"); // was 0x19
            MaxStackSize = new MemoryAddress<int>(baseAddress + ",0x1A");
        }
    }
}