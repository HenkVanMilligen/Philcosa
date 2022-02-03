using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Philcosa.Client.Infrastructure.Commands
{
    public class EditCoverCommand : ICommand
    {
        public EditCoverCommand(Action<object> execute)
        {
            Action = execute;
        }

        public Action<object> Action { get; } = null;
        public void Execute(object parameter)
        {
            if (Action != null)
                Action(parameter);
        }

        public bool CanExecute(object paramter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
}
