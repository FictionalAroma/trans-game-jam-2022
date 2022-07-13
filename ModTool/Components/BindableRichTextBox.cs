using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ModTool.Components
{
    public sealed class BindableRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
                typeof(string), 
                typeof(BindableRichTextBox),
                new PropertyMetadata(PropertyChangedCallback)
                {
                    CoerceValueCallback = CoerceValueCallback
                });

        private static object CoerceValueCallback(DependencyObject d, object basevalue) { throw new NotImplementedException(); }


        public string Source { get => GetValue(SourceProperty) as string; set => SetValue(SourceProperty, value); }

        private static void OnSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is BindableRichTextBox rtf && rtf.Source != null)
            {
                var stream = rtf.Source;
                if (stream != null)
                {
                    var range = new TextRange(rtf.Document.ContentStart, rtf.Document.ContentEnd)
                    {
                        Text = stream
                    };
                }
            }
        }

        private static void PropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is BindableRichTextBox rtf && rtf.Source != null)
            {
                var docText = new TextRange(rtf.Document.ContentStart, rtf.Document.ContentEnd).Text;
                rtf.Source = docText;
            }
        }

        }
}
