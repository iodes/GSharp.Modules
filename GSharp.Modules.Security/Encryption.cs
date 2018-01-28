using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GSharp.Modules.Security
{
    public class Encryption : GModule
    {
        [GCommand("{0} BASE64 인코딩")]
        public static string Base64_Encoding(string text)
        {
            byte[] bt = Encoding.Unicode.GetBytes(text);
            return Convert.ToBase64String(bt);
        }

        [GCommand("{0} BASE64 디코딩")]
        public static string Base64_Decoding(string text)
        {
            byte[] bt = Convert.FromBase64String(text);
            return Encoding.Unicode.GetString(bt);
        }

        [GCommand("{0} MD5 인코딩")]
        public static string MD5_Encoding(string text)
        {
            byte[] bt = Convert.FromBase64String(text);
            MD5 md5_txt = new MD5CryptoServiceProvider();
            byte[] md5 = md5_txt.ComputeHash(bt);
            return Convert.ToBase64String(md5);
        }

        [GCommand("{0} DES 인코딩 ({1} KEY (Length < 9))")]
        public static string DES_Encoding(string text, string key)
        {
            byte[] bt_key;
            if (key.Length != 8 || key.Length == 0)
            {
                bt_key = Encoding.ASCII.GetBytes("hubeenis");

            }
            bt_key = Encoding.ASCII.GetBytes(key);

            DESCryptoServiceProvider rc2 = new DESCryptoServiceProvider();

            rc2.Key = bt_key;
            rc2.IV = bt_key;

            MemoryStream ms = new MemoryStream();

            CryptoStream cryStream = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] data = Encoding.UTF8.GetBytes(text.ToCharArray());

            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        [GCommand("{0} DES 디코딩 ({1} KEY (Length < 9))")]
        public static string DES_Decoding(string text, string key)
        {
            byte[] bt_key;
            if (key.Length != 8 || key.Length == 0)
            {
                bt_key = Encoding.ASCII.GetBytes("hubeenis");

            }
            bt_key = Encoding.ASCII.GetBytes(key);

            DESCryptoServiceProvider rc2 = new DESCryptoServiceProvider();

            rc2.Key = bt_key;
            rc2.IV = bt_key;

            MemoryStream ms = new MemoryStream();

            CryptoStream cryStream = new CryptoStream(ms, rc2.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] data = Convert.FromBase64String(text);

            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.GetBuffer());
        }
    }
}
