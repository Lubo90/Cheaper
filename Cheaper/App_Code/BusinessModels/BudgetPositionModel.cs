using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudgetDetailsModel
/// </summary>
public class BudgetPositionModel
{
	public BudgetPositionModel()
	{

	}
    public string ProductName { get; set; }

    public long PositionID { get; set; }
    public decimal Price { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public string PurchaseDateString
    {
        get
        {
            if(!PurchaseDate.HasValue)
                return string.Empty;

            return string.Format("{0} {1} {2}", PurchaseDate.Value.Day.ToString(),
                Converters.GetMonthAsString(PurchaseDate.Value.Month),
                PurchaseDate.Value.Year);
        }
    }
    public decimal Quantity { get; set; }
    public decimal Wartosc
    {
        get
        {
            return (decimal)Price * Quantity;
        }
    }
    public decimal RoznicaCeny { get; set; }
    public decimal SredniaCena { get; set; }
    public string AddInfo { get; set; }

    public string ExpenseCatName { get; set; }

    public string ShopFriendlyName { get; set; }
    public string ShopStreet { get; set; }
    public string ShopCity { get; set; }
    public string ShopPostCode { get; set; }
}