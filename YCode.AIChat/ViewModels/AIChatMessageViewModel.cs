using YCode.AIChat.SDK;

namespace YCode.AIChat
{
	internal class AIChatMessageViewModel : ViewModelBase
	{
		private string _message = String.Empty;

		private AIRole _role;

		public DateTime CreateAt { get; set; }

		public AIRole Role
		{
			get { return _role; }
			set { _role = value; }
		}
		public string Message
		{
			get { return _message; }
			set { this.OnPropertyChanged(ref _message, value); }
		}
	}
}
