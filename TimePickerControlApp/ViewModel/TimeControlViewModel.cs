using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace TimePickerControlApp.ViewModel
{
    /// <summary>
    /// TimeControlViewModel class is for handling all the functionality of TimePicker Control.
    /// </summary>
    public class TimeControlViewModel : INotifyPropertyChanged
    {
        #region Constructor 
        public TimeControlViewModel()
        {
            IsPopupOpen = false;
            TimePickCommand = new DelegateCommand<object>(ExecuteTimePickerCommand);
            DoneCommand = new DelegateCommand<object>(ExecuteDoneCommand);
            CloseCommand = new DelegateCommand<object>(ExecuteCloseCommand);
            Is12HourClock = false;  
            LoadTimeData();
        }
        #endregion

        #region Private Fields
        private ObservableCollection<string> _AMPM = new ObservableCollection<string>();
        private ObservableCollection<int> _hours = new ObservableCollection<int>();
        private ObservableCollection<int> _minutes = new ObservableCollection<int>();
        private string _timeText = "Select Time";
        private int _selectedHour = -1;
        private int _selectedMin = -1;
        private string _selectedAMPM;
        private int _selectedIndexAMPM;
        private bool _is12HourClock;
        private bool _isPopupOpen;
        #endregion

        #region Public Properties

        /// <summary>
        /// Selected Hour
        /// </summary>
        public int SelectedHour
        {
            get => _selectedHour;
            set
            {
                if (_selectedHour != value)
                {
                    _selectedHour = value;
                    SelectionChanged(HoursList, _selectedHour);
                    RaisePropertyChanged(nameof(SelectedHour));
                }
            }
        }

        /// <summary>
        /// Selected Minute
        /// </summary>
        public int SelectedMin
        {
            get => _selectedMin;
            set
            {
                if (_selectedMin != value)
                {
                    _selectedMin = value;
                    SelectionChanged(MinutesList, _selectedMin);
                    RaisePropertyChanged(nameof(SelectedMin));
                }
            }
        }

        /// <summary>
        /// Selected AM/PM
        /// </summary>
        public string SelectedAMPM
        {
            get => _selectedAMPM;
            set
            {
                _selectedAMPM = value;
                ScrollToCenterAmPM(_selectedAMPM);
                RaisePropertyChanged(nameof(SelectedAMPM));
            }
        }

        /// <summary>
        /// Selected index for AM/PM
        /// </summary>
        public int SelectedIndexAMPM
        {
            get => _selectedIndexAMPM;
            set
            {
                _selectedIndexAMPM = value;
                RaisePropertyChanged(nameof(SelectedIndexAMPM));
            }
        }

        /// <summary>
        /// Time format
        /// </summary>
        public bool Is12HourClock
        {
            get => _is12HourClock;
            set
            {
                _is12HourClock = value;
                RaisePropertyChanged(nameof(Is12HourClock));
            }
        }

        /// <summary>
        /// Open popup, when true.
        /// </summary>
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                RaisePropertyChanged(nameof(IsPopupOpen));
            }
        }

        /// <summary>
        /// Collection for Hour list.
        /// </summary>
        public ObservableCollection<int> Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                RaisePropertyChanged("Hours");
            }
        }

        /// <summary>
        /// Collection for AM/PM list
        /// </summary>
        public ObservableCollection<string> AMPM
        {
            get => _AMPM;
            set
            {
                _AMPM = value;
                RaisePropertyChanged("AMPM");
            }
        }

        /// <summary>
        /// Collection for Minute list.
        /// </summary>
        public ObservableCollection<int> Minutes
        {
            get => _minutes;
            set
            {
                _minutes = value;
                RaisePropertyChanged("Minutes");
            }
        }
        public List<int> HoursList { get; set; } = new List<int>();

        public List<int> MinutesList { get; set; } = new List<int>();

        /// <summary>
        /// Property for selected time.
        /// </summary>
        public string TimeText
        {
            get => _timeText;
            set
            {
                _timeText = value;
                MapTextToTime(_timeText);
                RaisePropertyChanged(nameof(TimeText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<object> TimePickCommand { get; set; }
        public DelegateCommand<object> DoneCommand { get; set; }
        public DelegateCommand<object> CloseCommand { get; set; }

        #endregion

        #region Private Methods
        // Method to be executed on Done Command.
        private void ExecuteDoneCommand(object obj)
        {
            TimeText = SelectedHour.ToString("00") + ":" + SelectedMin.ToString("00");
            if (Is12HourClock)
                TimeText = TimeText + " " + SelectedAMPM;
            IsPopupOpen = false;
        }

        
        /// <summary>
        /// This method is for closing the popup
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteCloseCommand(object obj)
        {
            IsPopupOpen = false;
        }

        /// <summary>
        /// This method is for the alignment of AM/PM to the center.
        /// </summary>
        /// <param name="selectedValue"></param>
        private void ScrollToCenterAmPM(string selectedValue)
        {
            int currentIndex = AMPM.IndexOf(selectedValue);
            if (currentIndex > 0)
            {
                AMPM.RemoveAt(currentIndex);
                AMPM.Insert(0, selectedValue);
            }
            SelectedIndexAMPM = 0;
        }

        /// <summary>
        /// SelectionChanged method get called if hour list or minute list item selection is changed.
        /// also this method will move the selected item to the center of list.
        /// </summary>
        /// <param name="list">Hours list or minute list</param>
        /// <param name="selectedValue">Selected value</param>
        private void SelectionChanged(List<int> list, int selectedValue)
        {
            int selectedIndex;
            List<int> newList = new List<int>();

            if (list.Count < 25)
                selectedIndex = HoursList.IndexOf(selectedValue);
            else
                selectedIndex = MinutesList.IndexOf(selectedValue);

            if (selectedIndex == 0)
            {
                CirculateItems(0, new List<int> { list[list.Count - 2], list[list.Count - 1] }, list.Count, 2);
            }
            else if (selectedIndex == 1)
            {
                CirculateItems(0, new List<int> { list[list.Count - 1] }, list.Count, 1);
            }
            else if (selectedIndex == list.Count - 2)
            {
                CirculateItems(list.Count, new List<int> { list[0] }, 0, 1);
            }
            else if (selectedIndex == list.Count - 1)
            {
                CirculateItems(list.Count, new List<int> { list[0], list[1] }, 0, 2);
            }

            void CirculateItems(int insertPos, List<int> insertRange, int removePos, int removeCount)
            {
                list.InsertRange(insertPos, insertRange);
                list.RemoveRange(removePos, removeCount);
            }
            if (list.Count < 25)
            {
                HoursList = list;
                selectedIndex = HoursList.IndexOf(selectedValue);
                for (int i = selectedIndex - 2; i <= selectedIndex + 2; i++)
                {
                    newList.Add(HoursList[i]);
                }
                Hours = new ObservableCollection<int>(newList);
            }
            else
            {
                MinutesList = list;
                selectedIndex = MinutesList.IndexOf(selectedValue);
                for (int i = selectedIndex - 2; i <= selectedIndex + 2; i++)
                {
                    newList.Add(MinutesList[i]);
                }
                Minutes = new ObservableCollection<int>(newList);
            }
        }

        /// <summary>
        /// This method is for instering value to the HoursList,MinutesList and AMPM list.
        /// </summary>
        private void LoadTimeData()
        {
            string time = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern, CultureInfo.CurrentCulture);
            int _hr = 23;
            int index = 0;
            if (time.Contains("AM") || time.Contains("PM"))
            {
                _hr = 12;
                index = 1;
                Is12HourClock = true;
            }
            for (int i = index; i <= _hr; i++)
            {
                Hours.Add(i);
                HoursList.Add(i);
            }

            for (int i = 0; i <= 59; i++)
            {
                Minutes.Add(i);
                MinutesList.Add(i);
            }

            AMPM.Add("AM");
            AMPM.Add("PM");
        }

        /// <summary>
        /// This method is invoked when Timepicker command is fired.
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteTimePickerCommand(object obj)
        {
            if (TimeText != "Select Time")
                MapTextToTime(TimeText);
            else
                MapTextToTime(DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern, CultureInfo.CurrentCulture));
            IsPopupOpen = true;
        }

        /// <summary>
        /// Fire Property change event.
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This method maps text to time properties.
        /// </summary>
        /// <param name="timeText">Selected time as text</param>
        private void MapTextToTime(string timeText)
        {
            try
            {
                DateTime time = DateTime.Parse(timeText);
                if (timeText.Contains("AM") || timeText.Contains("PM"))
                {
                    if (time.Hour > 12 || time.Hour == 0)
                        SelectedHour = Math.Abs(time.Hour - 12);
                    else
                        SelectedHour = time.Hour;
                    SelectedAMPM = timeText.Contains("AM") ? "AM" : "PM";
                }
                else
                {
                    SelectedHour = time.Hour;
                }
                SelectedMin = time.Minute;
            }
            catch(FormatException)
            {

            }
        }
        
        #endregion
    }
}
