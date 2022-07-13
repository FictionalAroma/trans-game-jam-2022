using System;
using System.Collections.Generic;
using System.Text;
using DataLib.GameDataModels;

namespace DataLib
{
    public class DataLibrary 
    {
        private List<ICharacter> _characters;
        public List<ICharacter> Characters { get => _characters; set => _characters = value; }
    }

}
