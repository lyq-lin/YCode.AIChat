using System.Windows.Input;

namespace YCode.AIChat.SDK
{
	public class AICommand : ICommand
	{
		private readonly Action<object?> _action;

		public AICommand(Action<object?> action)
		{
			_action = action;
		}

		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => true;

		public virtual void Execute(object? parameter)
		{
			_action?.Invoke(parameter);
		}
	}
}
