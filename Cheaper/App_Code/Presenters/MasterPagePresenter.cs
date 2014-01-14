using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cheaper.Presenters
{
    /// <summary>
    /// Summary description for MasterPagePresenter
    /// </summary>
    public class MasterPagePresenter : BasePresenter<IMasterPageView>
    {
        private ICheaperService _service;

        public MasterPagePresenter(IMasterPageView view)
            : base(view)
        {
            _service = new CheaperService();
        }

        public void InitView(bool isPostBack)
        {
            SetViewGreetingsData();
        }

        public void SetViewGreetingsData()
        {
            if (_view.IsLoggedIn)
                _view.SwitchMultiViewActiveView(LoggingMultiViewContent.UserGreetings);
            else
                _view.SwitchMultiViewActiveView(LoggingMultiViewContent.LoggingForm);

            if (_view.IsLoggedIn)
                _view.LabelUserName = _view.UserName;
        }

        public void AuthenticateUser(string login, string pw)
        {
            if (_service.CheckUserAuthentication(login, pw))
            {
                _view.IsLoggedIn = true;
                _view.UserName = login;
            }

            SetViewGreetingsData();
        }

        public void LogUserOut()
        {
            _view.IsLoggedIn = false;
            _view.UserName = null;

            _view.RedirectTo("~/Views/StronaGlowna/Default.aspx", true);
        }
    }
}