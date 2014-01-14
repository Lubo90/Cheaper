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

        _view.RepeaterDataSource = _service.GetBudgets(_view.UserName);
    }

    public bool SaveBudzet(string nazwaBudzetu)
    {
        return _service.DodajBudzet(nazwaBudzetu, _view.UserName, DateTime.Now);
    }
}