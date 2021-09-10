using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NetricsERP.Models
{
    public enum CryptoAction
    {
        Encrypt = 1,
        Decrypt
    }
    public class clsEncryption
    {

        private string aesEncryptionKey
        {
            get
            {

                return ConfigurationManager.AppSettings["aesEncryptionKey"].ToString();
            }
        }

        public byte[] Encrypt(Stream inputFileStream)
        {
            return this.Invoke(inputFileStream, CryptoAction.Encrypt);
        }

        public byte[] Decrypt(Stream inputFileStream)
        {
            return this.Invoke(inputFileStream, CryptoAction.Decrypt);
        }

        private byte[] Key
        {
            //get
            //{ 
            //    var charData = this.aesEncryptionKey.ToCharArray();
            //    int length = charData.GetUpperBound(0);
            //    var byteDataToHash = new byte[length + 1];

            //    byteDataToHash = Encoding.ASCII.GetBytes(charData);

            //    var byteResult = new SHA512Managed().ComputeHash(byteDataToHash);
            //    var byteKey = new byte[32];

            //    for (int i = 0; i <= 31; i++)
            //        byteKey[i] = byteResult[i];

            //    return byteKey;
            //}

            get
            {
                return System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary.Parse(aesEncryptionKey).Value;

                //var charData = this.aesEncryptionKey.ToCharArray();

                //int length = charData.GetUpperBound(0);
                //var byteDataToHash = new byte[length + 1];

                //byteDataToHash = Encoding.ASCII.GetBytes(charData);

                //var byteResult = new SHA512Managed().ComputeHash(byteDataToHash);
                //var byteKey = new byte[32];

                //for (int i = 0; i <= 31; i++)
                //    byteKey[i] = byteResult[i];

                //return byteKey;
            }
        }

        private byte[] _iv;
        public byte[] IV
        {
            set
            {
                this._iv = value;
            }
            get
            {
                if (_iv != null && _iv.Length > 0)
                {
                    return _iv;
                }

                var charData = Guid.NewGuid().ToString().ToCharArray();
                int length = charData.GetUpperBound(0);
                var byteDataToHash = new byte[length + 1];

                byteDataToHash = Encoding.ASCII.GetBytes(charData);

                var byteResult = new SHA512Managed().ComputeHash(byteDataToHash);

                var byteIV = new byte[16];

                for (int i = 32; i <= 47; i++)
                    byteIV[i - 32] = byteResult[i];

                _iv = byteIV;
                return byteIV;
            }
        }

        private byte[] Invoke(Stream inputFileStream, CryptoAction action)
        {
            var msData = new MemoryStream();
            CryptoStream cs = null;

            try
            {
                long inputFileLength = inputFileStream.Length;
                var byteBuffer = new byte[4096];
                long bytesProcessed = 0;
                int bytesInCurrentBlock = 0;

                var csRijndael = new RijndaelManaged();
                switch (action)
                {
                    case CryptoAction.Encrypt:
                        cs = new CryptoStream(msData, csRijndael.CreateEncryptor(this.Key, this.IV), CryptoStreamMode.Write);
                        break;

                    case CryptoAction.Decrypt:
                        cs = new CryptoStream(msData, csRijndael.CreateDecryptor(this.Key, this.IV), CryptoStreamMode.Write);
                        break;
                }

                while (bytesProcessed < inputFileLength)
                {
                    bytesInCurrentBlock = inputFileStream.Read(byteBuffer, 0, 4096);
                    cs.Write(byteBuffer, 0, bytesInCurrentBlock);
                    bytesProcessed += bytesInCurrentBlock;
                }
                cs.FlushFinalBlock();

                return msData.ToArray();
            }
            catch
            {
                return null;
            }
        }

    }
}