using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_BudzetDetails_NowaPozycjaBudzetu : BaseView, INowaPozycjaBudzetu
{
    NowaPozycjaBudzetuPresenter _presenter;

    public Dictionary<int, string> DdlKategorieDataSource
    {
        set
        {
            this.ddlKategorie.DataSource = value;
            this.ddlKategorie.DataTextField = "Value";
            this.ddlKategorie.DataValueField = "Key";
            this.ddlKategorie.DataBind();
        }
    }

    public Dictionary<int, string> DllKategorieWydDataSource
    {
        set
        {
            this.ddlKategorieWyd.DataSource = value;
            this.ddlKategorieWyd.DataTextField = "Value";
            this.ddlKategorieWyd.DataValueField = "Key";
            this.ddlKategorieWyd.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new NowaPozycjaBudzetuPresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    protected void btnSavePozycja_Click(object sender, EventArgs e)
    {
        _presenter.SavePozycjaBudzetu(Convert.ToInt32(tbProductsId.Value), Convert.ToInt32(ddlKategorieWyd.SelectedItem.Value), Convert.ToInt32(tbShopId.Value), Convert.ToDecimal(tbPrice.Text), Convert.ToDateTime(tbPurchaseDate.Text), Convert.ToInt32(tbQuantity.Text), tbAddInfo.Text);
    }
}