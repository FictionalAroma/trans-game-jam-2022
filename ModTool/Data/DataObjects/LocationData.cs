using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DataLib.DataValues;
using DataLib.GameDataInterfaces;
using ModTool.Attributes;
using Newtonsoft.Json;

namespace ModTool.Data.DataObjects
{
    public class LocationData : BaseData, ILocation
    {
        private string _locationName;
        private string _description;
        private string _logoImagePath;
        private ObservableCollection<DayOfWeek> _openDaysBinding;
        private ObservableCollection<TimeslotType> _openTimeslotsBinding;

        [FormBind("Location Name")]
        public string LocationName { get => _locationName; set => _locationName = value; }

        [FormBind("Location Full Description", componentType: ComponentType.RichText)]
        public string Description { get => _description; set => _description = value; }

        [FormBind("Location Icon", componentType: ComponentType.ImageFilePath)]
        public string LogoImagePath { get => _logoImagePath; set => _logoImagePath = value; }

        [JsonIgnore]
        [FormBind("Days of Week Open", componentType: ComponentType.MultiSelectSetList)]
        public ObservableCollection<DayOfWeek> OpenDaysBinding
        {
            get => _openDaysBinding;
            set { _openDaysBinding = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        [FormBind("Days of Week Open")]
        public ObservableCollection<TimeslotType> OpenTimeslotsBinding
        {
            get => _openTimeslotsBinding;
            set
            {
                _openTimeslotsBinding = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<DayOfWeek> OpenDays => OpenDaysBinding.ToList();

        public IEnumerable<TimeslotType> OpenTimeslots => OpenTimeslotsBinding.ToList();
    }
}
