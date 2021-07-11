namespace No_Mans_API.Console
{
    using System;
    using No_Mans_API;
    using No_Mans_API.API;
    using No_Mans_API.API.Player;
    using No_Mans_API.Extensions;

    class Program
    {
        static void Main(string[] args)
        {
            InitAPI();

            Console.WriteLine(100m.ToHexCode());
            var player = new Player();

            Console.WriteLine(player.Name);
            Console.WriteLine(player.Units);
            Console.WriteLine(player.Nanites);
            Console.WriteLine(player.QuickSilver);


            Console.WriteLine(player.exosuitGeneralItems[0].TechType);
            Console.WriteLine(player.exosuitGeneralItems[0].StackSize);

            

            //player.Units.SetValue(100);

            /*Console.WriteLine(units);
            player.Units.SetValue(669699);
            Console.WriteLine(player.Units.GetValue());
            Thread.Sleep(3500);

            player.Units.SetValue(units);
            Console.WriteLine(player.Units.GetValue());*/
        }

        static void InitAPI()
        {
            Logger.MessageLogged += LogMessage;

            MemoryManager.InitMemoryModding();

            Logger.Log("No Mans Sky API has finished initializing...");
        }

        private static void LogMessage(object sender, Logger.LogEvents e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
