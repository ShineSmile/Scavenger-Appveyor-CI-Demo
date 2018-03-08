using System.Diagnostics;
using System.Windows;

namespace Scavenger.GUI
{
    internal class ScavengerViewModel
    {
        #region Field

        private const string ProcessName = "Scavenger.exe";

        #endregion

        #region Constructor

        internal ScavengerViewModel()
        {
            RegistServiceCommand = new Command(RegistService, CanRegistService);
            UnregistServiceCommand = new Command(UnregistService, CanUnregistService);
        }

        #endregion

        #region Property

        public bool ServiceStatus { get; set; }
        public PathConfig PathConfig { get; set; }

        #endregion

        #region Command

        public Command RegistServiceCommand { get; set; }
        public Command UnregistServiceCommand { get; set; }

        #endregion

        #region Excute

        public void RegistService(object param)
        {
            var process = Process.Start($"{ProcessName} /regist");
            process?.WaitForExit();
        }

        public void UnregistService(object param)
        {
            MessageBox.Show("OK");
            var process = Process.Start($"{ProcessName} /regist");
            process?.WaitForExit();
        }

        #endregion

        #region CanExcute

        public bool CanRegistService(object param)
        {
            return ServiceStatus;
        }

        public bool CanUnregistService(object param)
        {
            return !ServiceStatus;
        }

        #endregion
    }
}