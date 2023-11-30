﻿using System.Security.Cryptography;
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
                return hashedString; 
            }
        }
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            string hashedInput = HashPassword(password); 
            return hashedInput == hashedPassword;
        }
    }
}