using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Linq;

namespace CSE_628_Cryptography.Tools
{
	public class RelativePrimeClass : BaseViewModel
	{
		private string _display = "";
		private int _x;

		public RelativePrimeClass()
		{
			CalculateRelativePrimesCommmand = new Command(() => CalculateGCDList());
		}

		public Command CalculateRelativePrimesCommmand
		{
			get;
			private set;
		}

		public string Display
		{
			get => _display;
			set
			{
				_display = value;
				OnPropertyChanged();
			}
		}

		public List<int> RelativePrimesList
		{
			get;
			set;
		} = new List<int>();

		public int X
		{
			get => _x;
			set
			{
				_x = value;
				OnPropertyChanged(nameof(X));
			}
		}
		
		private void CalculateGCDList()
		{
			RelativePrimesList.Clear();
			RelativePrimesList.Add(1);

			for (int i = 2; i < X; i++)
			{
				var gcd = HelperClass.CalculateGCD(X, i);
				if (gcd == 1)
				{
					RelativePrimesList.Add(i);
				}
			}
			SetDisplay();
			OnPropertyChanged(nameof(RelativePrimesList));

		}

		private void SetDisplay()
		{
			var result = "a ∈ {";

			foreach (var item in RelativePrimesList)
			{
				result += item.ToString();

				if (item == RelativePrimesList.Last())
				{
					break;
				}

				result += ", ";
			}

			result += " }";

			Display = result;
		}
	}
}