using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Budzet_NowyBudzet : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private IBudzetView _mainView;
    public IBudzetView MainView
    {
        set { _mainView = value; }
        get { return _mainView; }
    }

    public string NowyBudzetDate
    {
        set
        {
            this.lblBudgetCreationDate.Text = value;
        }
    }

    protected void btnSaveBudzet_Click(object sender, EventArgs e)
    {
        MainView.SaveBudzet(tbBudgetName.Text);
    }
}