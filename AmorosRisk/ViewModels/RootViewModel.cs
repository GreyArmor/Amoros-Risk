using EmptyKeys.UserInterface.Controls;
using EmptyKeys.UserInterface.Mvvm;

namespace AmorosRisk.ViewModels
{
	internal class RootViewModel : ViewModelBase
	{
		private UserControl _content;

		public RootViewModel() { }

		internal void SetNewContent(UserControl _content)
		{
			ContentWindow = _content;
		}

		public UserControl ContentWindow
		{
			get { return _content; }
			set
			{
				SetProperty(ref _content, value, "ContentWindow");
			}
		}
	}
}