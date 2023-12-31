﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar.View
{
    /// <summary>
    /// Interaction logic for MyTask.xaml
    /// </summary>
    public partial class MyTask : UserControl
    {
        public MyTask()
        {
            InitializeComponent();
            SetDefaultDay();
        }
        void SetDefaultDay()
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.Local);
            datePicker.SelectedDate = localTime.DateTime;
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
