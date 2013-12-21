using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        using (var context = new CheaperEntities())
        {
            var user = new Users();

            var parserRys = MD5.Create();

            user.UserName = "lubo2";
            var parsedHash = parserRys.ComputeHash(Encoding.ASCII.GetBytes("roxkox"));
            user.Passwd = parsedHash.ToString();
            user.Email = "lubo@us.edu.pl";
            user.VerifCode = "xyz123";
            user.BirthDate = DateTime.Now;
            user.RegisterDate = DateTime.Now;

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}

public class Czlowiek<T> {}

public class Lubo {}