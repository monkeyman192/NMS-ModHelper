using Microsoft.Win32;
using NMS_ModHelper.Api.Utils;
using System;

namespace NMS_ModHelper.Api
{
    public class GameInfo
    {
        #region Properties

        public string GameDirectory
        {
            get 
            {
                if (string.IsNullOrEmpty(gameDirectory))
                    gameDirectory = TryGetGameDir();

                return gameDirectory;
            }
            private set { gameDirectory = value; }
        }
        private string gameDirectory;

        public string ModsDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(gameDirectory))
                    gameDirectory = TryGetModsDir();

                return gameDirectory;
            }
            private set { ModsDirectory = value; }
        }
        private string modsDirectory;

        public string GameVersion
        {
            get 
            {
                if (string.IsNullOrEmpty(gameVersion))
                {

                }
                return gameVersion;}
        }
        private string gameVersion;

        #endregion

        #region Constructors
        public GameInfo()
        {

        }
        #endregion


        public string TryGetGameDir()
        {
            if (IsGameInstalled())
            {
                string installDir = WinInfo.GetInstallLocation("No Man's Sky");
                return installDir;
            }

            return null;
        }

        public string TryGetModsDir()
        {
            if (string.IsNullOrEmpty(GameDirectory))
                return null;

            return GameDirectory + "\\GAMEDATA\\PCBANKS\\MODS";
        }

        public bool IsGameInstalled()
        {
            return WinInfo.IsProgramInstalled("No Man's Sky");
        }

        public static GameInfo GetGameInfo()
        {
            var gameInfo = new GameInfo();
            return gameInfo;
        }
    }
}
