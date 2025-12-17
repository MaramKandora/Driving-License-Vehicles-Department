using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsEncryptDecrypt
    {

     


       private const int _EncryptionKey = 4;
        
        public static string EncryptText(string Text)
        {
            string EncryptedText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                EncryptedText += Convert.ToChar((int)Text[i] + _EncryptionKey);
            }

            return EncryptedText;
        }


        public static string DecryptText(string Text)
        {
            string DecryptedText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                DecryptedText += Convert.ToChar((int)Text[i] - _EncryptionKey);
            }

            return DecryptedText;
        }

    }
}
