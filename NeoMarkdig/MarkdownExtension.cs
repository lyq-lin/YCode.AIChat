using Markdig;
using Markdig.Renderers;

namespace NeoMarkdig
{
	internal class MarkdownExtension : IMarkdownExtension
	{
		public void Setup(MarkdownPipelineBuilder pipeline)
		{

		}

		public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
		{
			//var code = renderer.ObjectRenderers.FindExact<CodeBlockRenderer>();

			//if (code is not null)
			//{
			//	renderer.ObjectRenderers.Remove(code);
			//}

			//renderer.ObjectRenderers.Insert(0, new ColorCodeBlockRenderer());
		}
	}
}
