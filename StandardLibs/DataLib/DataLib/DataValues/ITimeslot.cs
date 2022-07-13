using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.DataValues
{
    public interface ITimeslot
    {
        public TimeslotType TimeslotType { get; set; }
        public string ImageFilePath { get; set; }
    }
}
