using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;


namespace ModTool.Attributes
{
    
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class FormBindAttribute : Attribute
    {
        public string LabelName { get; }

        public string ToolTipText { get; }
        public int OrderingIndex { get; }

        public ComponentType OverrideComponentType { get; }

        public string MemberName { get; }

        public FormBindAttribute( string labelName,
            string toolTipText = "",
            int orderingIndex = 1,
            ComponentType componentType = ComponentType.NoAction,
            Type lookupType = null,
            [CallerMemberName] string memberName = "")
        {
            LabelName = labelName;
            ToolTipText = toolTipText;
            OrderingIndex = orderingIndex;
            OverrideComponentType = componentType;
            MemberName = memberName;
        }
    }

    public enum ComponentType
    {
        NoAction,
        ImageFilePath,
        RichText,
        MultiItemFreeEntry,
        MultiSelectSetList,
    }
}