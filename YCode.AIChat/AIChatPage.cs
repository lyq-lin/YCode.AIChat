using System.Windows;
using YCode.AIChat.SDK;

namespace YCode.AIChat
{
	internal class AIChatPage
	{
		private readonly AIContext _context;

		public AIChatPage(AIContext context)
		{
			_context = context;

			this.Content = new AIChatView();

			this.DataContext = new AIChatViewModel();

			this.Content.DataContext = this.DataContext;

			this.Fill();
		}

		public FrameworkElement Content { get; }

		public object DataContext { get; }

		private void Fill()
		{
			if (this.DataContext is AIChatViewModel viewModel)
			{
				viewModel.SendCommand = new AICommand(this.OnSend);
			}
		}

		private void OnSend(object? parameter)
		{

		}
	}
}
