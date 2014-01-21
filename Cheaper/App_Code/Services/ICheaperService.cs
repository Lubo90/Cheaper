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
    UserModel GetUserData(string userName);
    bool RegisterNewUser(string login, string password, string email, DateTime birthDate, bool statsEnabled);
    bool IsUsernameAvailable(string userName);

    List<BudgetModel> GetBudgets(string userName);
    BudgetModel GetBudgetData(int budgetId, string userName);
    List<BudgetPositionModel> GetBudgetDetailsData(int budgetId, string userName);
    bool DodajPozycjeBudzetu(int idBudzetu, int idProduktu, int idKategorii, int? idSklepu, decimal cena, DateTime dataZakupu, decimal ilosc, string dodatkoweInfo, string userName);

    bool DodajBudzet(string nazwaBudzetu, string login, DateTime dataUtworzenia);
    string[] GetProductsAutocomplete(string firstLetter, string userName, bool getDictValues);
    string[] GetShopsAutocomplete(string startsWith, string userName);
    List<ShopModel> GetShops(string userName);
    bool DodajProdukt(string nazwaProduktu, short idKategorii, string userName);

    Dictionary<int, string> GetKategorie();
    Dictionary<int, string> GetKategorieWydatkuComboList(string userName);
    List<ExpenseModel> GetKategorieWydatku(string userName);

    bool ChangeKwotaKatWyd(decimal kwota, int idKatWyd, string userName);
    bool DodajKatWyd(string nazwaKat, decimal kwotaKat, string userName);

    bool DodajSklep(string przyjaznaNazwa, string ulica, string miasto, string kodPocztowy, string userName);

    bool LogEvent(string methodName, Exception exceptionstring, string userName);
}