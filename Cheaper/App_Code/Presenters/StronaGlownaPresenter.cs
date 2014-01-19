using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cheaper.Presenters
{
    /// <summary>
    /// Summary description for StronaGlownaPresenter
    /// </summary>
    public class StronaGlownaPresenter
    {
        private ICheaperService _service;
        private IStronaGlownaView _view;

        public StronaGlownaPresenter(IStronaGlownaView view)
        {
            _view = view;
            _service = new CheaperService();
        }

        /// <summary>
        /// Metoda ładująca dane dla widoku.
        /// </summary>
        /// <param name="isPostBack">Określa, czy to pierwsze wczytanie strony. Jeśli tak, wczytuje dane.</param>
        public void InitView(bool isPostBack)
        {
            //if(isPostBack)
            //return;

            //_view.UsersRepaterDataSource = _service.GetUsers();
        }
    }
}