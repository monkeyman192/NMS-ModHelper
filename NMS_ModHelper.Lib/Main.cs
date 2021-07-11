using NMS_ModHelper.Api.Player;

namespace NMS_ModHelper
{
    public class Main
    {
        static bool apiInitialized = false;

        public static void InitAPI()
        {
            if (apiInitialized)
                return;

            MemoryManager.InitMemoryModding();
            Player.InitMainPlayer();
            apiInitialized = true;
        }
    }
}
