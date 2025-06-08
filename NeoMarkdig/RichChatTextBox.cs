using Markdig;
using Markdig.Renderers;
using Markdig.Syntax;
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
		}

		public void UpdateTextChanged(string text)
		{
			this.Dispatcher.BeginInvoke(() =>
			{
				this.Document = Markdig.Wpf.Markdown.ToFlowDocument(this.Text, _pipeline, _renderer);

				var document = Markdig.Markdown.Parse(this.Text, _pipeline);

				//思路: 原Markdow解析包解析完后，分发到Wpf document 去渲染。原包是一段段解析的，wpf document需要缓存已渲染过的内容。

				//1.取得完整的Document

				foreach (var para in document)
				{
					if (para is LeafBlock leaf)
					{
						if (leaf.Lines.Lines != null)
						{
							var lines = leaf.Lines;

							var slices = lines.Lines;

							for (var i = 0; i < lines.Count; i++)
							{
								var slice = slices[i].Slice;

								if (slice.Start > slice.End)
									return;

								var text = SplitText(slice.Text, slice.Start, slice.Length);
							}
						}
					}
				}

				//2.取得当前部分更新的字段存在与哪个段落的末尾,与之匹配
				//3.只更新匹配的字段控件,从Document的Block移除

				GC.Collect(1, GCCollectionMode.Optimized);

			}, System.Windows.Threading.DispatcherPriority.Background);
		}

		private string SplitText(string text, int offset, int length)
		{
			var buffer = new char[1024];

			if (offset == 0 && text.Length == length)
			{
				return text;
			}
			else
			{
				if (length > buffer.Length)
				{
					buffer = text.ToCharArray();

					return new string(buffer, offset, length);
				}
				else
				{
					text.CopyTo(offset, buffer, 0, length);

					return new string(buffer, 0, length);
				}
			}
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
