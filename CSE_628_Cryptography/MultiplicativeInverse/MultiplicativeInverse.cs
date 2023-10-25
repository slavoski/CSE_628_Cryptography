using MvvmHelpers;
using MvvmHelpers.Commands;

namespace CSE_628_Cryptography.MultiplicativeInverse
{
	public class MultiplicativeInverseClass : BaseViewModel
	{
		private int _a;
		private int _m;
		private int _result;

		public int A
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

		public int M
		{
			get => _m;
			set
			{
				_m = value;
				OnPropertyChanged(nameof(M));
			}
		}

		public int Result
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

		public int FindMultiplicativeInverse()
		{
			int i = 0;
			while (i < M)
			{
				int value = (i * A) - 1;

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

			return Result;
		}
	}
}