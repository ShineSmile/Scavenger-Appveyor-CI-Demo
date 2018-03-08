using System;
using System.Windows.Input;

namespace Scavenger.GUI
{
    internal delegate void ExcuteHandler(object obj);

    internal delegate bool CanExcuteHandler(object obj);

    internal class Command : ICommand
    {
        internal Command(ExcuteHandler excute, CanExcuteHandler canExcute = null)
        {
            ExcuteHandler = excute;
            CanExcuteHandler = canExcute;
            CanExecuteChanged = OnCanExecuteChanged;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ExcuteHandler?.Invoke(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return CanExcuteHandler?.Invoke(parameter) ?? false;
        }

        private event ExcuteHandler ExcuteHandler;
        private event CanExcuteHandler CanExcuteHandler;

        private void OnCanExecuteChanged(object sender, EventArgs args)
        {
            CanExecute(args);
        }
    }
}