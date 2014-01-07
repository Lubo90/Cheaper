﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum LoggingMultiViewContent : int { LoggingForm = 0, UserGreetings };
public enum BudgetMultiViewContent : int { BudgetList = 0, NewBudget };

public static class GETValueIdentifiers
{
    public const string PAGE = "p";
    public const string ID = "id";
}

public static class GET_PAGEIdentifiers
{
    public const string LIST = "list";
    public const string NOWY_BUDZET = "new";
}