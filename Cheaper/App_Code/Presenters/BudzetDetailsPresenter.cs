using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudzetDetailsPresenter
/// </summary>
public class BudzetDetailsPresenter : BasePresenter<IBudzetDetailsView>
{
    ICheaperService _service;

    public BudzetDetailsPresenter(IBudzetDetailsView view)
        : base(view)
    {
        _service = new CheaperService();
    }

    public void InitView(bool isPostBack)
    {
        if (!_view.IsLoggedIn)
            return;

        if (_view.GetQueryStringValue(GETValueIdentifiers.ID) == null)
        {
            _view.CanView = false;
            return;
        }

        var budgetData = _service.GetBudgetData(int.Parse(_view.GetQueryStringValue(GETValueIdentifiers.ID)), _view.UserName);
        if (budgetData == null)
        {
            this._view.CanView = false;
            _service.LogEvent("BudzetDetails", new Exception("Próba wyświetlenia szczegółów budżetu nienależącego do użytkownika"), _view.UserName);
            return;
        }
        this._view.CanView = true;

        _view.BudgetName = budgetData.BudgetName;
        var budgetDetails = _service.GetBudgetDetailsData(int.Parse(_view.GetQueryStringValue("id")), _view.UserName);
        this._view.RepeaterDataSource = budgetDetails;

        decimal sumaCeny = 0;
        decimal sumaIlosci = 0;
        decimal sumaWartosci = 0;
        decimal sumaRoznic = 0;
        foreach (var item in budgetDetails)
        {
            sumaCeny += item.Price;
            sumaIlosci += item.Quantity;
            sumaWartosci += item.Wartosc;
            if (_view.StatisticsEnabled)
                sumaRoznic += item.RoznicaCeny;
        }

        _view.SumaCeny = sumaCeny;
        _view.SumaIlosci = sumaIlosci;
        _view.SumaWartosci = sumaWartosci;
        _view.SumaRoznic = sumaRoznic;
    }
}