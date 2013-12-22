using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for CheaperService
/// </summary>
public class CheaperService:ICheaperService
{
	public CheaperService()
	{
	}

    public bool CheckUserAuthentication(string login, string password)
    {
        bool userExists = false;
        using (var context = new CheaperEntities())
        {
            string hashedPw =  GetMD5Hash(password);
            var selectedUsers = from c in context.Users where (c.UserName == login && c.Passwd == hashedPw) select c.UserName;

            if (selectedUsers.Count() == 1)
                userExists = true;
        }
        return userExists;
    }

    public List<UsersModel> GetUsers()
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Users select new UsersModel() { UserName = c.UserName, Passwd = c.Passwd };
            return select.ToList();
        }
    }

    #region Metody pomocnicze
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
    #endregion
}