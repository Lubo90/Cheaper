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
    public class MasterPagePresenter
    {
        private IMasterPageView _view;
        private ICheaperService _service;

        public MasterPagePresenter(IMasterPageView view)
        {
            _view = view;
            _service = new CheaperService();
        }

        public void InitView(bool isPostBack)
        {
            SetViewGreetingsData();
        }

        public void SetViewGreetingsData()
        {
            if (_view.SnLoggedIn)
                _view.SwitchMultiViewActiveView(LoggingMultiViewContent.UserGreetings);
            else
                _view.SwitchMultiViewActiveView(LoggingMultiViewContent.LoggingForm);

            _view.SetUsernameGreetingText();
        }

        public void AuthenticateUser(string login, string pw)
        {
            if (_service.CheckUserAuthentication(login, pw))
            {
                _view.SnLoggedIn = true;
                _view.SnUserLogin = login;
            }

            SetViewGreetingsData();
        }
    }
}