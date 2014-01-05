using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudzetPresenter
/// </summary>
public class BudzetPresenter
{
    private IBudzetView _view;
    private ICheaperService _service;

	public BudzetPresenter(IBudzetView view)
	{
        _view = view;
        _service = new CheaperService();
	}

    public void InitView(bool isPostBack)
    {
        if (isPostBack)
        {
            _view.BudgetsRepaterDataSource = _service.GetBudgets(_view.UserName);
            _view.ActiveView = BudgetMultiViewContent.BudgetList;
        }
    }

    public void SetNowyBudzetActiveView()
    {
        _view.ActiveView = BudgetMultiViewContent.NewBudget;
        _view.BudgetDate = DateTime.Now.ToString("dd-MM-yyyy");
    }

    public bool SaveBudzet(string nazwaBudzetu)
    {
        return _service.AddBudzet(nazwaBudzetu, _view.UserName, DateTime.Now);
    }
}