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
        var budgetData = _service.GetBudgetData(int.Parse(_view.GetQueryStringValue(GETValueIdentifiers.ID)), _view.UserName);
        _view.BudgetName = budgetData.BudgetName;

        this._view.RepeaterDataSource = _service.GetBudgetDetailsData(int.Parse(_view.GetQueryStringValue("id")), _view.UserName);
    }
}