namespace Scavenger.GUI
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