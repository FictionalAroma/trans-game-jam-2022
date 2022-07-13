using System;

namespace ModTool.Attributes
{
    public class FormGroup : Attribute
    {
        public string GroupName { get; }

        public FormGroup(string groupName) { GroupName = groupName; }
    }
}
