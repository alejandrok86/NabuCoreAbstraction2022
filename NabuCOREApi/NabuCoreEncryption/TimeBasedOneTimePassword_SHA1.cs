using System;
using System.Security.Cryptography;
using System.Text;

namespace Octavo.Gate.Nabu.CORE.Encryption
{
    public class TimeBasedOneTimePassword_SHA1
    {
        private byte[] K;
        public TimeBasedOneTimePassword_SHA1()
        {
            GenerateKey();
        }
        public void GenerateKey()
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                /*    Keys SHOULD be of the length of the HMAC output to facilitate
                      interoperability.*/
                //K = new byte[HMACSHA1.Create().HashSize / 8];
                K = new byte[20];
                rng.GetBytes(K);
            }
        }
        public int HOTP(UInt64 C, int digits = 6)
        {
            using (var hashAlgorithm = new HMACSHA1(K))
            {
                return Truncate(hashAlgorithm.ComputeHash(BitConverter.GetBytes(C)), digits);
            }
        }
        public UInt64 CounterNow(int T1 = 30)
        {
            var secondsSinceEpoch = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return (UInt64)Math.Floor(secondsSinceEpoch / T1);
        }
        private int DT(byte[] hmac_result)
        {
            int offset = hmac_result[19] & 0xf;
            int bin_code = (hmac_result[offset] & 0x7f) << 24
               | (hmac_result[offset + 1] & 0xff) << 16
               | (hmac_result[offset + 2] & 0xff) << 8
               | (hmac_result[offset + 3] & 0xff);
            return bin_code;
        }

        private int Truncate(byte[] hmac_result, int digits)
        {
            var Snum = DT(hmac_result);
            return Snum % (int)Math.Pow(10, digits);
        }
    }
}
