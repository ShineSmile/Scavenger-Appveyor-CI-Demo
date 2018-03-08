using Scavenger.Service;

namespace Scavenger
{
    public partial class App
    {
        internal ScavengerViewModel MainViewModel;

        internal App()
        {
            MainViewModel = new ScavengerViewModel
            {
                ServiceStatus = false,
                PathConfig = PathConfig.GetPathsConfigModel()
            };
        }
    }
}