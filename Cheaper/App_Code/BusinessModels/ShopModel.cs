using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShopsModel
/// </summary>
public class ShopModel
{
	public ShopModel()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string FriendlyName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
}