using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cheaper.Presenters;

public partial class SzabGlowny : System.Web.UI.MasterPage, IMasterPageView
{
    #region Zdarzenia
    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new MasterPagePresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    protected void btnZaloguj_Click(object sender, EventArgs e)
    {
        //_presenter.AuthenticateUser(tbLogin.Text, tbPassword.Text);
        //this.OnDataBinding(new EventArgs());
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        this.DataBind();
    }
    #endregion

    #region Metody i właściwości pozwalające prezenterowi zarządzać widokiem
    MasterPagePresenter _presenter;

    public bool IsLoggedIn
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
    public string UserName
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

    public bool StatisticsEnabled
    {
        get
        {
            if (Session["StatsEnabled"] is bool)
                return (bool)Session["StatsEnabled"];
            else
                return false;
        }
    }

    public bool IsDefaultPage
    {
        get
        {
            return Request.Url.Segments.Last().StartsWith("Default.aspx");
        }
    }

    public void RedirectTo(string page, bool endResponse = false)
    {
        Response.Redirect(page, endResponse);
    }

    public string LabelUserName
    {
        set { lblLogin.Text = value; }
    }

    public string GetQueryStringValue(string parameter)
    {
        if (!string.IsNullOrEmpty(Request.QueryString[parameter] as string))
            return Request.QueryString[parameter] as string;
        else
            return null;
    }

    public void SwitchMultiViewActiveView(LoggingMultiViewContent activeView)
    {
        mvLogowanie.ActiveViewIndex = (int)activeView;
    }

    #endregion
    protected void lbWyloguj_Click(object sender, EventArgs e)
    {
        _presenter.LogUserOut();
    }
}