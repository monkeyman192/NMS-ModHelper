using NMS_ModHelper.Api;
using NMS_ModHelper.Api.Player;
using NMS_ModHelper.Extensions;

namespace PracticeMod
{
    [NMSModInfo("A cool practice mod", "1.0.2", "www.getLatestVersionHere.com")]
    public class MyMod : NMSMod
    {
        public override void OnKeyDown(KeyCode keyCode)
        {
            if (keyCode == KeyCode.UpArrow)
            {
                Player.main.Units.SetValue(Player.main.Units * 2);
            }
        }
    }
}