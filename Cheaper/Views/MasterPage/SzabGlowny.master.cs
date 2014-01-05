using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cheaper.Presenters;

public partial class SzabGlowny : System.Web.UI.MasterPage, IMasterPageView
{
    #region Metody i właściwości pozwalające prezenterowi zarządzać widokiem
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
        }
    }

    public void SetUsernameGreetingText()
    {
        if (SnLoggedIn)
            lblLogin.Text = SnUserLogin;
    }

    public void SwitchMultiViewActiveView(LoggingMultiViewContent activeView)
    {
        mvLogowanie.ActiveViewIndex = (int)activeView;
    }
    #endregion

    #region Zdarzenia
    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new MasterPagePresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    protected void btnZaloguj_Click(object sender, EventArgs e)
    {
        _presenter.AuthenticateUser(tbLogin.Text, tbPassword.Text);
    }
    #endregion
}