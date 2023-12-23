using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calendar.Model;

namespace Calendar.ViewModel
{
    class HomeVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public HomeVM()
        {
            _pageModel = new PageModel();
        }
    }
}
