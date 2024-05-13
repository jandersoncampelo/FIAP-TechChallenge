using System.Security.Cryptography;
using System.Text;

namespace InvestmentPortal.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToSHA256(this string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a string para bytes
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Calcula o hash SHA-256
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Converte o hash de volta para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
