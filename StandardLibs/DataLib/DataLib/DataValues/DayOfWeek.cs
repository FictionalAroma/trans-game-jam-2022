using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.DataValues
{
    public interface IGameDay
    {
        public DayOfWeek DayOfWeek { get; set; }

        public List<TimeslotType> Timeslots { get; set; }
    }
}
