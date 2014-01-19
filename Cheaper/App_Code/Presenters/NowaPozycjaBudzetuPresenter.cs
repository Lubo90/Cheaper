using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NowaPozycjaBudzetuPresenter
/// </summary>
public class NowaPozycjaBudzetuPresenter : BasePresenter<INowaPozycjaBudzetu>
{
    ICheaperService _service;

    public NowaPozycjaBudzetuPresenter(INowaPozycjaBudzetu view)
        : base(view)
    {
        _service = new CheaperService();
    }

    public void InitView(bool isPostBack)
    {
        if (!isPostBack && _view.IsLoggedIn)
        {
            if (_view.GetQueryStringValue(GETValueIdentifiers.ID) == null)
            {
                _view.CanView = false;
                return;
            }

            var budgetData = _service.GetBudgetData(int.Parse(_view.GetQueryStringValue(GETValueIdentifiers.ID)), _view.UserName);
            if (budgetData == null)
            {
                _view.CanView = false;
                _service.LogEvent("NowaPozycjaBudzetu", new Exception("Próba wyświetlenia strony dodawania pozycji do budżetu nienależącego do użytkownika"), _view.UserName);
                return;
            }
            _view.CanView = true;

            _view.DdlKategorieDataSource = _service.GetKategorie();

            var katWyd = _service.GetKategorieWydatkuComboList(_view.UserName);
            if (katWyd == null)
            {
                this._view.HasKategorieWydatkow = false;
                return;
            }
            else
            {
                this._view.HasKategorieWydatkow = true;
                _view.DllKategorieWydDataSource = katWyd;
            }
            _view.BudgetName = budgetData.BudgetName;
        }
    }

    public void SavePozycjaBudzetu(int idProduktu, int idKategorii, int? idSklepu, decimal cena, DateTime dataZakupu, decimal ilosc, string dodatkoweInfo)
    {
        int result;
        if (int.TryParse(_view.GetQueryStringValue("id"), out result))
        {
            if (_service.DodajPozycjeBudzetu(result, idProduktu, idKategorii, idSklepu, cena, dataZakupu, ilosc, dodatkoweInfo, _view.UserName))
                _view.RedirectTo(string.Format("~/Views/BudzetDetails/BudzetDetails.aspx?id={0}", _view.GetQueryStringValue("id")));
        }
    }
}