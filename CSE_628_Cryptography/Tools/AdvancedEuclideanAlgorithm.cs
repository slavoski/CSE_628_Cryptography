using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;

namespace CSE_628_Cryptography.Tools
{
	public class AdvancedEuclideanAlgorithm : BaseViewModel
	{
		private int _a;
		private int _gcd;
		private int _m;
		private int _s;
		private int _t;

		#region properties

		public int A
		{
			get => _a;
			set
			{
				_a = value;
				OnPropertyChanged(nameof(A));
			}
		}

		public Command FindAEACommand
		{
			get;
			private set;
		}

		public int GCD
		{
			get => _gcd;
			set
			{
				_gcd = value;
				OnPropertyChanged(nameof(GCD));
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
		
		public ObservableRangeCollection<StringTable> Results
		{
			get;
			set;
		} = new ObservableRangeCollection<StringTable>();

		public int S
		{
			get => _s;
			set
			{
				_s = value;
				OnPropertyChanged(nameof(S));
			}
		}

		public int T
		{
			get => _t;
			set
			{
				_t = value;
				OnPropertyChanged(nameof(T));
			}
		}
		#endregion

		#region constructor

		public AdvancedEuclideanAlgorithm()
		{
			FindAEACommand = new Command(() => FindAEA());
		}

		#endregion constructor

		public void FindAEA()
		{
			Results.Clear();

			Results.Add(SetTableString("ₗ", "rₗ₋₂ = qₗ₋₁ ·rₗ₋₁ +rₗ", "rₗ = [sₗ]r₀ +[tₗ]r₁", ""));

			var r0 = A > M ? A : M;
			var r1 = A < M ? A : M;
			var remainder = 1;

			Dictionary<int, RValue> EachStep = new Dictionary<int, RValue>
			{
				{ r0, new RValue() { RiValue = r0, R0=1 } },
				{ r1, new RValue() { RiValue = r1, R1=1 } }
			};

			int index = 2;

			do
			{
				int ri = EachStep[r0].RiValue;
				int ri_1 = EachStep[r1].RiValue;

				int multBy = ri / ri_1;
				remainder = ri % ri_1;

				Results.Add(SetTableString(index.ToString(),
										   ri + " = " + multBy + " * " + ri_1 + " + " + remainder,
										   remainder + " = " + ri + " - " + multBy + " * " + ri_1,
										   "gcd(" + ri + " , " + ri_1 + ")"));

				if (remainder != 0)
				{
					var leftSide = EachStep[ri];
					var rightSide = EachStep[ri_1];

					Results.Add(SetTableString("", "", " = " + leftSide.Result() + " - " + multBy + "(" + rightSide.Result() + ")", ""));

					var r0New = GetR0Value(leftSide, rightSide, multBy);
					var r1New = rightSide.R0 != null ? leftSide.R1 - multBy * rightSide.R1 : -multBy * rightSide.R1;

					var newStep = new RValue() { RiValue = remainder, R0 = r0New, R1 = r1New };

					Results.Add(SetTableString("", "", " = " + newStep.Result(), ""));

					EachStep.Add(remainder, newStep);
				}
				else
				{
					EachStep.Add(remainder, new RValue() { RiValue = remainder, R0 = ri, R1 = ri_1 });
				}

				if (remainder <= 0)
				{
					var lastOne = EachStep[ri_1];
					S = lastOne.R0 ?? -1;
					T = lastOne.R1 ?? -1;
					GCD = ri_1;
				}

				r0 = r1;
				r1 = remainder;

				index++;
			} while (remainder != 0);
		}

		private int GetR0Value(RValue leftSide, RValue rightSide, int multBy)
		{
			int? result = 0;
			if (leftSide.R0 != null && leftSide.R1 != null)
			{
				result = leftSide.R0 - multBy * rightSide.R0;
			}
			else if (leftSide.R1 == null)
			{
				result = leftSide.R0;
			}
			else if (leftSide.R0 == null)
			{
				result = -multBy * rightSide.R0;
			}

			return result ?? -1;
		}

		private StringTable SetTableString(string result1, string result2, string result3, string result4)
		{
			var stringTable = new StringTable();
			stringTable.Result1 = result1;
			stringTable.Result2 = result2;
			stringTable.Result3 = result3;
			stringTable.Result4 = result4;
			return stringTable;
		}
	}
}