using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Budzet_Budzet : BaseView, IBudzetView
{
    private BudzetPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new BudzetPresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    public List<BudgetsModel> RepeaterDataSource
    {
        set
        {
            this.ListaBudzetow.BudgetsRepaterDataSource = value;
        }
    }

    public BudgetMultiViewContent ActiveView
    {
        set
        {
            this.mvBudzet.ActiveViewIndex = (int)value;
        }
    }

    public string BudgetDate
    {
        set
        {
            this.lblBudgetCreationDate.Text = value;
        }
    }

    public void SaveBudzet(string nazwaBudzetu)
    {
        if (_presenter.SaveBudzet(nazwaBudzetu))
            Response.Redirect("Budzet.aspx", true);
    }

    protected void btnSaveBudzet_Click(object sender, EventArgs e)
    {
        if (_presenter.SaveBudzet(tbBudgetName.Text))
            Response.Redirect("Budzet.aspx", true);
    }
}