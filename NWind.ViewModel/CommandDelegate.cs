using System;
using System.Windows.Input;

namespace NWind.ViewModel
{
    public class CommandDelegate : ICommand
    {
        Action<object> _executeDelegate;
        Func<object, bool> _canExecuteDelegate;

        public CommandDelegate(Func<object,bool> canExecuteDelegate, Action<object> executeDelegate)
        {
            _canExecuteDelegate = canExecuteDelegate;
            _executeDelegate = executeDelegate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var handler = _canExecuteDelegate;
            bool result = false;

            if(handler != null)
            {
                result = handler(parameter);
            }

            return result;
        }

        public void Execute(object parameter)
        {
            var handler = _executeDelegate;
            handler?.Invoke(parameter);
        }

        public void ChangeCanExecute()
        {
            var handler = CanExecuteChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
