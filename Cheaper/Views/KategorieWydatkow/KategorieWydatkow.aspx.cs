using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_KategorieWydatkow_KategorieWydatkow : BaseView, IKategorieWydatkowView
{
    KategorieWydatkowPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new KategorieWydatkowPresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    public List<ExpensesModel> RepeaterDataSource
    {
        set
        {
            this.rptrKatWyd.DataSource = value;
            this.rptrKatWyd.DataBind();
        }
    }

    public bool RepeaterVisible
    {
        get
        {
            var ds = rptrKatWyd.DataSource as List<ExpensesModel>;
            if (ds != null && ds.Count > 0)
                return true;
            else
                return false;
        }
    }

    public string GetColorBasedOnBalance(object balance)
    {
        var convBalance = Convert.ToDecimal(balance);
        if (convBalance < 0)
            return "color: red;";
        else
            return "color: black;";
    }
}