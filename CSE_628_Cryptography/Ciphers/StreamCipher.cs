using CSE_628_Cryptography.Tools;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;

namespace CSE_628_Cryptography.Ciphers
{
	public class StreamCipher : BaseViewModel
	{
		private string _analyze = "";
		private string _key = "";
		private string _result = "";

		public StreamCipher()
		{
			ParseStreamCipherCommand = new Command(() => ParseStreamCipher());
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

		public string Key
		{
			get => _key;
			set
			{
				_key = value;
				OnPropertyChanged(nameof(Key));
			}
		}

		public int Modulo
		{
			get;
			set;
		} = 26;

		public List<string> Operators
		{
			get;
			set;
		} = new List<string>() { "+", "-", "*", "/", "AND", "OR", "XOR" };

		public Command ParseStreamCipherCommand
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

		public string SelectedOperator
		{
			get;
			set;
		} = "+";

		private void ParseStreamCipher()
		{
			Result = "";
			var analyzeSize = Analyze.Length;

			if (Key.Length == analyzeSize)
			{
				for (int i = 0; i < analyzeSize; ++i)
				{
					var analayze = Analyze[i];

					if (!char.IsWhiteSpace(analayze))
					{
						var analyzeValue = analayze - 'a';
						var keyValue = Key[i] - 'a';

						var result = 0;

						switch (SelectedOperator)
						{
							case "+":
								result = (analyzeValue + keyValue);
								break;

							case "-":
								result = (analyzeValue - keyValue);
								break;

							case "*":
								result = (analyzeValue * keyValue);
								break;

							case "/":
								{
									if (keyValue != 0)
									{
										result = (analyzeValue / keyValue);
									}
									else
									{
										result = 0;
									}
								}
								break;

							case "AND":
								result = (analyzeValue & keyValue);
								break;

							case "OR":
								result = (analyzeValue | keyValue);
								break;

							case "XOR":
								result = (analyzeValue ^ keyValue);
								break;

							default:
								SnackBarManager.SnackBoxMessage.Enqueue($"Stream Cipher No operator exists");
								break;
						}

						result %= Modulo;

						if (result < 0)
							result = Modulo + result;

						result += 'a';
						Result += (char)result;
					}
					else
					{
						Result += analayze;
					}
				}
			}
			else
			{
				SnackBarManager.SnackBoxMessage.Enqueue($"Stream Cipher: Bad Calculation: Key is not equal to Decrypt text");
			}
		}
	}
}