using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for View
/// </summary>
public interface IView
{
    bool IsLoggedIn { get; }
    string UserName { get; }
    bool StatisticsEnabled { get; }
    string GetQueryStringValue(string parameter);
    void RedirectTo(string page, bool endResponse = false);
}