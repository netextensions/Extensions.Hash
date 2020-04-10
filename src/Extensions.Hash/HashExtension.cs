using System;
using System.Security.Cryptography;
using System.Text;
using ServiceStack.Text;

namespace NetExtensions
{
    public static class HashExtension
    {
        public static string GenerateHash(this object obj)
        {
            using var md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, TypeSerializer.SerializeToString(obj));
        }

        public static bool VerifyMd5Hash(this object obj, string hash)
        {
            using var md5Hash = MD5.Create();
            return 0 == StringComparer.OrdinalIgnoreCase.Compare(GetMd5Hash(md5Hash, TypeSerializer.SerializeToString(obj)), hash);
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (var t in data) sBuilder.Append(t.ToString("x2"));

            return sBuilder.ToString();
        }

        public static string GetMd5Hash(this string input)
        {
            using var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (var t in data) sBuilder.Append(t.ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
