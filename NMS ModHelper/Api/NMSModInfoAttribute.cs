namespace NMS_ModHelper.Api
{
    public class NMSModInfoAttribute : System.Attribute
    {
        public string ModName { get; private set; }
        public string VersionUrl { get; private set; }
        public string Version { get; private set; }


        public NMSModInfoAttribute(string name)
        {
            ModName = name;
            Version = "1.0.0.0";
        }

        public NMSModInfoAttribute(string name, string version)
        {
            ModName = name;
            Version = version;
        }

        public NMSModInfoAttribute(string name, string version, string versionUrl)
        {
            ModName = name;
            Version = version;
            VersionUrl = versionUrl;
        }
    }
}
