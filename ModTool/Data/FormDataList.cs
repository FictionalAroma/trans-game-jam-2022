using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using ModTool.Data.DataObjects;

namespace ModTool.Data
{
    public class FormDataList<T> : ObservableCollection<T> where T : BaseData
    {
        private T _selectedItem;
        public FormDataList() : base() { }

        public FormDataList(IList<T> list) : base(list) { }
        public FormDataList(IEnumerable<T> list) : base(list) { }
        public IEnumerable<string> GetNames => Items.Select(data => data.EntityName);

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value)
                {
                    return;
                }

                _selectedItem = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        public void AddItem(T newData)
        {
            this.Add(newData);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newData));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Items)));

        }

    }

    public class FormListConverter<T> : IValueConverter where T: BaseData
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (FormDataList<T>)value;
            value = new FormDataList<BaseData>(temp.Select(data => (BaseData)data));

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (FormDataList<BaseData>)value;
            value = new FormDataList<T>(temp.Select(data => (T)data));

            return value;

        }
    }

    [ValueConversion(typeof(FormDataList<CharacterData>), typeof(FormDataList<BaseData>))]
    public class FormListCharacterConverter : FormListConverter<CharacterData>
    {
    }

    [ValueConversion(typeof(FormDataList<LocationData>), typeof(FormDataList<BaseData>))]
    public class FormListLocationConverter : FormListConverter<LocationData>
    {
    }


}
