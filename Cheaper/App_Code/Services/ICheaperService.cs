using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ICheaperService
/// </summary>
public interface ICheaperService
{
    bool CheckUserAuthentication(string login, string password);
    List<UsersModel> GetUsers();

    List<BudgetsModel> GetBudgets(string userName);

    bool AddBudzet(string nazwaBudzetu, string login, DateTime dataUtworzenia);
}