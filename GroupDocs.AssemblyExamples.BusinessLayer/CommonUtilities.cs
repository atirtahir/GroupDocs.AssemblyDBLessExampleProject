using GroupDocs.Assembly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.AssemblyExamples.BusinessLayer
{
    public class CommonUtilities
    {

        public const string sourceFolderPath = "../../../../Data/SourceFolder/";
        public const string destinationFolderPath = "../../../../Data/DestinationFolder/";
        public const string licensePath = "../../GroupDocs.Assembly Product Family.lic";

        #region DocumentDirectories
        public static string DocumentSourceFolderPath(string fileName, string sourceFolder)
        {
            return Path.Combine(Path.GetFullPath(sourceFolderPath), sourceFolder, fileName);
        }

        public static string DocumentOutputFolderPath(string fileName, string destinationFolder)
        {
            return Path.Combine(Path.GetFullPath(destinationFolderPath), destinationFolder, fileName);
        }

        #endregion

        #region ProductLicense

        public static void ProductLicense()
        {
            License lic = new License();
            lic.SetLicense(licensePath);
        }

        #endregion

        #region ChangeFileName

        public static string ChangeFileName(string fileName)
        {
            string currentDateTime = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string alterFileName = nameWithoutExtension + "-" + currentDateTime + "-CS";
            string updatedFileName = alterFileName + extension;

            return updatedFileName;
        }

        #endregion
    }
}
