using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Programacao2_final.Controller
{
    internal class Cmd : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canexecute;

        public Cmd(Action<object> execute, Predicate<object> canexecute)
        {
            this._execute = execute;
            this._canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object parameter)
        {
            return this._canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute.Invoke(parameter);
        }
    }
}
