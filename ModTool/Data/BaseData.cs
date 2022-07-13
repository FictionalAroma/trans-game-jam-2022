
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using ModTool.Annotations;
using ModTool.Attributes;
using ModTool.Data.DataObjects;
using Newtonsoft.Json;

namespace ModTool.Data
{
    public abstract class BaseData : INotifyPropertyChanged
    {
        private Guid _entityID = Guid.NewGuid();

        private string _entityName;
        [FormBind("Lookup Name")]
        public string EntityName
        {
            get => _entityName;
            set
            {
                _entityName = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public IEnumerable<FormBindAttributeWrapper> GetFormBindings => GetPropertiesWithAttribute<FormBindAttribute>().Select(info => new FormBindAttributeWrapper(info, this));

        public IEnumerable<PropertyInfo> GetPropertiesWithAttribute<T>() where T : Attribute =>
            this.GetType().GetProperties().Where(info => info.CustomAttributes.Any(data => data.AttributeType ==  typeof(T)));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [ValueConversion(typeof(BaseData), typeof(CharacterData))]
    [ValueConversion(typeof(BaseData), typeof(LocationData))]
    public class BaseDataTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
