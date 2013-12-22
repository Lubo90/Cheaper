using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface ICheaperService
{
    bool AuthenticateUser(string login, string password);
}