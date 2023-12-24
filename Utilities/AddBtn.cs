using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calendar.Utilities
{
    public class AddBtn : Button
    {

        static AddBtn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddBtn), new FrameworkPropertyMetadata(typeof(AddBtn)));
        }




    }
}