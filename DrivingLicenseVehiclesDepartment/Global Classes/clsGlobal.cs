using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using Microsoft.Win32;
using Shared;


namespace DVLD_PresentationLayer.Global_Classes
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

       

        public static void RememberUserCredentials(clsUser User)
        {
            if (User == null)
                return;

            try
            {
                Registry.SetValue(KeyPath, "UserName", User.UserName, RegistryValueKind.String);
                Registry.SetValue(KeyPath, "Password", clsEncryptDecrypt.EncryptText(User.Password));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               clsLogger.LogError(ex);
            }

  

        }

        public static void ClearRememberMeCredentials()
        {
           
            try
            {
                using (RegistryKey BaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {

                    string SubkeyPath = @"SOFTWARE\DVLD";
                    using (RegistryKey SubKey = BaseKey.OpenSubKey(SubkeyPath,true))
                    {
                        if (SubKey != null)
                        {
                            SubKey.DeleteValue("UserName");
                            SubKey.DeleteValue("Password");
                        }
                        else
                        {
                            MessageBox.Show($"Registry Key {KeyPath} Is not found");
                        }
                    }
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"\"UnauthorizedAccessException: Run the program with administrative privileges.\"");

                if (!EventLog.SourceExists("DVLD"))
                {
                    EventLog.CreateEventSource("DVLD", "Application");
                }

                EventLog.WriteEntry("DVLD", ex.Message, EventLogEntryType.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");

               clsLogger.LogError(ex);


            }
        }

        public static bool LoadStoredCredentials(ref string UserName,ref string Password)
        {
            bool isFound = false;
            try
            {
                object Value = Registry.GetValue(KeyPath, "UserName", "");
                if (Value != null)
                {
                    UserName = Value.ToString();
                }

                Value = Registry.GetValue(KeyPath, "Password", "");
                if (Value != null)
                {
                    Password = clsEncryptDecrypt.DecryptText(Value.ToString()) ;    
                }

                isFound = true;
               

            }
            catch (IOException ex)
            {

                MessageBox.Show(ex.Message);

               clsLogger.LogError(ex);


            }
            return isFound; 
        }
    }
}
