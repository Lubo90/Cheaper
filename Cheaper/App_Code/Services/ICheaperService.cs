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
    BudgetsModel GetBudgetData(int budgetId, string userName);
    List<BudgetDetailsModel> GetBudgetDetailsData(int budgetId, string userName);

    bool AddBudzet(string nazwaBudzetu, string login, DateTime dataUtworzenia);

    bool LogEvent(string methodName, string exceptionMessage, string userName);
}