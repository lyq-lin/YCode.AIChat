using System.Windows;

namespace YCode.AIChat
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			var app = new Application();

			var page = new AIChatPage();

			var window = new Window();

			window.Width = 400;

			window.Title = "YCode.AIChat";

			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

			window.Content = page.Content;

			app.Run(window);
		}
	}
}
