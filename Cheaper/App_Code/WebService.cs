using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[System.Web.Script.Services.ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    ICheaperService service;

    public WebService()
    {
        service = new CheaperService();

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public string UserName
    {
        get
        {
            if (Session["UserLogin"] is string)
                return Session["UserLogin"].ToString();
            else
                return string.Empty;
        }
    }

    public bool IsLoggedIn
    {
        get
        {
            if (Session["UserLoggedIn"] is bool)
                return (bool)Session["UserLoggedIn"];
            else
                return false;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] ProductsAutocomplete(object danePrzeslane)
    {
        try
        {
            return service.GetProductsAutocomplete(danePrzeslane.ToString(), UserName);
        }
        catch (Exception ex)
        {
            service.LogEvent("ProductsAutocomplete", ex, UserName);
            return null;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] ShopsAutocomplete(object danePrzeslane)
    {
        try
        {
            return service.GetShopsAutocomplete(danePrzeslane.ToString(), UserName);
        }
        catch (Exception ex)
        {
            service.LogEvent("ProductsAutocomplete", ex, UserName);
            return null;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool AuthorizeUser(string loginData)
    {
        try
        {
            string[] dane = loginData.Split(new string[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

            if (dane.Count() != 2)
                return false;

            if (service.CheckUserAuthentication(dane[0], dane[1]))
            {
                Session["UserLogin"] = dane[0];
                Session["UserLoggedIn"] = true;
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            service.LogEvent("AuthorizeUser", ex, UserName);
            return false;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string RegisterUser(object login, object password, object email, object birthDate)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(login.ToString()) || login.ToString().Length < 4)
                return "login";
            if (string.IsNullOrWhiteSpace(password.ToString()))
                return "pw";
            if (string.IsNullOrWhiteSpace(email.ToString()) || !Regex.IsMatch(email.ToString(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
                return "email";
            var isMatch = Regex.IsMatch(birthDate.ToString(), @"[12]{1}\d{1}\d{1}\d{1}-[01]?\d{1}-[01]?\d{1}");
            if (string.IsNullOrWhiteSpace(birthDate.ToString()) || !isMatch)
                return "birthDate";

            if (service.RegisterNewUser(login.ToString(), password.ToString(), email.ToString(), Convert.ToDateTime(birthDate)))
                return "ok";
            else
                return "error";
        }
        catch (Exception ex)
        {
            service.LogEvent("RegisterUser", ex, UserName);
            return "error";
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool ValidateUsername(object login)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(login.ToString()))
                return false;

            return service.IsUsernameAvailable(login.ToString());
        }
        catch (Exception ex)
        {
            service.LogEvent("DodajBudzet", ex, UserName);
            return false;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool ValidateEmail(object email)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email.ToString()))
                return false;

            if (Regex.IsMatch(email.ToString(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            service.LogEvent("ValidateEmail", ex, UserName);
            return false;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool ValidateBirthDate(object birthDate)
    {
        try
        {
            var bdate = Convert.ToDateTime(birthDate);
            return true;
        }
        catch (InvalidCastException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
        catch (Exception ex)
        {
            service.LogEvent("ValidateBirthDate", ex, UserName);
            return false;
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool DodajBudzet(object nazwaBudzetu)
    {
        try
        {
            if (IsLoggedIn)
                return service.DodajBudzet(nazwaBudzetu.ToString(), UserName, DateTime.Now);
            else
                return false;
        }
        catch (Exception ex)
        {
            service.LogEvent("DodajBudzet", ex, UserName);
            return false;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool DodajProdukt(object nazwaProduktu, object idKategorii)
    {
        if (IsLoggedIn)
        {
            try
            {
                var id = Convert.ToInt16(idKategorii);
                return service.DodajProdukt(nazwaProduktu.ToString(), id, UserName);
            }
            catch (Exception ex)
            {
                service.LogEvent("DodajProdukt", ex, UserName);
                return false;
            }
        }
        else
            return false;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool ZmienKwoteKatWyd(object kwota, object idKatWyd)
    {
        if (IsLoggedIn)
        {
            try
            {
                var id = Convert.ToInt32(idKatWyd);
                var decKwota = Convert.ToDecimal(kwota);
                return service.ChangeKwotaKatWyd(decKwota, id, UserName);
            }
            catch (Exception ex)
            {
                service.LogEvent("ZmienKwoteKatWyd", ex, UserName);
                return false;
            }
        }
        else
            return false;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool DodajKatWyd(object nazwaKat, object kwotaKat)
    {
        if (IsLoggedIn)
        {
            try
            {
                var nazwa = nazwaKat.ToString();
                var kwota = Convert.ToDecimal(kwotaKat);

                return service.DodajKatWyd(nazwa, kwota, UserName);
            }
            catch (Exception ex)
            {
                service.LogEvent("DodajKatWyd", ex, UserName);
                return false;
            }
        }
        else
            return false;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool DodajSklep(object przyjaznaNazwa, object ulica, object miasto, object kodPocztowy)
    {
        if (IsLoggedIn)
        {
            try
            {
                var friendlyName = przyjaznaNazwa.ToString();
                var street = ulica.ToString();
                var city = miasto.ToString();
                var postCode = kodPocztowy.ToString();

                return service.DodajSklep(friendlyName, street, city, string.IsNullOrEmpty(postCode) ? null : postCode, UserName);
            }
            catch (Exception ex)
            {
                service.LogEvent("DodajSklep", ex, UserName);
                return false;
            }
        }
        else
            return false;
    }
}