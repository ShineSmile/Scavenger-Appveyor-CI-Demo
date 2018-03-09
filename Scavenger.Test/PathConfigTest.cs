using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scavenger.Test
{
    [TestClass]
    public class PathConfigTest
    {
        [TestInitialize]
        public void DeleteJsonConfigFile()
        {
            if (File.Exists(PathConfig.ConfigPath))
            {
                File.Delete(PathConfig.ConfigPath);
            }
        }

        [TestMethod]
        public void GetPathsConfigModelTest()
        {
            var config = PathConfig.GetPathsConfigModel();
            Assert.AreEqual(config.Paths.First(), "%TMP%");
        }
    }
}