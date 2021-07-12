using NMS_ModHelper.Api;
using NMS_ModHelper.Api.Player;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NMS_ModHelper
{
    public class NMSModHandler
    {
        public static List<NMSMod> NMSMods { get; set; } = new List<NMSMod>();
        static bool apiInitialized = false;

        public static void InitAPI()
        {
            if (apiInitialized)
                return;

            Logger.Log("Welcome to NMS Mod Helper! Beginning initialization...");
            LoadAllMods();
            MemoryManager.InitMemoryModding();
            Player.InitMainPlayer();

            apiInitialized = true;
        }

        private static void LoadAllMods()
        {
            var gameInfo = GameInfo.GetGameInfo();
            if (string.IsNullOrEmpty(gameInfo.ModsDirectory))
            {
                Logger.Log("Critical Error! Mods directory was not found!", LogLevel.Error);
                return;
            }

            Logger.Log("Searching for NMS mods...");
            List<NMSMod> allPossibleMods = GetDllMods(gameInfo.ModsDirectory);

            if (allPossibleMods.Count > 0)
            {
                Logger.Log("Mods found! Loading mods...");
                allPossibleMods.ForEach(mod => {
                    NMSMods.Add(mod);
                    mod.Start();
                });

                Logger.Log("Finished loading mods.");
            }
        }

        private static List<NMSMod> GetDllMods(string modsFolder)
        {
            List<NMSMod> dllMods = new List<NMSMod>();
            var allDlls = Directory.GetFiles(modsFolder, "*.dll").ToList();
            foreach (var dll in allDlls)
            {
                if (dll.Contains("Memory.dll") || dll.Contains("NMS ModHelper.dll"))
                    continue;

                var assembly = Assembly.LoadFrom(dll);
                
                foreach (var type in assembly.GetTypes())
                {
                    if (type.BaseType.Name == nameof(NMSMod))
                    {
                        var mod = (NMSMod)assembly.CreateInstance(type.FullName);
                        dllMods.Add(mod);
                    }
                }
            }

            return dllMods;
        }

        private static List<string> GetZipMods(string modsFolder)
        {
            return Directory.GetFiles(modsFolder, ".zip").ToList();
        }
    }
}
