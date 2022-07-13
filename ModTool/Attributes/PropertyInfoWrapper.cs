using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ModTool.Data;

namespace ModTool.Attributes
{
    public class FormBindAttributeWrapper
    {
        private readonly PropertyInfo _property;
        private readonly BaseData _objectItem;
        private readonly FormBindAttribute _formBindData;

        public FormBindAttributeWrapper(PropertyInfo property, BaseData objectItem)
        {
            _property = property;
            _objectItem = objectItem;
            _formBindData = property.GetCustomAttribute<FormBindAttribute>();

        }

        public FormBindAttribute FormBindData => _formBindData;

        public object PropertyValue
        {
            get => _property.GetValue(_objectItem);
            set => _property.SetValue(_objectItem, value);
        }
    }
}
