using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SklepPresenter
/// </summary>
public class SklepPresenter : BasePresenter<ISklepView>
{
    ICheaperService _service = new CheaperService();

    public SklepPresenter(ISklepView view)
        : base(view)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void InitView(bool isPostBack)
    {
        this._view.RepeaterDataSource = _service.GetShops(this._view.UserName);
    }
}