using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Octavo.Gate.Nabu.CORE.Encryption
{
    public class EncryptorDecryptor
    {
        public bool ErrorsDetected = false;
        public string ErrorMessage = "";
        public string StackTrace = "";

        /// <param name="passPhrase">
        /// Passphrase from which a pseudo-random password will be derived. The
        /// derived password will be used to generate the encryption key.
        /// Passphrase can be any string. In this example we assume that this
        /// passphrase is an ASCII string.
        /// </param>
        public string passPhrase = "Pas5pr@se";         // can be any string

        /// <param name="saltValue">
        /// Salt value used along with passphrase to generate password. Salt can
        /// be any string. In this example we assume that salt is an ASCII string.
        /// </param>
        public string saltValue = "s@1tValue";          // can be any string

        /// <param name="hashAlgorithm">
        /// Hash algorithm used to generate password. Allowed values are: "MD5" and
        /// "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        /// </param>
        public string hashAlgorithm = "SHA1";           // can be "MD5"

        /// <param name="passwordIterations">
        /// Number of iterations used to generate password. One or two iterations
        /// should be enough.
        /// </param>
        public int passwordIterations = 2;              // can be any number

        /// <param name="initVector">
        /// Initialization vector (or IV). This value is required to encrypt the
        /// first block of plaintext data. For RijndaelManaged class IV must be 
        /// exactly 16 ASCII characters long.
        /// </param>
        public string initVector = "@1B2c3D4e5F6g7H8";  // must be 16 bytes

        /// <param name="keySize">
        /// Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
        /// Longer keys are more secure than shorter keys.
        /// </param>
        public int keySize = 256;                       // can be 192 or 128

        public EncryptorDecryptor()
        {
        }

        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be encrypted.
        /// </param>
        /// <returns>
        /// Encrypted value formatted as a base64-encoded string.
        /// </returns>
        public string Encrypt(string plainText)
        {
            try
            {
                if (plainText.Trim().Length > 0)
                {
                    // Convert strings into byte arrays.
                    // Let us assume that strings only contain ASCII codes.
                    // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                    // encoding.
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                    // Convert our plaintext into a byte array.
                    // Let us assume that plaintext contains UTF8-encoded characters.
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                    // First, we must create a password, from which the key will be derived.
                    // This password will be generated from the specified passphrase and 
                    // salt value. The password will be created using the specified hash 
                    // algorithm. Password creation can be done in several iterations.
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = password.GetBytes(keySize / 8);

                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = new RijndaelManaged();

                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;

                    // Generate encryptor from the existing key bytes and initialization 
                    // vector. Key size will be defined based on the number of the key 
                    // bytes.
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = new MemoryStream();

                    // Define cryptographic stream (always use Write mode for encryption).
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    // Start encrypting.
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                    // Finish encrypting.
                    cryptoStream.FlushFinalBlock();

                    // Convert our encrypted data from a memory stream into a byte array.
                    byte[] cipherTextBytes = memoryStream.ToArray();

                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    // Convert encrypted data into a base64-encoded string.
                    string cipherText = Convert.ToBase64String(cipherTextBytes);

                    // Return encrypted string.
                    return cipherText;
                }
                else
                    return plainText;
            }
            catch (Exception exc)
            {
                ErrorsDetected = true;
                ErrorMessage = exc.Message;
                StackTrace = exc.StackTrace;
                return plainText;
            }
        }
        /// <summary>
        /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        /// </summary>
        /// <param name="cipherText">
        /// Base64-formatted ciphertext value.
        /// </param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        /// <remarks>
        /// Most of the logic in this function is similar to the Encrypt
        /// logic. In order for decryption to work, all parameters of this function
        /// - except cipherText value - must match the corresponding parameters of
        /// the Encrypt function which was called to generate the
        /// ciphertext.
        /// </remarks>
        public string Decrypt(string cipherText)
        {
            try
            {
                if (cipherText.Trim().Length > 0)
                {
                    // Convert strings defining encryption key characteristics into byte
                    // arrays. Let us assume that strings only contain ASCII codes.
                    // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                    // encoding.
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                    // Convert our ciphertext into a byte array.
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                    // First, we must create a password, from which the key will be 
                    // derived. This password will be generated from the specified 
                    // passphrase and salt value. The password will be created using
                    // the specified hash algorithm. Password creation can be done in
                    // several iterations.
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = password.GetBytes(keySize / 8);

                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = new RijndaelManaged();

                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;

                    // Generate decryptor from the existing key bytes and initialization 
                    // vector. Key size will be defined based on the number of the key 
                    // bytes.
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                    // Define cryptographic stream (always use Read mode for encryption).
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                    // Since at this point we don't know what the size of decrypted data
                    // will be, allocate the buffer long enough to hold ciphertext;
                    // plaintext is never longer than ciphertext.
                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                    // Start decrypting.
                    //int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                    int readBytes = 0;
                    while (readBytes < cipherTextBytes.Length)
                    {
                        int n = cryptoStream.Read(plainTextBytes, readBytes, cipherTextBytes.Length - readBytes);
                        if (n == 0) 
                            break;
                        readBytes += n;
                    }

                    // Close both streams.
                    memoryStream.Close();

                    cryptoStream.Close();

                    // Convert decrypted data into a string. 
                    // Let us assume that the original plaintext string was UTF8-encoded.
                    //string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                    string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, readBytes);

                    // Return decrypted string.   
                    return plainText;
                }
                else
                    return cipherText;
            }
            catch (Exception exc)
            {
                ErrorsDetected = true;
                ErrorMessage = exc.Message;
                StackTrace = exc.StackTrace;
                return cipherText;
            }
        }

        /**********************************************************************
         * MD5
         *********************************************************************/
        public string EncrtyptMD5(string pSourceText)
        {
            string encryptedString = null;
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    encryptedString = GetMd5Hash(md5Hash, pSourceText);
                    //Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                    //Console.WriteLine("Verifying the hash...");
                    //if (VerifyMd5Hash(md5Hash, pSourceText, hash))
                    //    encryptedString = hash;
                    //else
                    //{
                    //    Console.WriteLine("The hashes are not same.");
                    //}
                }
            }
            catch
            {
            }
            return encryptedString;
        }
        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /**********************************************************************
         * URL Encoding and Decoding
         *********************************************************************/
        public string UrlEncode(string pEncryptedString)
        {
            /*
             Dollar ("$")                       24
             Ampersand ("&")                    26
             Percent(%)                         25
             Plus ("+")                         2B
             Comma (",")                        2C
             Forward slash/Virgule ("/")        2F
             Colon (":")                        3A
             Semi-colon (";")                   3B
             Equals ("=")                       3D
             Question mark ("?")                3F
             'At' symbol ("@")                  40
             */

        string encoded = "";
            for (int i = 0; i < pEncryptedString.Length; i++)
            {
                string character = Convert.ToString(pEncryptedString[i]);
                if (reservedCharacters.Contains(character))
                {
                    for (int x = 0; x < reservedCharacters.Length; x++)
                    {
                        string reservedCharacter = Convert.ToString(reservedCharacters[x]);
                        if (character.CompareTo(reservedCharacter) == 0)
                        {
                            encoded += percentValueMapping[x];
                            break;
                        }
                    }
                }
                else
                    encoded += character;
            }
            return encoded;
        }
        public string UrlDecode(string pEncryptedString)
        {
            if (pEncryptedString != null && pEncryptedString.Trim().Length > 0 && pEncryptedString.Contains("%"))
            {
                string decoded = "";
                for (int i = 0; i < pEncryptedString.Length - 1; i++)
                {
                    if (pEncryptedString.Substring(i, 1).CompareTo("%") == 0)
                    {
                        string percentValue = pEncryptedString.Substring(i, 3);
                        for (int x = 0; x < percentValueMapping.Length; x++)
                        {
                            if (percentValueMapping[x].CompareTo(percentValue) == 0)
                            {
                                decoded += reservedCharacters[x].ToString();
                                break;
                            }
                        }
                        i += 2;
                    }
                    else
                        decoded += pEncryptedString.Substring(i, 1);
                }
                return decoded;
            }
            else
                return pEncryptedString;
        }

        /**********************************************************************
         * Private Variables used by URL Encoding/Decoding methods
         *********************************************************************/
        private string reservedCharacters = "$&+,/:;=?@%";
        private string[] percentValueMapping = { "%24", "%26", "%2b", "%2c", "%2f", "%3a", "%3B", "%3d", "%3F", "%40", "%25" };
    }
}
