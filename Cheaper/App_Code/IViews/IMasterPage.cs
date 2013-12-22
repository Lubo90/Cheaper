using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMasterPage
/// </summary>
public interface IMasterPage
{
    bool SnLoggedIn { get; set; }
    string SnUserLogin { get; set; }
    void SwitchMultiViewActiveView(MultiViewContent activeView);
}