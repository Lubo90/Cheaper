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
            _view.DdlKategorieDataSource = _service.GetKategorie();
            _view.DllKategorieWydDataSource = _service.GetKategorieWydatkuComboList(_view.UserName);
        }
    }

    public void SavePozycjaBudzetu(int idProduktu, int idKategorii, int idSklepu, decimal cena, DateTime dataZakupu, int ilosc, string dodatkoweInfo)
    {
        int result;
        if (int.TryParse(_view.GetQueryStringValue("id"), out result))
        {
            if (_service.DodajPozycjeBudzetu(result, idProduktu, idKategorii, idSklepu, cena, dataZakupu, ilosc, dodatkoweInfo, _view.UserName))
                _view.RedirectTo(string.Format("~/Views/BudzetDetails/BudzetDetails.aspx?id={0}", _view.GetQueryStringValue("id")));
        }
    }
}