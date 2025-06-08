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
			this.Dispatcher.BeginInvoke(messages.ScrollToEnd, System.Windows.Threading.DispatcherPriority.Background);
		}
	}
}
