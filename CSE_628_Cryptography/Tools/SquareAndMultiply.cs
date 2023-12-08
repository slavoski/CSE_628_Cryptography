using MvvmHelpers;
using MvvmHelpers.Commands;
using System;

namespace CSE_628_Cryptography.Tools
{
	public class SquareAndMultiply : BaseViewModel
	{
		#region member variables

		private int _e;
		private double _m;
		private double _result;
		private double _x;

		#endregion member variables

		#region properties

		public Command CalculateSquareAndMultiplyCommand
		{
			get;
			private set;
		}

		public int E
		{
			get => _e;
			set
			{
				_e = value;
				OnPropertyChanged(nameof(E));
			}
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

		public ObservableRangeCollection<string> Messages
		{
			get;
			set;
		} = new ObservableRangeCollection<string>();

		public double Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		public double X
		{
			get => _x;
			set
			{
				_x = value;
				OnPropertyChanged(nameof(X));
			}
		}

		#endregion properties

		#region constructor

		public SquareAndMultiply()
		{
			CalculateSquareAndMultiplyCommand = new Command(() => CalculateSquareandMultiply());
		}

		#endregion constructor

		#region methods

		private void CalculateSquareandMultiply()
		{
			Messages.Clear();

			var binaryValue = ConvertToBit(E);
			int bitValue = binaryValue[0].Equals('1') ? 1 : 0;
			binaryValue = binaryValue[1..];
			double currentValue = X;

			foreach (var character in binaryValue)
			{
				Messages.Add("Bit Value: " + character + " ");

				currentValue = Math.Pow(currentValue, 2) % M;
				bitValue *= 2;
				Messages.Add("\tPow: " + currentValue.ToString() + $" \t\tBit Result: {X}^{ConvertToBit(bitValue)} ");

				if (character.Equals('1'))
				{
					currentValue = (currentValue * X) % M;
					bitValue += 1;
					Messages.Add("\tMultiply: " + currentValue.ToString() + $" \tBit Result: {X}^{ConvertToBit(bitValue)} ");
				}
			}

			Result = currentValue;
		}

		private string ConvertToBit(int value)
		{
			var bits = Convert.ToString(value, 2);
			return bits;
		}

		#endregion methods
	}
}