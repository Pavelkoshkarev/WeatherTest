using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherClient
{
    public class DelegateCommand : ICommand
    {

        public DelegateCommand() { }

        public DelegateCommand(Action action)
        {
            CanExecuteFunc = () => true;
            Command = action;
        }

        public Action Command { get; set; }
        public Func<bool> CanExecuteFunc { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc();
        }

        public void Execute(object parameter)
        {
            Command();
        }

    }
}
