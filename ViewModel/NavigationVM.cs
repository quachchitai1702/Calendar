using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Utilities;
using System.Windows.Input;

namespace Calendar.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand CalendarCommand { get; set; }
        public ICommand MyTaskCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Calendar(object obj) => CurrentView = new CalendarVM();
        private void MyTask(object obj) => CurrentView = new MyTaskVM();


        public NavigationVM()
        {
            //Startup Page
            CurrentView = new HomeVM();

            HomeCommand = new RelayCommand(Home);
            CalendarCommand = new RelayCommand(Calendar);
            MyTaskCommand = new RelayCommand(MyTask);
        }
    }
}
