﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBudzetDetailsView
/// </summary>
public interface IBudzetDetailsView : IView
{
    string BudgetName { set; }
    List<BudgetDetailsModel> RepeaterDataSource { set; }
}