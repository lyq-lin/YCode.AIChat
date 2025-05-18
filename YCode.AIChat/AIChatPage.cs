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

			this.Fill();
		}

		public FrameworkElement Content { get; }

		public object DataContext { get; }

		private void Fill()
		{
			//Test
			if (this.DataContext is AIChatViewModel viewModel)
			{
				viewModel.Messages.Add(new AIChatMessageViewModel()
				{
					Role = SDK.AIRole.User,
					Message = "什么是MCP?",
					CreateAt = DateTime.Now
				});

				viewModel.Messages.Add(new AIChatMessageViewModel()
				{
					Role = SDK.AIRole.AI,
					Message = "MCP是XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
					CreateAt = DateTime.Now
				});
			}
		}
	}
}
