using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ModTool.Data;
using ModTool.Utils;

namespace ModTool.Pages;

/// <summary>
/// Interaction logic for UserControl1.xaml
/// </summary>
public partial class BaseDataPage : UserControl
{
    public static readonly DependencyProperty FormDataProperty = DependencyProperty.Register(
        "FormData", typeof(FormDataList<BaseData>),
        typeof(BaseDataPage),
        new FrameworkPropertyMetadata()
        {
            BindsTwoWayByDefault = true
        }
    );

    public static readonly DependencyProperty FormDataTypeProperty = DependencyProperty.Register(
        "FormDataType", typeof(Type),
        typeof(BaseDataPage)
    );


    public FormDataList<BaseData> FormData
    {
        get => (FormDataList<BaseData>)GetValue(FormDataProperty);
        set => SetValue(FormDataProperty, value);
    }

    public Type FormDataType
    {
        get => (Type)GetValue(FormDataTypeProperty);
        set => SetValue(FormDataTypeProperty, value);
    }


    public BaseDataPage()
    {
        DataContext = FormData;
        InitializeComponent();
    }

    private void FileBrowseButton_Click(object sender, RoutedEventArgs e)
    {
        var formItem = sender as Button;
        var selectedFile = DialogUtils.SelectImageFile();
        if (!string.IsNullOrEmpty(selectedFile))
        {
            var elementToSearch = TreeUtils.GetTopParent(formItem);
            var textBox = elementToSearch.FindName("FilePathText") as TextBox;
            textBox.Text = selectedFile;
            textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }

    private void AddNewItem_Click(object sender, RoutedEventArgs e)
    {
        var cahce = FormData;
        var newData = (BaseData)Activator.CreateInstance(FormDataType);
        newData.EntityName = $"New {FormDataType.Name}";
        cahce.AddItem(newData);
        FormData = cahce;
    }
}