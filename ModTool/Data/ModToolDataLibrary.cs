using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModTool.Annotations;
using ModTool.Data.DataObjects;
using Newtonsoft.Json;

namespace ModTool.Data
{
    public class ModToolDataLibrary : INotifyPropertyChanged
    {
        private FormDataList<CharacterData> _characters;
        private FormDataList<LocationData> _locations;
        private string _name;

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

        public ModToolDataLibrary()
        {
            _characters = new FormDataList<CharacterData>();
            _locations = new FormDataList<LocationData>();
        }

        public static ModToolDataLibrary CreateDefault()
        {
            return new ModToolDataLibrary()
            {
                Name = "Default",
                Characters = new FormDataList<CharacterData>()
                {
                    new CharacterData { EntityName = "Lucy", CharacterHeadline = "The Coder", FirstName = "Lucy" },
                    new CharacterData { EntityName = "Justin", CharacterHeadline = "Writer", FirstName = "Justin" }

                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
