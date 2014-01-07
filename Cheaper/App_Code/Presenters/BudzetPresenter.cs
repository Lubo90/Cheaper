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
        _view.RepeaterDataSource = _service.GetBudgets(_view.UserName);
        switch (_view.GetQueryStringValue(GETValueIdentifiers.PAGE))
        {
            case GET_PAGEIdentifiers.LIST:
                _view.ActiveView = BudgetMultiViewContent.BudgetList;
                break;
            case GET_PAGEIdentifiers.NOWY_BUDZET:
                _view.ActiveView = BudgetMultiViewContent.NewBudget;
                _view.BudgetDate = DateTime.Now.ToString("dd-MM-yyyy");
                break;
            default:
                _view.ActiveView = BudgetMultiViewContent.BudgetList;
                break;
        }
    }

    public bool SaveBudzet(string nazwaBudzetu)
    {
        return _service.AddBudzet(nazwaBudzetu, _view.UserName, DateTime.Now);
    }
}