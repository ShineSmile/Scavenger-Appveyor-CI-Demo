using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Scavenger.Service
{
    public class PathConfig
    {
        private const string ConfigPath = "PathConfig.json";

        internal PathConfig()
        {
            Paths = new ObservableCollection<string>();
        }
        public ObservableCollection<string> Paths { get; }

        public static PathConfig GetPathsConfigModel()
        {
            try
            {
                return ReadPathConfig();
            }
            catch
            {
                File.Delete(ConfigPath);
                RecreateConfigFile();
            }

            return ReadPathConfig();
        }
        public static void SavePathConfigModel(PathConfig pathConfig)
        {
            string json = JsonConvert.SerializeObject(pathConfig);
            using (FileStream fileStream = File.Open("ConfigPath", FileMode.OpenOrCreate))
            {
                fileStream.Write(json);
                fileStream.Flush();
            }
        }
        private static PathConfig ReadPathConfig()
        {
            using (var fileStream = File.Open(ConfigPath, FileMode.Open))
            {
                string json = fileStream.ReadToEnd();
                return JsonConvert.DeserializeObject<PathConfig>(json);
            }
        }
        private static void RecreateConfigFile()
        {
            using (var fileStream = File.Create(ConfigPath))
            {
                var model = new PathConfig();
                model.Paths.Add("%TMP%");
                string json = JsonConvert.SerializeObject(model);
                fileStream.Write(json);
                fileStream.Flush();
            }
        }
    }
}