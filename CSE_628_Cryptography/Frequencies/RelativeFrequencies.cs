using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Linq;

namespace CSE_628_Cryptography.Frequencies
{
	public class RelativeFrequencies : BaseViewModel
	{
		private Dictionary<char, FrequencyModel> _alphabet = new Dictionary<char, FrequencyModel>();

		private string _textToCalculate = "";

		public Dictionary<char, FrequencyModel> Alphabet
		{
			get => _alphabet;
			set
			{
				_alphabet = value;
				OnPropertyChanged(nameof(Alphabet));
			}
		}

		public Command CalculateFrequenciesCommand { get; set; }

		public string TextToCalculate
		{
			get => _textToCalculate;
			set
			{
				_textToCalculate = value;
				OnPropertyChanged(nameof(TextToCalculate));
			}
		}

		#region constructor

		public RelativeFrequencies()
		{
			CalculateFrequenciesCommand = new Command(() => CalculateFrequencies());
		}

		#endregion constructor

		private void CalculateFrequencies()
		{
			ResetCount();
			foreach (var c in TextToCalculate)
			{
				if (Alphabet.ContainsKey(c))
				{
					Alphabet[c].Count++;
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(c.ToString()))
						Alphabet.Add(c, new FrequencyModel() { Count = 1 });
				}
			}

			var totalCount = 0;
			foreach (var c in Alphabet)
			{
				totalCount += c.Value.Count;
			}

			foreach (var c in Alphabet)
			{
				c.Value.TotalCount = totalCount;
			}

			var list = _alphabet.ToList();
			list.Sort((x, y) => (y.Value.Count.CompareTo(x.Value.Count)));

			Alphabet = new Dictionary<char, FrequencyModel>(list);

			OnPropertyChanged(nameof(Alphabet));
		}

		private void ResetCount()
		{
			_alphabet = new Dictionary<char, FrequencyModel>();
		}
	}
}