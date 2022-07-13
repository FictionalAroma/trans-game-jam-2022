using System;

namespace ModTool.Attributes;

public class AddToSelectionList : Attribute
{
    public AddToSelectionList(DisplayType type = DisplayType.Standard)
    {

    }
}

public enum DisplayType
{
    Standard,
    Image
}