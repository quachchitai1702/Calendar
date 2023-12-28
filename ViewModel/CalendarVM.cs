using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Calendar.Model;

namespace Calendar.ViewModel
{
    class CalendarVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public CalendarVM()
        {
            _pageModel = new PageModel();
        }

        
    }
}
