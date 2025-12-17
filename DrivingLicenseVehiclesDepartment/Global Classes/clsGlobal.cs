using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_PresentationLayer.Global_Classes
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;

        static string DirectoryPath = Directory.GetCurrentDirectory();
        public static string CredentialsFilePath = DirectoryPath + "\\data.txt";


        public static void RememberUserCredentials(clsUser User)
        {
            if (User == null)
                return;

            string UserText = User.UserName + "#//#" + clsEncryptDecrypt.EncryptText(User.Password);

            try
            {
                
                File.WriteAllText(CredentialsFilePath, UserText);


            }
            catch (IOException EX)
            {
                MessageBox.Show(EX.Message);
            }


        }

        public static void ClearRememberMeFile()
        {
            File.Delete(CredentialsFilePath);   
        }
        public static bool LoadStoredCredentials(ref string UserName,ref string Password)
        {
            bool isFound = false;
            try
            {
                if (File.Exists(CredentialsFilePath))
                {
                    string UserText = File.ReadAllText(CredentialsFilePath);
                    if (UserText != "")
                    {
                        string[] UserCredentials = UserText.Split(new string[] { "#//#" }, StringSplitOptions.None);

                        UserName = UserCredentials[0];
                        Password = clsEncryptDecrypt.DecryptText(UserCredentials[1]);

                        isFound = true;
                    }
                   
                }

            }
            catch (IOException ex)
            {

                MessageBox.Show(ex.Message);

            }
            return isFound; 
        }
    }
}
