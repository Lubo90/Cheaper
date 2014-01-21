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

    public List<BudgetPositionModel> RepeaterDataSource
    {
        set
        {
            this.rptrBudgetDetails.DataSource = value;
        }
        get
        {
            return this.rptrBudgetDetails.DataSource as List<BudgetPositionModel>;
        }
    }

    public bool RepeaterVisible
    {
        get
        {
            if (RepeaterDataSource != null && RepeaterDataSource.Count > 0)
                return true;
            else
                return false;
        }
    }

    public string BudgetName
    {
        set
        {
            this.lblBudgetName.Text = value;
        }
    }

    public bool CanView { get; set; }

    public decimal SumaCeny { get; set; }
    public decimal SumaWartosci { get; set; }
    public decimal SumaIlosci { get; set; }
    public decimal SumaRoznic { get; set; }
}