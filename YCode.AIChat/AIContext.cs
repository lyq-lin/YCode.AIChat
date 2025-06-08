using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using OpenAI;
using System.ClientModel;

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
			var client = new OpenAIClient(
				new ApiKeyCredential(Environment.GetEnvironmentVariable("AICHATKey", EnvironmentVariableTarget.Machine)!),
				new OpenAIClientOptions()
				{
					Endpoint = new Uri("https://api.deepseek.com")
				});

			var builder = Kernel.CreateBuilder();

			builder.AddOpenAIChatCompletion("deepseek-chat", client);
			builder.AddOpenAIChatCompletion("deepseek-reasoner", client);

			builder.Services.AddLogging(builder => builder.AddSimpleConsole().SetMinimumLevel(LogLevel.Trace));

			return builder.Build();
		}
	}
}
