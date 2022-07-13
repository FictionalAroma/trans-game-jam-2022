using System.ComponentModel;

namespace DataLib.DataValues
{
    public enum Gender
    {

    }

    public enum CharacterTraits
    {

    }

    public enum Sexuality
    {
        [Description(""), ]
        Straight,
        Gay,
        Yes,
        No,
    }

    public enum TimeslotType
    {

        EarlyMorning,
        WorkAM,
        Lunchtime,
        WorkPM,
        Evening,
        Night,
        DayOffMorning,
        DayOffAfternoon,
        LateNight,
    }


}