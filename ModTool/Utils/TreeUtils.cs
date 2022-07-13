using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModTool.Utils
{
    public class TreeUtils
    {
        public static FrameworkElement GetTopParent(FrameworkElement item)
        {
            var currentItem = item;
            while (currentItem.Parent != null)
            {
                currentItem = (FrameworkElement)currentItem.Parent;
            }

            return currentItem;
        }

        public static FrameworkElement GetTopTemplateParent(FrameworkElement item)
        {
            var currentItem = item;
            while (currentItem.TemplatedParent != null)
            {
                currentItem = (FrameworkElement)currentItem.TemplatedParent;
            }

            return currentItem;
        }
    }
}
