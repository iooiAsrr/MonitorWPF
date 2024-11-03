using System.Windows.Input;

namespace MonitorWPF.Commands
{
    public class Command : ICommand
    {
        private Action _action;
        //构造函数接受一个Action委托
        public Command(Action action)
        {
            _action = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (CanExecuteChanged != null)
            {
                _action();
            }
        }
    }
}
