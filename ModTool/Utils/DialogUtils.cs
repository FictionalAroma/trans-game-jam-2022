using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Drawing.Imaging;


namespace ModTool.Utils
{
    public class DialogUtils
    {
        public static string SelectImageFile()
        {
            StringBuilder filterBuilder = new StringBuilder();
            filterBuilder.AppendJoin('|',
                ImageCodecInfo.GetImageEncoders().Select(info =>
                    $"{info.FormatDescription} Files ({info.FilenameExtension}) | {info.FilenameExtension}"));
            filterBuilder.Append("|All files(*.*) | *.*");
            OpenFileDialog fileSelect = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = filterBuilder.ToString(),
            };
            return fileSelect.ShowDialog() == true ? fileSelect.FileName : string.Empty;
        }
    }
}
