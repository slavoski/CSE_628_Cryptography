using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE_628_Cryptography.Tools
{
	public class FiAlgorithm : BaseViewModel
	{
		private int _m;
		private string _fiValue;

		#region properties

		public int M
		{
			get => _m;
			set
			{
				_m = value;
				OnPropertyChanged(nameof(M));
			}
		}

		public string FiValue
		{
			get => _fiValue;
			set
			{
				_fiValue = value;
				OnPropertyChanged(nameof(FiValue));
			}
		}

		public Command FindFiCommand
		{
			get;
			private set;
		}

		public ObservableRangeCollection<string> Results
		{
			get;
			set;
		} = new ObservableRangeCollection<string>();

		#endregion

		#region constructor

		public FiAlgorithm()
		{
			FindFiCommand = new Command(() => FindFi());
		}

		#endregion constructor

		#region methods

		public void FindFi()
		{
			Results.Clear();
			var count = 0;
			for(int i = 0; i < M; i++) 
			{
				var gcd = HelperClass.CalculateGCD(i, M);

				Results.Add($"gcd({i}, {M}) = {gcd}");

				if(gcd == 1)
				{
					count++;
				}
			}

			FiValue = $"φ({M}) = {count}";
		}

		#endregion
	}
}
