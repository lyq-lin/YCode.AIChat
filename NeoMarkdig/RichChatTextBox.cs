using Markdig;
using Markdig.Renderers;
using System.Windows;
using System.Windows.Controls;

namespace NeoMarkdig
{
	public class RichChatTextBox : RichTextBox
	{
		private readonly MarkdownPipeline _pipeline;
		private readonly WpfRenderer _renderer;

		public RichChatTextBox()
		{
			_pipeline = new MarkdownPipelineBuilder()
				.UseAdvancedExtensions()
				.Use<MarkdownExtension>()
				.Build();

			_renderer = new WpfRenderer(this.Document);

			this.IsDocumentEnabled = true;
		}

		public void FullTextChanged(string text)
		{
			this.Dispatcher.BeginInvoke(() =>
			{
				this.Document = Markdig.Wpf.Markdown.ToFlowDocument(text, _pipeline, _renderer);

			}, System.Windows.Threading.DispatcherPriority.Background);
		}

		public void UpdateTextChanged(string text)
		{

		}

		#region Dependency Property

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public string UpdateText
		{
			get { return (string)GetValue(UpdateTextProperty); }
			set { SetValue(UpdateTextProperty, value); }
		}

		public static readonly DependencyProperty UpdateTextProperty =
			DependencyProperty.Register("UpdateText", typeof(string), typeof(RichChatTextBox), new PropertyMetadata(String.Empty, OnUpdateTextChanged));

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(RichChatTextBox), new PropertyMetadata(String.Empty, OnTextChanged));

		private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is RichChatTextBox box && e.NewValue is string text)
			{
				box.FullTextChanged(text);
			}
		}

		private static void OnUpdateTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is RichChatTextBox box && e.NewValue is string update)
			{
				box.UpdateTextChanged(update);
			}
		}

		#endregion
	}
}
