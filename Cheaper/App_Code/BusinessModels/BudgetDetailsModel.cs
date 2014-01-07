using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudgetDetailsModel
/// </summary>
public class BudgetDetailsModel
{
	public BudgetDetailsModel()
	{

	}
    public string ProductName { get; set; }

    public long PositionID { get; set; }
    public decimal Price { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public int Quantity { get; set; }
    public string AddInfo { get; set; }

    public string ExpenseCatName { get; set; }

    public string ShopFriendlyName { get; set; }
    public string ShopStreet { get; set; }
    public string ShopCity { get; set; }
    public string ShopPostCode { get; set; }
}