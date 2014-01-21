using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Shops_Sklep : BaseView, ISklepView
{
    SklepPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new SklepPresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    public List<ShopModel> RepeaterDataSource
    {
        set
        {
            this.rptrShops.DataSource = value;
            this.rptrShops.DataBind();
        }
    }

    public bool RepeaterVisible
    {
        get
        {
            var ds = rptrShops.DataSource as List<ShopModel>;
            if (ds != null && ds.Count > 0)
                return true;
            else
                return false;
        }
    }
}