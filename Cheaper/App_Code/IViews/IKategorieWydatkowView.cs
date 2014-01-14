using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IKategorieWydatkowView
/// </summary>
public interface IKategorieWydatkowView : IView
{
    List<ExpensesModel> RepeaterDataSource { set; }
}