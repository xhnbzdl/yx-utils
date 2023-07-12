using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Yx.Utils.Helper
{
    public static class EncryptionHelper
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始向量</param>
        /// <param name="padding">填充模式</param>
        /// <param name="mode">加密模式</param>
        /// <returns></returns>
        public static string AESEncrypt(string source, string key, string iv = "", PaddingMode padding = PaddingMode.PKCS7, CipherMode mode = CipherMode.CBC)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] textBytes = Encoding.UTF8.GetBytes(source);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            byte[] useKeyBytes = new byte[16];
            byte[] useIvBytes = new byte[16];

            if (keyBytes.Length > useKeyBytes.Length)
            {
                Array.Copy(keyBytes, useKeyBytes, useKeyBytes.Length);
            }
            else
            {
                Array.Copy(keyBytes, useKeyBytes, keyBytes.Length);
            }


            if (ivBytes.Length > useIvBytes.Length)
            {
                Array.Copy(ivBytes, useIvBytes, useIvBytes.Length);
            }
            else
            {
                Array.Copy(ivBytes, useIvBytes, ivBytes.Length);
            }

            Aes aes = Aes.Create();
            // 秘钥的大小，以位为单位,128,256等
            aes.KeySize = 256;
            // 支持的块大小
            aes.BlockSize = 128;
            // 填充模式
            aes.Padding = padding;
            // 加密模式
            aes.Mode = mode;
            // 密钥
            aes.Key = useKeyBytes;
            // 初始化向量，如果没有设置默认的16个0
            aes.IV = useIvBytes;

            ICryptoTransform cryptoTransform = aes.CreateEncryptor();
            byte[] resultBytes = cryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始向量</param>
        /// <param name="padding">填充模式</param>
        /// <param name="mode">加密模式</param>
        /// <returns></returns>
        public static string AESDecrypt(string source, string key, string iv = "", PaddingMode padding = PaddingMode.PKCS7, CipherMode mode = CipherMode.CBC)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] textBytes = Convert.FromBase64String(source);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            byte[] useKeyBytes = new byte[16];
            byte[] useIvBytes = new byte[16];

            if (keyBytes.Length > useKeyBytes.Length)
            {
                Array.Copy(keyBytes, useKeyBytes, useKeyBytes.Length);
            }
            else
            {
                Array.Copy(keyBytes, useKeyBytes, keyBytes.Length);
            }


            if (ivBytes.Length > useIvBytes.Length)
            {
                Array.Copy(ivBytes, useIvBytes, useIvBytes.Length);
            }
            else
            {
                Array.Copy(ivBytes, useIvBytes, ivBytes.Length);
            }

            Aes aes = Aes.Create();
            // 秘钥的大小，以位为单位,128,256等
            aes.KeySize = 256;
            // 支持的块大小
            aes.BlockSize = 128;
            // 填充模式
            aes.Padding = padding;
            // 加密模式
            aes.Mode = mode;
            // 密钥
            aes.Key = useKeyBytes;
            // 初始化向量，如果没有设置默认的16个0
            aes.IV = useIvBytes;

            ICryptoTransform decryptoTransform = aes.CreateDecryptor();
            byte[] resultBytes = decryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

            return Encoding.UTF8.GetString(resultBytes);
        }

    }
}
