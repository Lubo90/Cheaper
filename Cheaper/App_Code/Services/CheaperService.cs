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
        using (var context = new CheaperEntities())
        {
            string hashedPw = GetMD5Hash(password);
            var selectedUsers = from c in context.Users where (c.UserName == login && c.Passwd == hashedPw) select c.UserName;

            if (selectedUsers.Count() == 1)
                return true;
            return false;
        }
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
            var select = from c in context.BudgetsWithExpenses where c.UserID == userName select new BudgetsModel() { BudgetID = c.BudgetID, BudgetName = c.BudgetName, CreationDate = c.CreationDate, LastMonthExpenses = c.ThisMonthExpenses, LastYearExpenses = c.ThisYearExpenses };
            return select.ToList();
        }
    }

    public BudgetsModel GetBudgetData(int budgetId, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.BudgetsWithExpenses where c.UserID == userName && c.BudgetID == budgetId orderby c.CreationDate select new BudgetsModel() { BudgetID = c.BudgetID, BudgetName = c.BudgetName, CreationDate = c.CreationDate, LastMonthExpenses = c.ThisMonthExpenses, LastYearExpenses = c.ThisYearExpenses };
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
                         join products in context.Products on budPos.ProdID equals products.ProductID
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

    public bool DodajPozycjeBudzetu(int idBudzetu, int idProduktu, int idKategorii, int idSklepu, decimal cena, DateTime dataZakupu, int ilosc, string dodatkoweInfo, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Budgets where c.UserID == userName && c.BudgetID == idBudzetu select c.BudgetID;
            if (select.Count() != 1)
                return false;

            var nowaPozycja = new BudgetPositions();
            nowaPozycja.BudgetID = idBudzetu;
            nowaPozycja.ProdID = idProduktu;
            nowaPozycja.ExpenseCatID = idKategorii;
            nowaPozycja.ShopID = idSklepu;
            nowaPozycja.UserID = userName;
            nowaPozycja.Price = cena;
            nowaPozycja.PurchaseDate = dataZakupu;
            nowaPozycja.CreationDate = DateTime.Now;
            nowaPozycja.Quantity = ilosc;
            nowaPozycja.AdditionalInfo = dodatkoweInfo;

            context.BudgetPositions.AddObject(nowaPozycja);

            if (context.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

    public bool DodajBudzet(string nazwaBudzetu, string login, DateTime dataUtworzenia)
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

    public string[] GetProductsAutocomplete(string firstLetters, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Products
                         where c.Name.StartsWith(firstLetters) && c.UserID == userName
                         select new { c.ProductID, c.Name };

            List<string> resultList = new List<string>();
            foreach (var item in select)
            {
                resultList.Add(string.Format("{0}~{1}", item.ProductID, item.Name));
            }

            return resultList.ToArray();
        }
    }

    public string[] GetShopsAutocomplete(string startsWith, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Shops
                         where c.UserID == userName
                            && c.FriendlyName.StartsWith(startsWith)
                         select new { c.Id, c.FriendlyName };

            List<string> resultList = new List<string>();
            foreach (var item in select)
            {
                resultList.Add(string.Format("{0}~{1}", item.Id, item.FriendlyName));
            }

            return resultList.ToArray();
        }
    }

    public bool DodajProdukt(string nazwaProduktu, short idKategorii, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var nowyProdukt = new Products();
            nowyProdukt.Name = nazwaProduktu;
            nowyProdukt.UserID = userName;
            nowyProdukt.CategoryID = idKategorii;

            context.Products.AddObject(nowyProdukt);
            if (context.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

    public Dictionary<int, string> GetKategorie()
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.Categories select new { c.Id, c.Name };

            var resultKategorie = new Dictionary<int, string>();

            foreach (var item in select)
            {
                resultKategorie.Add(item.Id, item.Name);
            }

            return resultKategorie;
        }
    }

    public Dictionary<int, string> GetKategorieWydatkuComboList(string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.ExpenseCategories where c.UserID == userName select new { c.Id, c.Name };

            var resultKategorieWyd = new Dictionary<int, string>();
            foreach (var item in select)
            {
                resultKategorieWyd.Add(item.Id, item.Name);
            }

            return resultKategorieWyd;
        }
    }

    public List<ExpensesModel> GetKategorieWydatku(string userName)
    {
        using (var context = new CheaperEntities())
        {
            var select = from c in context.ExpenseCatLastMthBalance where c.UserID == userName select new ExpensesModel() { Id = c.Id, Name = c.Name, Amount = c.Amount, Balance = c.Balance };

            return select.ToList();
        }
    }

    public bool ChangeKwotaKatWyd(decimal kwota, int idKatWyd, string userName)
    {
        using (var context = new CheaperEntities())
        {
            ExpenseCategories katWyd = (from c in context.ExpenseCategories where c.UserID == userName && c.Id == idKatWyd select c).First();
            katWyd.Amount = kwota;
            if (context.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

    public bool DodajKatWyd(string nazwaKat, decimal kwotaKat, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var nowaKatWyd = new ExpenseCategories();
            nowaKatWyd.Name = nazwaKat;
            nowaKatWyd.Amount = kwotaKat;
            nowaKatWyd.UserID = userName;

            context.ExpenseCategories.AddObject(nowaKatWyd);
            if (context.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

    public bool LogEvent(string methodName, Exception exception, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var nowyEvent = new Events();
            nowyEvent.MethodName = methodName;
            nowyEvent.ExMessage = exception.Message;
            if (exception.InnerException != null)
                nowyEvent.InnerExMessage = exception.InnerException.Message;
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

    public bool DodajSklep(string przyjaznaNazwa, string ulica, string miasto, string kodPocztowy, string userName)
    {
        using (var context = new CheaperEntities())
        {
            var nowySklep = new Shops();
            nowySklep.FriendlyName = przyjaznaNazwa;
            nowySklep.Street = ulica;
            nowySklep.City = miasto;
            nowySklep.PostCode = kodPocztowy;
            nowySklep.UserID = userName;

            context.Shops.AddObject(nowySklep);

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