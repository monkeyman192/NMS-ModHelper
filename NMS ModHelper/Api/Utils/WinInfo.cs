using Microsoft.Win32;

namespace NMS_ModHelper.Api.Utils
{
    public class WinInfo
    {
        public static bool IsProgramInstalled(string programDisplayName)
        {
            return GetRegistryKey(programDisplayName) != null;
        }

        public static RegistryKey GetRegistryKey(string programDisplayName)
        {
            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {
                var registeryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item);
                object programName = registeryKey.GetValue("DisplayName");

                if (string.Equals(programName, programDisplayName))
                {
                    return registeryKey;
                }
            }

            return null;
        }

        public static string GetInstallLocation(string programDisplayName)
        {
            var registryInfo = GetRegistryKey(programDisplayName);
            var value = registryInfo?.GetValue("InstallLocation");
            return value != null ? (string)value : null;
        }
    }
}
