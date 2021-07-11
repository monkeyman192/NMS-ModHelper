using Microsoft.Win32;
using NMS_ModHelper.Api.Utils;
using System;

namespace NMS_ModHelper.Api
{
    public class GameInfo
    {
        #region Properties
        public string GameDirectory { get; private set; }
        public string ModsDirectory { get; private set; }
        
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
