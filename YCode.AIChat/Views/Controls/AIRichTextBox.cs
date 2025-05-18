using System.Windows;
using System.Windows.Controls;

namespace YCode.AIChat
{
	internal class AIRichTextBox : RichTextBox
	{
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(AIRichTextBox), new FrameworkPropertyMetadata(String.Empty, OnTextChanged));

		private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is AIRichTextBox tb && e.NewValue is string text)
			{
				tb.UpdateText(text);
			}
		}

		private void UpdateText(string text)
		{
			this.Dispatcher.BeginInvoke(() =>
			{
				this.Document = Markdig.Wpf.Markdown.ToFlowDocument(text);

			}, System.Windows.Threading.DispatcherPriority.DataBind);
		}
	}
}
