using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudzetPresenter
/// </summary>
public class BudzetPresenter
{
    private IBudzetView _view;

	public BudzetPresenter(IBudzetView view)
	{
        _view = view;
	}
}