using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IShops
/// </summary>
public interface ISklepView : IView
{
    List<ShopModel> RepeaterDataSource { set; }
}