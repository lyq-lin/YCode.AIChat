using System.Collections.ObjectModel;
using System.Windows.Input;
using YCode.AIChat.SDK;

namespace YCode.AIChat
{
	internal class AIChatViewModel : ViewModelBase
	{
		private string _title = String.Empty;
		private string _prompt = String.Empty;

		private ObservableCollection<AIChatMessageViewModel> _messages = [];

		public ObservableCollection<AIChatMessageViewModel> Messages
		{
			get { return _messages; }
			set { this.OnPropertyChanged(ref _messages, value); }
		}

		public string Prompt
		{
			get { return _prompt; }
			set { this.OnPropertyChanged(ref _prompt, value); }
		}

		public string Title
		{
			get { return _title; }
			set { this.OnPropertyChanged(ref _title, value); }
		}

		public ICommand? SendCommand { get; set; }
	}
}
