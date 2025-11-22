using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsGlobal
    {

        public static clsUser CurrentUser;

        public static int EncryptionKey = 4;


        public static string EncryptText(string Text, int EncryptionKey)
        {
            string EncryptedText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                EncryptedText += Convert.ToChar((int)Text[i] + EncryptionKey);
            }

            return EncryptedText;
        }


        public static string DecryptText(string Text, int EncryptionKey)
        {
            string DecryptedText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                DecryptedText += Convert.ToChar((int)Text[i] - EncryptionKey);
            }

            return DecryptedText;
        }

    }
}
