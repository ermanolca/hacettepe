using System.Security.Cryptography;
using System.Text;

namespace Hacettepe.Application.Utils;

public static class Hasher
{
    public static string Hash(string stringToBeHashed, byte[] salt)
    {
        using var sha256 =  SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(stringToBeHashed);
        var saltedPassword = new byte[passwordBytes.Length + salt.Length];

        // Concatenate password and salt
        Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

        // Hash the concatenated password and salt
        byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

        // Concatenate the salt and hashed password for storage
        byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
        Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
        Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

        return Convert.ToBase64String(hashedPasswordWithSalt);

    }
}