using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModTool.Data
{
    public class SettingsManager
    {

        public void InitialLoadup()
        {
            var pathList = Properties.Settings.Default.DataCollectionPaths;
            if (pathList == null || pathList.Count == 0)
            {
                DataLibaryManager.Instance.Datasets.Add("Default/Default.json");
                DataLibaryManager.Instance.Current = ModToolDataLibrary.CreateDefault();
                Properties.Settings.Default.DataCollectionPaths = new StringCollection(){"Default/Default.json"};

                Properties.Settings.Default.Save();
            }
            else
            {
                foreach (var path in Properties.Settings.Default.DataCollectionPaths)
                {
                    DataLibaryManager.Instance.Datasets.Add(path);
                    DataLibaryManager.Instance.LoadDataset(path);
                }

                DataLibaryManager.Instance.LoadDataset(Properties.Settings.Default.LastCollectionIndex);
            }

        }

        public void SaveSettings()
        {
            Properties.Settings.Default.DataCollectionPaths.Clear();
            Properties.Settings.Default.DataCollectionPaths.AddRange(DataLibaryManager.Instance.Datasets.ToArray());

            Properties.Settings.Default.Save();
        }
    }
}
