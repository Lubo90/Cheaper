using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudgetsModel
/// </summary>
public class BudgetsModel
{
	public BudgetsModel()
	{
        
	}

    public int BudgetID { get; set; }
    public string BudgetName { get; set; }
    public DateTime CreationDate { get; set; }
    public decimal LastMonthExpenses { get; set; }
    public decimal LastYearExpenses { get; set; }
}