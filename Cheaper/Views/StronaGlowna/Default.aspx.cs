using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Cheaper.Presenters;

public partial class _Default : System.Web.UI.Page, IStronaGlownaView
{
    private StronaGlownaPresenter _presenter;

    public object UsersRepaterDataSource
    {
        set
        {
            if (value is List<UsersModel>)
            {
                rptrUsers.DataSource = value;
                rptrUsers.DataBind();
            }
            else
                throw new TypeLoadException("Niepoprawny typ obiektu");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new StronaGlownaPresenter(this);
        _presenter.InitView(Page.IsPostBack);
    }
}