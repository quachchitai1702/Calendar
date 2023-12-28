using Calendar.Model;
using Calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    /// 

    public partial class Calendar : UserControl
    {
        #region Peoperties
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private List<string> dateOfWeek = new List<string>{ "Monday", "Tuesday", "Wenesday", "Thursday", "Friday", "Saturday", "Sunday" };


        #endregion

        public Calendar()
        {
            InitializeComponent();

            LoadMatrix();
        }

        int DayOfColumn = 7;
        int DayOfWeek = 6;

        int dateButtonWidth = 50;
        int dateButtonHeight = 50;


        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            for (int i = 0; i < DayOfWeek; i++)
            {
                Matrix.Add(new List<Button>());

                for (int j = 0; j < DayOfColumn; j++)
                {
                    Button btn = new Button
                    {
                        Width = dateButtonWidth,
                        Height = dateButtonHeight,
                        Style = (Style)FindResource("earch_DayButton")
                    };

                    Grid.SetColumn(btn, j);
                    Grid.SetRow(btn, i);

                    Matrix[i].Add(btn);

                    gridMatrix.Children.Add(btn);
                }
            }

            SetDefaultDay();
        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if ((date.Year % 4 == 0) && (date.Year % 100 == 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 0;
            }
        }

        void AddNumberIntoMatrixByDate(DateTime date)
        {
            ClearMatrix();

            DateTime useDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
            int line = 0;

            for (int i = 0; i < DayOfMonth(date); i++)
            {
                int column = ((int)useDate.DayOfWeek + 6) % 7; // Adjust for zero-based index

                if (column >= 0 && column < DayOfColumn && line >= 0 && line < DayOfWeek)
                {
                    Button btn = Matrix[line][column];
                    btn.Content = (i + 1).ToString(); // Hiển thị số ngày                    

                    SolidColorBrush backgroundColor = Brushes.White; // Mặc định là trắng

                    if (isEqualDate(useDate, DateTime.Now.Date))
                    {
                        backgroundColor = new SolidColorBrush(Color.FromArgb(255, 151, 71, 255)); // Màu nền cho ngày hiện tại
                        btn.Foreground = Brushes.Black; 
                    }

                    btn.Background = backgroundColor;
                }

                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);
            }
        }



        bool isEqualDate(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }


        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Content = "";
                    btn.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)); // Đặt màu nền trắng
                }
            }
        }



        void SetDefaultDay()
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.Local);
            datePicker.SelectedDate = localTime.DateTime;
        }


        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            AddNumberIntoMatrixByDate(datePicker.SelectedDate ?? DateTime.UtcNow);
        }


        private void next_Month_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = datePicker.SelectedDate.Value;
                DateTime nextMonth = selectedDate.AddMonths(1);
                datePicker.SelectedDate = nextMonth;
            }
        }

        private void pre_Month_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = datePicker.SelectedDate.Value;
                DateTime previousMonth = selectedDate.AddMonths(-1);
                datePicker.SelectedDate = previousMonth;
            }
        }

        private void todaySet_Calendar_btn_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultDay();
        }
    }


}



