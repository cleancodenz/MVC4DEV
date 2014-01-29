using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class RSA
    {

        private RSACryptoServiceProvider _RSAServiceProvider;

        public RSA()
        {
            _RSAServiceProvider = new RSACryptoServiceProvider();
        }

        public byte[] Encrypt(byte[] DataToEncrypt, RSAParameters keyInfo)
        {

            _RSAServiceProvider.ImportParameters(keyInfo);
            return _RSAServiceProvider.Encrypt(DataToEncrypt, false);
        }

        public byte[] Decrypt(byte[] DataToDecrypt, RSAParameters keyInfo)
        {
            _RSAServiceProvider.ImportParameters(keyInfo);
            return _RSAServiceProvider.Decrypt(DataToDecrypt, false);

        }

      
    }
}
