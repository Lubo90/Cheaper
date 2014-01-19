using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for INowaPozycjaBudzetu
/// </summary>
public interface INowaPozycjaBudzetu : IView
{
    Dictionary<int, string> DdlKategorieDataSource { set; }
    Dictionary<int, string> DllKategorieWydDataSource { set; }
    string BudgetName { set; }
    bool HasKategorieWydatkow { get; set; }
    bool CanView { get; set; }
}