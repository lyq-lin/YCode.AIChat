using System.Windows;

namespace YCode.AIChat
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			var app = new Application();

			var window = new Window();

			window.Title = "YCode.AIChat";

			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

			app.Run(window);
		}
	}
}
