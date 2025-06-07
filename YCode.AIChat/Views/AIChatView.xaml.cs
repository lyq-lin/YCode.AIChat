using System.Windows.Controls;

namespace YCode.AIChat
{
	/// <summary>
	/// Interaction logic for AIChatView.xaml
	/// </summary>
	public partial class AIChatView : UserControl
	{
		public AIChatView()
		{
			InitializeComponent();
		}

		public void MessageScrollToEnd()
		{
			messages.ScrollToEnd();
		}
	}
}
