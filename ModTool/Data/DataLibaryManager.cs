using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ModTool.Data
{
    public class DataLibaryManager
    {
        private static readonly Lazy<DataLibaryManager> LazyInstance = new Lazy<DataLibaryManager>();
        public static DataLibaryManager Instance => LazyInstance.Value;

        private const string StoragePath = "\\UnderTheBed\\VisualNovelModTool\\Datasets";
        
        public List<string> Datasets { get; set; }

        public ModToolDataLibrary Current { get; set; }

        public DataLibaryManager()
        {
            Datasets = new List<string>();
        }

        public bool LoadDataset(int index)
        {
            if (index < Datasets.Count)
            {
                return LoadDataset(Datasets[index]);
            }

            return false;
        }

        public bool LoadDataset(string filePath)
        {
            string readPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                StoragePath, filePath);
            if (File.Exists(readPath))
            {
                var newDataset = JsonConvert.DeserializeObject<ModToolDataLibrary>(File.ReadAllText(readPath), new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                });
                Current = newDataset;
                Datasets.Add(filePath);
                return true;
            }

            return false;
        }

        public bool ImportDataset(string filepath)
        {
            if (File.Exists(filepath))
            {
                var newDataset = JsonConvert.DeserializeObject<ModToolDataLibrary>(File.ReadAllText(filepath));
                SaveDataset(newDataset);
                Datasets.Add(Path.Combine(newDataset.Name, $"{newDataset.Name}.json"));
                return true;
            }

            return false;
        }

        public void SaveDataset(ModToolDataLibrary newDataset, string path = "")
        {
            var filePath = string.IsNullOrEmpty(path) ? GetDatasetSavePath(newDataset) : path;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, JsonConvert.SerializeObject(newDataset, Formatting.Indented));
        }

        public static string GetDatasetSavePath(ModToolDataLibrary newDataset) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            StoragePath, newDataset.Name, $"{newDataset.Name}.json");


    }

    public struct DataLibaryProperties
    {
        public string FilePath { get; set; }
        public string Name { get; set; }

    }
}
