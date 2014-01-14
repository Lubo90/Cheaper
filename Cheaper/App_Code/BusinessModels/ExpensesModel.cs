﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpensesModel
/// </summary>
public class ExpensesModel
{
    public ExpensesModel()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public decimal? Balance { get; set; }
}