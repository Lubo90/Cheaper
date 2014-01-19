﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IBudzetView : IView
{
    List<BudgetsModel> RepeaterDataSource { set; }
    decimal SumaWydatkowRok { set; }
    decimal SumaWydatkowMsc { set; }
    int SumaPozycji { set; }
}