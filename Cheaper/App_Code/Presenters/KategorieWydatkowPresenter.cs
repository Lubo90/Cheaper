using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KategorieWydatkowPresenter
/// </summary>
public class KategorieWydatkowPresenter : BasePresenter<IKategorieWydatkowView>
{
    ICheaperService _service = new CheaperService();

    public KategorieWydatkowPresenter(IKategorieWydatkowView view)
        : base(view)
    {
        _service = new CheaperService();
    }

    public void InitView(bool isPostBack)
    {
        if (!_view.IsLoggedIn)
            return;

        _view.RepeaterDataSource = _service.GetKategorieWydatku(_view.UserName);
    }
}