using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DataLib.GameDataInterfaces;
using ModTool.Attributes;

namespace ModTool.Data.DataObjects
{
    public class LocationData : BaseData, ILocation
    {
        [FormBind("Location Name")]
        public string LocationName { get; set; }
        [FormBind("Location Full Description", componentType:ComponentType.RichText)]
        public string Description { get; set; }
        [FormBind("Location Icon", componentType: ComponentType.ImageFilePath)]
        public string LogoImagePath { get; set; }

    }
}
