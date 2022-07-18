using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DataLib.DataValues;
using ModTool.Annotations;
using ModTool.Data.DataObjects;
using Newtonsoft.Json;

namespace ModTool.Data
{
    public class ModToolDataLibrary : INotifyPropertyChanged
    {
        private string _name;

        private FormDataList<CharacterData> _characters;
        private FormDataList<LocationData> _locations;

        private FormDataList<GameDayData> _daysOfWeek;
        private FormDataList<TimeslotData> _timeslots;

        public FormDataList<CharacterData> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        public FormDataList<LocationData> Locations
        {
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        public string Name { get => _name; set => _name = value; }

        public FormDataList<GameDayData> DaysOfWeek
        {
            get => _daysOfWeek;
            set { _daysOfWeek = value; OnPropertyChanged();}
        }

        public FormDataList<TimeslotData> Timeslots { get => _timeslots; set => _timeslots = value; }

        public ModToolDataLibrary()
        {
            _characters = new FormDataList<CharacterData>();
            _locations = new FormDataList<LocationData>();
        }

        public static ModToolDataLibrary CreateDefault()
        {
            var newLib = new ModToolDataLibrary()
            {
                Name = "Default",
            };
            InsertDefaultData(newLib);

            return newLib;
        }

        public static void InsertDefaultData(ModToolDataLibrary lib)
        {
            if (!lib.Characters.Any())
            {
                lib.Characters.AddItem(new CharacterData { EntityName = "Lucy", CharacterHeadline = "The Coder", FirstName = "Lucy" });
                lib.Characters.AddItem(new CharacterData
                    { EntityName = "Justin", CharacterHeadline = "Writer", FirstName = "Justin" });

            }

            if (lib.Timeslots.Any())
            {
                foreach (var timeslot in Enum.GetValues<TimeslotType>())
                {
                    lib.Timeslots.AddItem(new TimeslotData()
                    {
                        EntityName = timeslot.ToString(), DisplayText = timeslot.ToString(), TimeslotType = timeslot
                    });
                }
            }

            if (!lib.DaysOfWeek.Any())
            {
                var timeslotTypes = Enum.GetValues<TimeslotType>();
                foreach (var day in Enum.GetValues<DayOfWeek>())
                {
                    lib.DaysOfWeek.AddItem(new GameDayData(){DayOfWeek = day, EntityName = day.ToString(), Timeslots = timeslotTypes.ToList() });
                }
            }

            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
