using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_BudzetDetails_BudzetDetails : BaseView, IBudzetDetailsView
{
    private BudzetDetailsPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new BudzetDetailsPresenter(this);
        _presenter.InitView(IsPostBack);
    }

    public List<BudgetDetailsModel> RepeaterDataSource
    {
        set
        {
            this.rptrBudgetDetails.DataSource = value;
        }
    }

    private string _budgetName;
    public string BudgetName
    {
        set
        {
            this.lblBudgetName.Text = value;
        }
    }
}