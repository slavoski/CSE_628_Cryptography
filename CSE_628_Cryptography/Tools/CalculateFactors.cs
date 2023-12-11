using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE_628_Cryptography.Tools
{
	public class CalculateFactors : BaseViewModel
	{
		#region member variables

		private int _middleX;
		private int _integer;
		private string _result = "";

		#endregion member variables

		#region properties

		public int B
		{
			get => _middleX;
			set
			{
				_middleX = value;
				OnPropertyChanged(nameof(B));
			}
		}

		public int C
		{
			get => _integer;
			set
			{
				_integer = value;
				OnPropertyChanged(nameof(C));
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

		public Command FindFactorsCommand
		{
			get;
			private set;
		}

		#endregion

		#region constructor

		public CalculateFactors()
		{
			FindFactorsCommand = new Command(() => CalculateFactor());
		}

		#endregion

		#region methods

		private void CalculateFactor()
		{
			if(C != 0 && B != 0)
			{
				var leftValue = Math.Abs(B / 2);
				var righSide = int.MaxValue;
				var center = Math.Abs(leftValue);
				var found = false;
				for(int i = 0; i < center; i++)
				{
					leftValue++;
					var value = (C / 1.0f / leftValue);
					if ((value % 1) < Double.Epsilon && (value + leftValue) == B)
					{
						righSide = Convert.ToInt32(value);
						found = true;
						break;
					}
				}

				if(found) 
				{
					Result = $"(x {GetOperator(leftValue)} {leftValue}), (x {GetOperator(righSide)} {righSide}) ";
				}
				else
				{
					Result = "No Easy Factorization";
				}


			}

		}

		private string GetOperator(int value)
		{
			return value > 0 ? "+" : "-";
		}

		#endregion

	}
}
