using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IWebService
/// </summary>
public interface IWebService
{
    void AuthorizeUser(string loginData);
}