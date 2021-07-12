namespace NMS_ModHelper.Console
{
    using System;
    using System.Threading;
    using NMS_ModHelper;
    using NMS_ModHelper.Api;
    using NMS_ModHelper.Api.Player;
    using NMS_ModHelper.Api.Utils;
    using NMS_ModHelper.Extensions;

    class Program
    {
        static void Main(string[] args)
        {
            InitAPI();

            var player = Player.main;

            Logger.Log(player.Name);
            Logger.Log(player.Units);
            Logger.Log(player.Nanites);
            Logger.Log(player.QuickSilver);

            Logger.Log(player.exosuitGeneralItems[0].TechType);
            Logger.Log(player.exosuitGeneralItems[0].StackSize);

            var gameInfo = GameInfo.GetGameInfo();

            Logger.Log(gameInfo.TryGetGameDir());
            Console.ReadLine();
        }

        static void InitAPI()
        {
            Logger.MessageLogged += LogMessage;

            NMSModHandler.InitAPI();

            Logger.Log("No Mans Sky API has finished initializing...");
        }

        private static void LogMessage(object sender, Logger.LogEvents e)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" [" + e.Sender + "] ");
            Console.ResetColor();
            Console.Write(e.Message + Environment.NewLine);
        }
    }
}
