using System;

namespace NMS_ModHelper
{
    public class MemoryAddress<T>
    {
        private string address;

        public MemoryAddress(string address)
        {
            this.address = address;
        }

        // removed until I can figure out how to do it
        /*public static implicit operator MemoryAddress<T>(T value)
        {
            return new MemoryAddress<T>(value);
        }*/

        public static implicit operator T(MemoryAddress<T> memoryAddress)
        {
            return (T)Convert.ChangeType(memoryAddress.GetValue(), typeof(T));
        }


        public T GetValue()
        {
            return MemoryManager.Read<T>(address);
        }

        public bool SetValue(T value)
        {
            return MemoryManager.Write(address, value);
        }
    }
}
