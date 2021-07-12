using System.IO.Compression;

namespace NMS_ModHelper.Api.Utils
{
    public class Zipfile
    {
        #region Properties
        public string Location { get; set; }

        public ZipArchive Archive
        {
            get 
            {
                if (archive is null)
                    archive = Open();

                return archive; 
            }
            set { archive = value; }
        }
        private ZipArchive archive;
        #endregion


        #region Constructors
        public Zipfile(string filePath)
        {
            Location = filePath;
        }
        #endregion


        public ZipArchive Open(ZipArchiveMode archiveMode = ZipArchiveMode.Read)
        {
            Archive = ZipFile.Open(Location, archiveMode);
            return Archive;
        }
    }
}
