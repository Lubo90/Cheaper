using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IBudzetView : IView
{
    List<BudgetsModel> RepeaterDataSource { set; }
    BudgetMultiViewContent ActiveView { set; }
    string BudgetDate { set; }
    void SaveBudzet(string nazwaBudzetu);
}