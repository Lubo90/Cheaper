using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Converters
/// </summary>
public static class Converters
{
    public static string GetMonthAsString(int month)
    {
        switch (month)
        {
            case 1:
                return "stycznia";
            case 2:
                return "lutego";
            case 3:
                return "marca";
            case 4:
                return "kwietnia";
            case 5:
                return "maja";
            case 6:
                return "czerwca";
            case 7:
                return "lipca";
            case 8:
                return "sierpnia";
            case 9:
                return "września";
            case 10:
                return "października";
            case 11:
                return "listopada";
            case 12:
                return "grudnia";
            default:
                return string.Empty;
        }
    }

    public static string GetColorBasedOnDecimal(object balance, string positiveColor = "black", string negativeColor = "red")
    {
        var convBalance = Convert.ToDecimal(balance);
        if (convBalance < 0)
            return string.Format("color: {0};", negativeColor);
        else
            return string.Format("color: {0};", positiveColor);
    }
}