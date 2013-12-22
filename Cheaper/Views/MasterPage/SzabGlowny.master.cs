using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cheaper.Presenters;

public partial class SzabGlowny : System.Web.UI.MasterPage, IMasterPage
{
    MasterPagePresenter _presenter;

    public bool SnLoggedIn
    {
        get
        {
            if (Session["UserLoggedIn"] is bool)
                return (bool)Session["UserLoggedIn"];
            else
                return false;
        }
        set
        {
            Session["UserLoggedIn"] = value;
        }
    }
    public string SnUserLogin
    {
        get
        {
            if (!string.IsNullOrEmpty(Session["UserLogin"] as string))
                return Session["UserLogin"] as string;
            else
                return null;
        }
        set
        {
            Session["UserLogin"] = value;
            lblLogin.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new MasterPagePresenter(this);
    }

    public void SwitchMultiViewActiveView(MultiViewContent activeView)
    {
        mvLogowanie.ActiveViewIndex = (int)activeView;
    }

    protected void btnZaloguj_Click(object sender, EventArgs e)
    {
        _presenter.AuthenticateUser(tbLogin.Text, tbHaslo.Text);
    }
}