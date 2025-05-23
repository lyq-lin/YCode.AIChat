﻿using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ClientModel.Primitives;
using System.Text.Json.Nodes;
using System.Windows;
using YCode.AIChat.SDK;

namespace YCode.AIChat
{
	internal class AIChatPage
	{
		private readonly AIContext _context;

		public AIChatPage(AIContext context)
		{
			_context = context;

			this.Content = new AIChatView();

			this.DataContext = new AIChatViewModel();

			this.Content.DataContext = this.DataContext;

			this.Fill();
		}

		public FrameworkElement Content { get; }

		public object DataContext { get; }

		private void Fill()
		{
			if (this.DataContext is AIChatViewModel viewModel)
			{
				viewModel.SendCommand = new AICommand(this.OnSend);
			}
		}

		private async void OnSend(object? parameter)
		{
			if (this.DataContext is AIChatViewModel viewModel
				&& !String.IsNullOrWhiteSpace(viewModel.Prompt))
			{
				var user = new AIChatMessageViewModel()
				{
					Message = viewModel.Prompt,
					Role = AIRole.User,
					CreateAt = DateTime.Now
				};

				var assistant = new AIChatMessageViewModel()
				{
					CreateAt = DateTime.Now,
					Role = AIRole.AI,
				};

				viewModel.Messages.Add(user);

				var history = new ChatHistory();

				history.AddRange(viewModel.Messages.Select(x => new ChatMessageContent()
				{
					Content = x.Message,
					Role = x.Role switch
					{
						AIRole.AI => AuthorRole.Assistant,
						AIRole.User or
						_ => AuthorRole.User,
					},
				}));

				viewModel.Messages.Add(assistant);

				viewModel.Prompt = String.Empty;

				var settings = new OpenAIPromptExecutionSettings()
				{
					Temperature = 0.3f,
					MaxTokens = 1000,
					TopP = 1.0f,
					ModelId = viewModel.ModelId
				};

				var args = new KernelArguments(settings);

				try
				{
					var isRasoning = default(bool?);

					await foreach (var update in _context.Kernel.InvokePromptStreamingAsync(user.Message, args))
					{
						var jsonContent = JsonNode.Parse(ModelReaderWriter.Write(update.InnerContent!));

						var reasoningUpdate = jsonContent!["choices"]![0]!["delta"]!["reasoning_content"];

						if (reasoningUpdate != null)
						{
							if (!isRasoning.HasValue)
							{
								isRasoning = false;

								assistant.Message += "推理中... \n\n";
							}

							assistant.Message += reasoningUpdate;

							continue;
						}

						if (isRasoning.HasValue && !isRasoning.Value)
						{
							isRasoning = true;

							assistant.Message += "\n\n 推理结束.\n\n";
						}

						assistant.Message += update;
					}
				}
				catch (Exception ex)
				{
					assistant.Message += ex.Message;
				}
			}
		}
	}
}
