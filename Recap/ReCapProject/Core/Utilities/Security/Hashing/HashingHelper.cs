using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using var hmac = new HMACSHA512();
            passwordsalt = hmac.Key;
            passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt)
        {
            using var hmac = new HMACSHA512(passwordsalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordhash[i]) return false;
            }

            return true;
        }
    }
}