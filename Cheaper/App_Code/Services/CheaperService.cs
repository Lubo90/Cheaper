using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for CheaperService
/// </summary>
public class CheaperService : ICheaperService
{
    public CheaperService()
    {
    }

    public bool CheckUserAuthentication(string login, string password)
    {
        bool userExists = false;
        using (var context = new CheaperEntities())
        {
            string hashedPw = GetMD5Hash(password);
            var selectedUsers = from c in context.Users where (c.UserName == login && c.Passwd == hashedPw) select c.UserName;

            if (selectedUsers.Count() == 1)
                userExists = true;
        }
        return userExists;
    }

    public List<UsersModel> GetUsers()
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Users select new UsersModel() { UserName = c.UserName, Passwd = c.Passwd };
            return select.ToList();
        }
    }

    public List<BudgetsModel> GetBudgets(string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Budgets where c.UserID == userName select new BudgetsModel() { BudgetID = c.BudgetID, BudgetName = c.BudgetName, CreationDate = c.CreationDate, Expenses = c.Expenses, Income = c.Income };
            return select.ToList();
        }
    }

    public BudgetsModel GetBudgetData(int budgetId, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Budgets where c.UserID == userName && c.BudgetID == budgetId select new BudgetsModel() { BudgetID = c.BudgetID, BudgetName = c.BudgetName, CreationDate = c.CreationDate, Expenses = c.Expenses, Income = c.Income };
            var resultArray = select.ToArray();
            if (resultArray.Count() > 0)
                return resultArray[0];
            else
                return null;
        }
    }

    public List<BudgetDetailsModel> GetBudgetDetailsData(int budgetId, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from budPos in context.BudgetPositions
                         join buds in context.Budgets on budPos.BudgetID equals buds.BudgetID
                         join shops in context.Shops on budPos.ShopID equals shops.Id
                         join products in context.Products on budPos.ProdID equals products.Id
                         join expCats in context.ExpenseCategories on budPos.ExpenseCatID equals expCats.Id
                         where budPos.BudgetID == budgetId && buds.UserID == userName
                         select new BudgetDetailsModel()
                         {
                             PositionID = budPos.PositionID,
                             Price = budPos.Price,
                             PurchaseDate = budPos.PurchaseDate,
                             Quantity = budPos.Quantity,
                             AddInfo = budPos.AdditionalInfo,
                             ProductName = products.Name,
                             ExpenseCatName = expCats.Name,
                             ShopFriendlyName = shops.FriendlyName,
                             ShopStreet = shops.Street,
                             ShopCity = shops.City,
                             ShopPostCode = shops.PostCode
                         };

            return select.ToList();
        }
    }

    public bool AddBudzet(string nazwaBudzetu, string login, DateTime dataUtworzenia)
    {
        using (var context = new CheaperEntities())
        {
            var nowyBudzet = new Budgets();
            nowyBudzet.BudgetName = nazwaBudzetu;
            nowyBudzet.CreationDate = dataUtworzenia;
            nowyBudzet.UserID = login;

            context.Budgets.AddObject(nowyBudzet);
            if (context.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

    public bool LogEvent(string methodName, string exceptionMessage, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var nowyEvent = new Events();
            nowyEvent.MethodName = methodName;
            nowyEvent.ExMessage = exceptionMessage;
            nowyEvent.OccurenceDate = DateTime.Now;
            if (!string.IsNullOrEmpty(userName))
                nowyEvent.UserName = userName;

            context.Events.AddObject(nowyEvent);

            if (context.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

    #region Metody pomocnicze
    private string GetMD5Hash(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

        byte[] hash = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("x2"));
        }
        return sb.ToString();
    }
    #endregion
}