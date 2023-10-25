using MvvmHelpers;
using MvvmHelpers.Commands;

namespace CSE_628_Cryptography.Tools
{
	public class GCDClass : BaseViewModel
	{
		private int _gcd;
		private int _x;
		private int _y;

		public GCDClass()
		{
			CalculateGCDCommand = new Command(() => CalculateGCD());
		}

		public Command CalculateGCDCommand
		{
			get;
			private set;
		}

		public int Gcd
		{
			get => _gcd;
			set
			{
				_gcd = value;
				OnPropertyChanged(nameof(Gcd));
			}
		}

		public int X
		{
			get => _x;
			set
			{
				_x = value;
				OnPropertyChanged(nameof(X));
			}
		}

		public int Y
		{
			get => _y;
			set
			{
				_y = value;
				OnPropertyChanged(nameof(Y));
			}
		}

		public void CalculateGCD()
		{
			Gcd = HelperClass.CalculateGCD(X, Y);
		}
	}
}