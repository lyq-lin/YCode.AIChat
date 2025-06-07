using Markdig.Renderers;
using Markdig.Renderers.Wpf;
using Markdig.Syntax;
using Markdig.Wpf;
using System.Windows;
using System.Windows.Documents;

namespace NeoMarkdig.Renders
{
	internal class ColorCodeBlockRenderer : WpfObjectRenderer<CodeBlock>
	{
		protected override void Write(WpfRenderer renderer, CodeBlock obj)
		{
			if (renderer == null) throw new ArgumentNullException(nameof(renderer));

			var paragraph = new Paragraph();

			paragraph.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.CodeBlockStyleKey);

			renderer.Push(paragraph);

			renderer.WriteLeafRawLines(obj);

			renderer.Pop();
		}
	}
}
