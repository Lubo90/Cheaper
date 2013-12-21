using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SzabGlowny : System.Web.UI.MasterPage
{
    string login = "lubo";
    string haslo = "kluboka";

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void RefreshContent()
    {
        if (Session["isZalogowany"] is bool && (bool)Session["isZalogowany"] == true)
        {
            mvLogowanie.ActiveViewIndex = 1;
            lblLogin.Text = Session["userLogin"].ToString();
        }
        else
            mvLogowanie.ActiveViewIndex = 0;
    }

    protected void btnZaloguj_Click(object sender, EventArgs e)
    {
        using (var context = new CheaperEntities())
        {
            var result = from c in context.Users where (c.UserName == tbLogin.Text && c.Passwd == tbHaslo.Text) select c;

            if (result.Count() == 1)
            {
                Session["isZalogowany"] = true;
                Session["userLogin"] = tbLogin.Text;
                RefreshContent();
            }
        }
    }
}
