using System.Windows;
using System.Windows.Controls;
using YCode.AIChat.SDK;

namespace YCode.AIChat
{
	internal class AIMessageDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate AI { get; set; } = default!;
		public DataTemplate User { get; set; } = default!;

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is AIChatMessageViewModel viewModel)
			{
				return viewModel.Role switch
				{
					AIRole.AI => this.AI,
					AIRole.User or
					_ => this.User,
				};
			}

			return base.SelectTemplate(item, container);
		}
	}
}
