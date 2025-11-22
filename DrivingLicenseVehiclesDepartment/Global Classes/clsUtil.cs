using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PresentationLayer.Global_Classes
{
    public class clsUtil
    {

        public static string GenerateNewGuid()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }

        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            FileInfo FileInfo1= new FileInfo(SourceFile);        
            string Extension= FileInfo1.Extension;

            return GenerateNewGuid() + Extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationImagesFolder = @"C:\DVLD-People-Images\";

            if (!CreateFolderIfDoesNotExist(DestinationImagesFolder))
            {
                return false;
            }


            string DestinationFile = DestinationImagesFolder + ReplaceFileNameWithGuid(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
               
            }
            catch(IOException io)
            {
                MessageBox.Show(io.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                return false;
            }

            SourceFile = DestinationFile;
            return true;

        }


        public static bool CreateFolderIfDoesNotExist(string FolderName)
        {
            if(!File.Exists(FolderName))
            {
                try
                {

                    Directory.CreateDirectory(FolderName);
                    return true;

                }
                catch(IOException)
                {
                    MessageBox.Show("Error In Creating Folder");
                    return false;
                }
            }

            return true;
        }
       

    }
}
