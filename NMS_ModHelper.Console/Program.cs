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

            Console.WriteLine(player.Name);
            Console.WriteLine(player.Units);
            Console.WriteLine(player.Nanites);
            Console.WriteLine(player.QuickSilver);

            Console.WriteLine(player.exosuitGeneralItems[0].TechType);
            Console.WriteLine(player.exosuitGeneralItems[0].StackSize);

            var gameInfo = GameInfo.GetGameInfo();
            Console.WriteLine(gameInfo.TryGetGameDir());
            Console.ReadLine();
        }

        static void InitAPI()
        {
            Logger.MessageLogged += LogMessage;

            NMS_ModHelper.Main.InitAPI();

            Logger.Log("No Mans Sky API has finished initializing...");
        }

        private static void LogMessage(object sender, Logger.LogEvents e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
