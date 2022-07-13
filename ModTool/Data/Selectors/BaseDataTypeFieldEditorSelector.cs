using System.Windows;
using System.Windows.Controls;
using ModTool.Attributes;

namespace ModTool.Data.Selectors
{
    public class BaseDataTypeFieldEditorSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            string selectedComponent = string.Empty;
            if (element != null && item is FormBindAttributeWrapper dataItem)
            {
                selectedComponent = dataItem.FormBindData.OverrideComponentType switch
                {
                    ComponentType.ImageFilePath => "FilePathSelectorTemplate",
                    ComponentType.RichText => "RichTextContentTemplate",
                    _ => dataItem.PropertyValue switch
                    {
                        int => "FieldContentInt",
                        bool => "FieldContentBool",
                        _ => selectedComponent
                    }
                };

            }

            if (string.IsNullOrEmpty(selectedComponent))
            {
                selectedComponent = "FieldContentString";
            }

            if (element != null) return element.FindResource(selectedComponent) as DataTemplate;
            return Application.Current.MainWindow.FindResource(selectedComponent) as DataTemplate;
        }
    }
}
