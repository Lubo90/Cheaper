using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMasterPage
/// </summary>
public interface IMasterPageView:IView
{
    void SwitchMultiViewActiveView(LoggingMultiViewContent activeView);
    //void SetUsernameGreetingText();
    string LabelUserName { set; }
    bool IsLoggedIn { get; set; }
    string UserName { get; set; }
}