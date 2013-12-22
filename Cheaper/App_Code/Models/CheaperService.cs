using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Repo;

namespace Cheaper.Models
{
    /// <summary>
    /// Serwis zajmujący się komunikacją z bazą danych za pomocą EntityFramework'a
    /// </summary>
    public class CheaperService : ICheaperService
    {
        public CheaperService() { }

        public bool AuthenticateUser(string login, string password)
        {
            using (var context = new CheaperEntities())
            {
                string hashedPassword = GetMD5Hash(password);
                var selectedUsers = from c in context.Users where (c.UserName == login && c.Passwd == hashedPassword) select c.UserName;

                if (selectedUsers.Count() == 1)
                    return true;
                else
                    return false;
            }
        }

        private string GetMD5Hash(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}