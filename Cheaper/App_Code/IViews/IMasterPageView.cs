using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMasterPage
/// </summary>
public interface IMasterPageView
{
    bool SnLoggedIn { get; set; }
    string SnUserLogin { get; set; }
    void SwitchMultiViewActiveView(LoggingMultiViewContent activeView);
    void SetUsernameGreetingText();
}