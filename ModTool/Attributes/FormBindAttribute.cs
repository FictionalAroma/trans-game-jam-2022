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

        public ComponentType OverrideComponentType { get; }

        public string MemberName { get; }

        public FormBindAttribute( string labelName,
            string toolTipText = "",
            ComponentType componentType = ComponentType.NoAction,
            [CallerMemberName] string memberName = "")
        {
            LabelName = labelName;
            ToolTipText = toolTipText;
            OverrideComponentType = componentType;
            MemberName = memberName;
        }
    }

    public enum ComponentType
    {
        NoAction,
        ImageFilePath,
        RichText
    }
}