using MvvmHelpers;
using MvvmHelpers.Commands;

namespace CSE_628_Cryptography.Ciphers
{
	public class Caeser : BaseViewModel
	{
		private string _analyze = "";
		private int _key = 0;
		private Command _parseCaeserCommand;
		private string _result = "";

		public Caeser()
		{
			ParseCaeserCommand = new Command(() => ParseCaeser());
		}

		public string Analyze
		{
			get => _analyze;
			set
			{
				_analyze = value;
				OnPropertyChanged(nameof(Analyze));
			}
		}

		public int Key
		{
			get => _key;
			set
			{
				_key = value;
				OnPropertyChanged(nameof(Key));
			}
		}

		public Command ParseCaeserCommand
		{
			get;
			private set;
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

		private void ParseCaeser()
		{
			Result = "";
			var backwards = true;
			
			if (Key < 0)
				backwards = false;

			foreach (char c in _analyze)
			{
				var update = c;
				var tempKey = Key; 
				var i = backwards ? -1 : 1;
				while (tempKey != 0)
				{
					if (update == 'z' && !backwards)
						update = 'a';
					else if (update == 'a' && backwards)
						update = 'z';
					else
					{
						if (backwards)
							update--;
						else
							update++;
					}

					tempKey += backwards ? -1 : 1;
				}

				Result += update;
			}
		}
	}
}