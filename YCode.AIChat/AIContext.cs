using Microsoft.SemanticKernel;

namespace YCode.AIChat
{
	internal class AIContext
	{
		private Kernel _kernel;

		public AIContext()
		{
			_kernel = this.CreateKernel();
		}

		public Kernel Kernel => _kernel ?? this.CreateKernel();

		private Kernel CreateKernel()
		{
			var builder = Kernel.CreateBuilder();

			//TODO: 

			return builder.Build();
		}
	}
}
