using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.GameDataInterfaces
{
    public interface ILocation
    {
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string LogoImagePath { get; set; }

    }
}
