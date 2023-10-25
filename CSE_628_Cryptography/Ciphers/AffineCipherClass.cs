using CSE_628_Cryptography.MultiplicativeInverse;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace CSE_628_Cryptography.Ciphers
{
	public class AffineCipherClass : BaseViewModel
	{
		private int _a;
		private int _b;
		private string _decrypt;
		private int _m;
		private MultiplicativeInverseClass _multiplicativeInverseClass = new MultiplicativeInverseClass();
		private string _result;

		public AffineCipherClass()
		{
			CalculateAffineCipherCommand = new Command(() => CalculateAffineCipher());
		}

		public int A
		{
			get => _a;
			set
			{
				_a = value;
				OnPropertyChanged(nameof(A));
			}
		}

		public int B
		{
			get => _b;
			set
			{
				_b = value;
				OnPropertyChanged(nameof(B));
			}
		}

		public Command CalculateAffineCipherCommand
		{
			get;
			set;
		}

		public string Decrypt
		{
			get => _decrypt;
			set
			{
				_decrypt = value;
				OnPropertyChanged(nameof(Decrypt));
			}
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

		public string Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		public void CalculateAffineCipher()
		{
			Result = "";

			_multiplicativeInverseClass.A = A;
			_multiplicativeInverseClass.M = M;

			var inverseA = _multiplicativeInverseClass.FindMultiplicativeInverse();

			foreach (var value in Decrypt)
			{
				if (!char.IsWhiteSpace(value))
				{

					int newValue = value - 'a';

					var result = (inverseA * (newValue - B)) % M;

					if (result < 0)
						result = M + result;

					result += 'a';
					Result += (char)result;
				}
				else
				{
					Result += value;
				}
			}
		}
	}
}