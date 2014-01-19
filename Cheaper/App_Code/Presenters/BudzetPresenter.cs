using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudzetPresenter
/// </summary>
public class BudzetPresenter : BasePresenter<IBudzetView>
{
    private ICheaperService _service;

    public BudzetPresenter(IBudzetView view)
        : base(view)
    {
        _service = new CheaperService();
    }

    public void InitView(bool isPostBack)
    {
        if (!_view.IsLoggedIn)
            return;

        var budgets=_service.GetBudgets(_view.UserName);
        _view.RepeaterDataSource = budgets;

        decimal sumaMsc = 0;
        decimal sumaRok = 0;
        int sumaPozycji = 0;
        foreach(var item in budgets)
        {
            sumaMsc += item.LastMonthExpenses;
            sumaRok += item.LastYearExpenses;
            sumaPozycji += item.PositionsCount;
        }

        _view.SumaWydatkowMsc = sumaMsc;
        _view.SumaWydatkowRok = sumaRok;
        _view.SumaPozycji = sumaPozycji;
    }

    public bool SaveBudzet(string nazwaBudzetu)
    {
        return _service.DodajBudzet(nazwaBudzetu, _view.UserName, DateTime.Now);
    }
}