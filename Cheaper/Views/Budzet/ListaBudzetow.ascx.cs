using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Budzet_ListaBudzetow : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public List<BudgetsModel> BudgetsRepaterDataSource
    {
        set
        {
            this.rptrBudgets.DataSource = value;
            this.rptrBudgets.DataBind();
        }
    }

    public bool RepeaterVisible
    {
        get
        {
            var ds = rptrBudgets.DataSource as List<BudgetsModel>;
            if (ds != null && ds.Count > 0)
                return true;
            else
                return false;
        }
    }

    public decimal SumaWydatkowRok { get; set; }
    public decimal SumaWydatkowMsc { get; set; }
    public int SumaPozycji { get; set; }
}