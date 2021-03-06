﻿using System;
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

    public string BudgetName
    {
        set
        {
            this.lblBudgetName.Text = value;
        }
    }

    public bool HasKategorieWydatkow { get; set; }

    public bool CanView { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new NowaPozycjaBudzetuPresenter(this);
        _presenter.InitView(this.IsPostBack);
    }

    protected void btnSavePozycja_Click(object sender, EventArgs e)
    {
        int? shopId;
        if(string.IsNullOrWhiteSpace(tbShopId.Value))
            shopId = null;
        else
            shopId = Convert.ToInt32(tbShopId.Value);

        _presenter.SavePozycjaBudzetu(Convert.ToInt32(tbProductsId.Value),
            Convert.ToInt32(ddlKategorieWyd.SelectedItem.Value),
            shopId,
            Convert.ToDecimal(tbPrice.Text),
            Convert.ToDateTime(tbPurchaseDate.Text),
            Convert.ToDecimal(tbQuantity.Text),
            tbAddInfo.Text);
    }
}