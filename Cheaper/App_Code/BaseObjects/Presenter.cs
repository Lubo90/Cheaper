using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaseView
/// </summary>
public class BasePresenter<T> where T : IView
{
    protected T _view;

    public BasePresenter(T view)
    {
        _view = view;
    }

    protected bool IsLoggedIn
    {
        get { return _view.IsLoggedIn; }
    }
}