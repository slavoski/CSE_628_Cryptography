using MvvmHelpers;
using System.Drawing;

namespace CSE_628_Cryptography.Frequencies
{
	public class FrequencyModel : BaseViewModel
	{
		private int _count;
		private int _totalCount;
		private string _value = "";

		public Color BarColor => Color.Pink;

		public double BarWidth => Percentage * 50;

		public int Count
		{
			get => _count;
			set
			{
				_count = value;
				OnPropertyChanged(nameof(Count));
			}
		}

		public double Percentage => (Count / (double)TotalCount) * 100;

		public int TotalCount
		{
			get => _totalCount;
			set
			{
				_totalCount = value;
				OnPropertyChanged(nameof(TotalCount));
				OnPropertyChanged(nameof(Percentage));
			}
		}

		public string Value
		{
			get => _value;
			set
			{
				_value = value;
				OnPropertyChanged(nameof(Value));
			}
		}
	}
}