using Markdig.Renderers;
using Markdig.Renderers.Wpf;
using Markdig.Syntax;
using System.Windows.Documents;
using YCode.Controls;

namespace NeoMarkdig.Renders
{
	internal class ColorCodeBlockRenderer : WpfObjectRenderer<CodeBlock>
	{
		protected override void Write(WpfRenderer renderer, CodeBlock obj)
		{
			if (renderer == null) throw new ArgumentNullException(nameof(renderer));

			if (obj is LeafBlock leafBlock)
			{
				if (leafBlock.Lines.Lines != null)
				{
					var lines = leafBlock.Lines;

					var slices = lines.Lines;

					var code = new CodeControl();

					renderer.Push(new BlockUIContainer(code));

					renderer.Pop();

					for (var i = 0; i < lines.Count; i++)
					{
						var slice = slices[i].Slice;

						if (slice.Start > slice.End)
							return;

						var text = SplitText(slice.Text, slice.Start, slice.Length);

						code.Text += text;
					}
				}
			}
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
	}
}
