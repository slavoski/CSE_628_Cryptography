using MvvmHelpers;
using MvvmHelpers.Commands;

namespace CSE_628_Cryptography.MultiplicativeInverse
{
	public class MultiplicativeInverseClass : BaseViewModel
	{
		private double _a;
		private double _m;
		private double _result;

		public double A
		{
			get => _a;
			set
			{
				_a = value;
				OnPropertyChanged(nameof(A));
			}
		}

		public Command FindMultiplicativeInverseCommand
		{
			get;
			private set;
		}

		public double M
		{
			get => _m;
			set
			{
				_m = value;
				OnPropertyChanged(nameof(M));
			}
		}

		public double Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		#region constructor

		public MultiplicativeInverseClass()
		{
			FindMultiplicativeInverseCommand = new Command(() => FindMultiplicativeInverse());
		}

		#endregion constructor

		public void FindMultiplicativeInverse()
		{
			int i = 0;
			while (i < M)
			{
				double value = (i * A) - 1;

				if (value % M == 0)
				{
					Result = i;
					break;
				}
				else
				{
					i++;
				}
			}
		}
	}
}