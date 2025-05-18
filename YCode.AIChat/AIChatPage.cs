using System.Windows;

namespace YCode.AIChat
{
	internal class AIChatPage
	{
		public AIChatPage()
		{
			this.Content = new AIChatView();

			this.DataContext = new AIChatViewModel();

			this.Content.DataContext = this.DataContext;
		}

		public FrameworkElement Content { get; }

		public object DataContext { get; }
	}
}
