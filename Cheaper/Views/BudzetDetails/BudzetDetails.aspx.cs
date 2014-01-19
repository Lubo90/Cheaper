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
        get
        {
            return this.rptrBudgetDetails.DataSource as List<BudgetDetailsModel>;
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

    private decimal _sumaCeny;
    public decimal SumaCeny
    {
        get { return _sumaCeny; }
        set { _sumaCeny = value; }
    }

    private decimal _sumaWartosci;
    public decimal SumaWartosci
    {
        get { return _sumaWartosci; }
        set { _sumaWartosci = value; }
    }

    private int _sumaIlosci;
    public int SumaIlosci
    {
        get { return _sumaIlosci; }
        set { _sumaIlosci = value; }
    }
}