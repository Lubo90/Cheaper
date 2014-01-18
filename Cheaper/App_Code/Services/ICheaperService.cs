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
    bool DodajPozycjeBudzetu(int idBudzetu, int idProduktu, int idKategorii, int idSklepu, decimal cena, DateTime dataZakupu, int ilosc, string dodatkoweInfo, string userName);

    bool DodajBudzet(string nazwaBudzetu, string login, DateTime dataUtworzenia);
    string[] GetProductsAutocomplete(string firstLetter, string userName);
    string[] GetShopsAutocomplete(string startsWith, string userName);
    bool DodajProdukt(string nazwaProduktu, short idKategorii, string userName);

    Dictionary<int, string> GetKategorie();
    Dictionary<int, string> GetKategorieWydatkuComboList(string userName);
    List<ExpensesModel> GetKategorieWydatku(string userName);

    bool ChangeKwotaKatWyd(decimal kwota, int idKatWyd, string userName);
    bool DodajKatWyd(string nazwaKat, decimal kwotaKat, string userName);

    bool DodajSklep(string przyjaznaNazwa, string ulica, string miasto, string kodPocztowy, string userName);

    bool LogEvent(string methodName, Exception exceptionstring, string userName);
}