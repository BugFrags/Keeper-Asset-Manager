namespace Keeper_AssetManager.Data;
using System;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

public class Utils
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 4;
    private const int MemorySize = 65536;
    private const int Parallelism = 8;

    public static string HashPassword(string password)
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        
        byte[] hash = GetHash(password, salt);
        
        byte[] combined = new byte[salt.Length + hash.Length];
        Array.Copy(salt, 0, combined, 0, salt.Length);
        Array.Copy(hash, 0, combined, salt.Length, hash.Length);
        
        return Convert.ToBase64String(combined);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        byte[] combined = Convert.FromBase64String(storedHash);
        byte[] salt = new byte[SaltSize];
        byte[] storedHashBytes = new Byte[HashSize];
        
        Array.Copy(combined, 0, salt, 0, SaltSize);
        Array.Copy(combined, SaltSize, storedHashBytes, 0, HashSize);

        byte[] newHash = GetHash(password, salt);
        
        return CryptographicOperations.FixedTimeEquals(newHash,storedHashBytes);
    }

    private static byte[] GetHash(string password, byte[] salt)
    {
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.Iterations = Iterations;
        argon2.MemorySize =  MemorySize;
        argon2.DegreeOfParallelism =  Parallelism;
        return argon2.GetBytes(HashSize);
    }
}