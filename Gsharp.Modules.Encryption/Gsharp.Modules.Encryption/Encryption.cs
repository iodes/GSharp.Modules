using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Windows.Forms;

namespace Gsharp.Modules.Encryption
{
    public class Encryption : GModule
    { // base64, md5, des
        public static string _base64_Encoding_str;
        public static string _base64_Decoding_str;
        public static string _md5_Encoding_str;
        public static string _des_Encoding_str;
        public static string _des_Decoding_str;
        

        [GCommand("Base64 Encoding 결과")]
        public static string _Base64_Encoding
        {
            get
            {
                return _base64_Encoding_str;
            }
        }
        [GCommand("Base64 Decoding 결과")]
        public static string _Base64_Decoding
        {
            get
            {
                return _base64_Decoding_str;
            }
        }
        [GCommand("MD5 Encoding 결과")]
        public static string _MD5_Encoding
        {
            get
            {
                return _md5_Encoding_str;
            }
        }
        [GCommand("DES Encoding 결과")]
        public static string _DES_Encoding
        {
            get
            {
                return _des_Encoding_str;
            }
        }
        [GCommand("DES Decoding 결과")]
        public static string _DES_Decoding
        {
            get
            {
                return _des_Decoding_str;
            }
        }


        [GCommand("Base64 Encoding({0})")]
        public static void Base64_Encoding(string text)
        {
            byte[] bt = Encoding.Unicode.GetBytes(text);
            string ret = Convert.ToBase64String(bt);
            _base64_Encoding_str = ret; 
        }
        [GCommand("Base64 Decoding({0})")]
        public static void Base64_Decoding(string text)
        {
            byte[] bt = Convert.FromBase64String(text);
            string ret = Encoding.Unicode.GetString(bt);
            _base64_Decoding_str = ret;
        }
        [GCommand("MD5 Encoding({0})")]
        public static void MD5_Encoding(string text)
        {
            byte[] bt = Convert.FromBase64String(text);
            MD5 md5_txt = new MD5CryptoServiceProvider();
            byte[] md5 = md5_txt.ComputeHash(bt);
            _md5_Encoding_str = Convert.ToBase64String(md5);
        }

        [GCommand("DES Encoding({0}) Key(Length<9) {1}")]
        public static void DES_Encoding(string text, string key)
        {
            byte[] bt_key;
            if (key.Length != 8 || key.Length == 0)
            {
                bt_key = ASCIIEncoding.ASCII.GetBytes("hubeenis");
                   
            }
            bt_key = ASCIIEncoding.ASCII.GetBytes(key);

            DESCryptoServiceProvider rc2 = new DESCryptoServiceProvider();

            rc2.Key = bt_key;
            rc2.IV = bt_key;

            MemoryStream ms = new MemoryStream();

            CryptoStream cryStream = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] data = Encoding.UTF8.GetBytes(text.ToCharArray());

            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            _des_Encoding_str = Convert.ToBase64String(ms.ToArray());
        }

        [GCommand("DES Decoding({0}) Key(Length<9) {1}")]
        public static void DES_Decoding(string text, string key)
        {
            byte[] bt_key;
            if (key.Length != 8 || key.Length == 0)
            {
                bt_key = ASCIIEncoding.ASCII.GetBytes("hubeenis");

            }
            bt_key = ASCIIEncoding.ASCII.GetBytes(key);

            DESCryptoServiceProvider rc2 = new DESCryptoServiceProvider();

            rc2.Key = bt_key;
            rc2.IV = bt_key;

            MemoryStream ms = new MemoryStream();
 
            CryptoStream cryStream = new CryptoStream(ms, rc2.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] data = Convert.FromBase64String(text);

            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            _des_Decoding_str = Encoding.UTF8.GetString(ms.GetBuffer());
        }
    
    }
}
