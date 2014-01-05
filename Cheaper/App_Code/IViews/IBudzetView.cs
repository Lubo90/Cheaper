using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IBudzetView
{
    List<BudgetsModel> BudgetsRepaterDataSource { set; }
    string UserName { get; }
    BudgetMultiViewContent ActiveView { set; }
    string BudgetDate { set; }
    void SaveBudzet(string nazwaBudzetu);
}