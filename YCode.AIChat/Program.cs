using System.Windows;
using YCode.AIChat;

var thread = new Thread(() =>
{
	var app = new Application();

	var context = new AIContext();

	var page = new AIChatPage(context);

	var window = new Window();

	window.Width = 400;

	window.Title = "YCode.AIChat";

	window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

	window.Content = page.Content;

	app.Run(window);
});

_ = thread.TrySetApartmentState(ApartmentState.STA);

thread.Start();