using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Linq;

namespace CSE_628_Cryptography.Tools
{
	public class FactorClass : BaseViewModel
	{
		private string _display = "";
		private List<int> _factors = new List<int>();
		private int _x;

		public FactorClass()
		{
			FactorClassCommand = new Command(() => CalculateFactors());
		}

		public string Display
		{
			get => _display;
			set
			{
				_display = value;
				OnPropertyChanged(nameof(Display));
			}
		}

		public Command FactorClassCommand
		{
			get;
			private set;
		}

		public List<int> Factors
		{
			get => _factors;
			set
			{
				_factors = value;
				OnPropertyChanged(nameof(X));
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

		public void CalculateFactors()
		{
			Factors = HelperClass.CalculateFactors(X);
			SetDisplay();
		}

		private void SetDisplay()
		{
			var display = "{ ";

			foreach (var factor in Factors)
			{
				display += factor.ToString();

				if (factor != Factors.Last())
					display += ", ";
			}
			display += "}";

			Display = display;
		}
	}
}