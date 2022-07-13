using System;
using DataLib.GameDataModels;
using ModTool.Attributes;

namespace ModTool.Data.DataObjects
{
    [Serializable]
    public class CharacterData : BaseData, ICharacter
    {
        private string _characterImagePath;
        private string _characterHeadline;
        private string _pronoun2;
        private string _pronoun1;
        private string _lastName;
        private string _firstName;

        private int _age;
        private bool _dateable;

        private string _favouritePie;
        private string _characterFullDescription;

        [FormBind("First Name")] 
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value; 
                OnPropertyChanged();
            }
        }

        [FormBind("Last Name")] 
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();

            }
        }

        [FormGroup("pronouns")]
        [FormBind("He/She/They")]
        public string Pronoun1
        {
            get => _pronoun1;
            set
            {
                _pronoun1 = value;
                OnPropertyChanged();

            }
        }

        [FormGroup("pronouns")]
        [FormBind("Him/Her/They")]
        public string Pronoun2
        {
            get => _pronoun2;
            set
            {
                _pronoun2 = value;
                OnPropertyChanged();
            }
        }

        [FormBind("Full Description", componentType: ComponentType.RichText)]
        public string CharacterFullDescription
        {
            get => _characterFullDescription;
            set
            {
                _characterFullDescription = value;
                OnPropertyChanged();
            }
        }


        [FormBind("Character Introduction Text", "Text to be displayed on First Meet and on character list")]
        public string CharacterHeadline
        {
            get => _characterHeadline;
            set
            {
                _characterHeadline = value;
                OnPropertyChanged();
            }
        }

        [AddToSelectionList(DisplayType.Image)]
        [FormBind("Image File Path", componentType: ComponentType.ImageFilePath)]
        public string CharacterImagePath
        {
            get => _characterImagePath;
            set
            {
                _characterImagePath = value;
                OnPropertyChanged();
            }
        }

        [FormBind("Favourite Pie")]
        public string FavouritePie
        {
            get => _favouritePie;
            set { _favouritePie = value; OnPropertyChanged();
            }
        }

        [FormBind("Age")]
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(); }
        }

        [FormBind("Is Dateable")]
        public bool Dateable
        {
            get => _dateable;
            set
            {
                OnPropertyChanged();
                _dateable = value; }
        }
    }
}
