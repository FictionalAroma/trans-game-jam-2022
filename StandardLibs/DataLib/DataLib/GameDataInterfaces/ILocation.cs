using System;
using System.Collections.Generic;
using System.Text;
using DataLib.DataValues;

namespace DataLib.GameDataInterfaces
{
    public interface ILocation
    {
        string LocationName { get; set; }
        string Description { get; set; }
        string LogoImagePath { get; set; }
        IEnumerable<DayOfWeek> OpenDays { get; }
        IEnumerable<TimeslotType> OpenTimeslots { get; }
    }
}
