using Memory;
using System;
using System.Diagnostics;

namespace NMS_ModHelper
{
    public class MemoryManager
    {
        private static MemoryManager instance;
        public static Mem memLib = new Mem();
        private static bool initialized = false;

        public MemoryManager()
        {
            
        }

        internal static void InitMemoryModding()
        {
            if (initialized)
                return;

            if (memLib.OpenProcess("NMS.exe"))
            {
                initialized = true;
                instance = new MemoryManager();
            }
        }

        public static bool Write<T>(string code, T valueToWrite)
        {
            string typeToWrite = typeof(T).Name.ToLower().Replace("16", "").Replace("32", "").Replace("64", "");
            return memLib.WriteMemory(code, typeToWrite, valueToWrite.ToString());
        }

        public static T Read<T> (string code)
        {
            object value = null;

            if (typeof(T) == typeof(int))
            {
                value = memLib.ReadInt(code);
            }
            else if (typeof(T) == typeof(float))
            {
                value = memLib.ReadFloat(code);
            }
            else if (typeof(T) == typeof(double))
            {
                value = memLib.ReadDouble(code);
            }
            else if (typeof(T) == typeof(string))
            {
                value = memLib.ReadString(code);
            }
            else if (typeof(T) == typeof(byte))
            {
                value = memLib.ReadByte(code);
            }
            else if (typeof(T) == typeof(long))
            {
                value = memLib.ReadLong(code);
            }
            else if (typeof(T) == typeof(uint) || typeof(T) == typeof(UInt16) || typeof(T) == typeof(UInt32) || typeof(T) == typeof(UInt64))
            {
                value = memLib.ReadUInt(code);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
