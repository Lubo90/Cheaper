using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for View
/// </summary>
public class BaseView : System.Web.UI.Page
{
    public BaseView()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);
        this.DataBind();
    }

    public string GetQueryStringValue(string parameter)
    {
        if (!string.IsNullOrEmpty(Request.QueryString[parameter] as string))
            return Request.QueryString[parameter] as string;
        else
            return null;
    }

    public void RedirectTo(string page, bool endResponse = false)
    {
        Response.Redirect(page, endResponse);
    }

    public string UserName
    {
        get
        {
            if (Session["UserLogin"] is string)
                return Session["UserLogin"].ToString();
            else
                return string.Empty;
        }
    }

    public bool IsLoggedIn
    {
        get
        {
            if (Session["UserLoggedIn"] is bool)
                return (bool)Session["UserLoggedIn"];
            else
                return false;
        }
    }
}