using System.Security.Cryptography;
using System.Text;

namespace SharedLibraryProject
{
    public static class PasswordHashUtility
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "");
                return hashedString.Substring(0, 64);
            }
        }
    }
}