using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Scavenger
{
    public class PathConfig
    {
        public const string ConfigPath = "PathConfig.json";

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
            using (var fileStream = File.Open(ConfigPath, FileMode.OpenOrCreate))
            {
                fileStream.Write(json);
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
            var config = new PathConfig();
            config.Paths.Add("%TMP%");
            SavePathConfigModel(config);
        }
    }
}