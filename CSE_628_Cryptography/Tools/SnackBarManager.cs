using MaterialDesignThemes.Wpf;

namespace CSE_628_Cryptography.Tools
{
	public static class SnackBarManager
	{
		public static SnackbarMessageQueue SnackBoxMessage
		{
			get;
			set;
		} = new SnackbarMessageQueue();
	}
}