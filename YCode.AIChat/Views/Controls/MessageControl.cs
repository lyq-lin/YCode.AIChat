using System.Windows.Controls;

namespace YCode.AIChat
{
	internal class MessageControl : ItemsControl
	{
		private ScrollViewer? _scroll;

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (this.GetTemplateChild("PART_Scroll") is ScrollViewer scroll)
			{
				_scroll = scroll;
			}
		}

		public void ScrollToEnd()
		{
			_scroll?.ScrollToEnd();
		}

		public void ScrollToHome()
		{
			_scroll?.ScrollToHome();
		}
	}
}
