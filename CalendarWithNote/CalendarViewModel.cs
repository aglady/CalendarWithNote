using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarWithNote
{
    internal class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime currentMonth;
        private List<DateModel> dates;
        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarViewModel()
        {
            currentMonth = DateTime.Now;
            LoadCalendar();
        }

        public DateTime CurrentMonth
        {
            get { return currentMonth; }
            set
            {
                currentMonth = value;
                LoadCalendar();
                OnPropertyChanged(nameof(CurrentMonth));
            }
        }

        public string DisplayMonth => CurrentMonth.ToString("MMMM yyyy");
        public List<DateModel> Dates
        {
            get { return dates; }
            set
            {
                dates = value;
                OnPropertyChanged(nameof(Dates));
            }
        }
        private void LoadCalendar()
        {
            var daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            //var startDay = new DateTime(currentMonth.Year, currentMonth.Month, 1).DayOfWeek;

            var calendarDates = new List<DateModel>();
            
            for (var day = 1; day <= daysInMonth; day++)
            {
                var date = new DateModel()
                {
                    Day = new DateTime(currentMonth.Year, currentMonth.Month, day),
                   //WeekDay = (DayOfWeek)(((int)startDay + day - 1) % 7)
                };
                calendarDates.Add(date);
            }
            Dates = calendarDates;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
