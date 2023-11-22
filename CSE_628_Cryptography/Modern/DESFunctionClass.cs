using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;

namespace CSE_628_Cryptography.Modern
{
	public class DESFunctionClass : BaseViewModel
	{
		#region member variables

		private string _bit64 = "";
		private string _bit64Value = "";
		private string _calculateText = "";
		private string _crossResult = "";
		private string _expansionResult = "";
		private string _finalCrossResult = "";
		private bool _firstTime = true;
		private string _initialPermutationResult = "";
		private string _key = "";
		private string _keyPermutationResult = "";
		private string _keyShiftResult = "";
		private string _keyValue = "";
		private string _leftSide = "";
		private string _permutationResult = "";
		private string _rightSide = "";
		private int _round = 1;
		private string _roundKeyPermutationResult = "";
		private int _s1;
		private int _s2;
		private int _s3;
		private int _s4;
		private int _s5;
		private int _s6;
		private int _s7;
		private int _s8;
		private string _sBoxResult = "";
		private string _firstBitPosition = "";
		private string _sboxChanged = "";

		#region tables

		private List<int> ExpansionPermutation = new List<int>
		{
			32,  1,  2,  3,  4,  5,
			 4,  5,  6,  7,  8,  9,
			 8,  9, 10, 11, 12, 13,
			12, 13, 14, 15, 16, 17,
			16, 17, 18, 19, 20, 21,
			20, 21, 22, 23, 24, 25,
			24, 25, 26, 27, 28, 29,
			28, 29, 30, 31, 32,  1,
		};

		private List<int> InitialKeyPermutation = new List<int>
		{
			57, 49, 41, 33, 25, 17,  9,  1,
			58, 50, 42, 34, 26, 18, 10,  2,
			59, 51, 43, 35, 27, 19, 11,  3,
			60, 52, 44, 36, 63, 55, 47, 39,
			31, 23, 15,  7, 62, 54, 46, 38,
			30, 22, 14,  6, 61, 53, 45, 37,
			29, 21, 13,  5, 28, 20, 12,  4,
		};

		private List<int> InitialPermutation = new List<int>
		{
			58, 50, 42, 34, 26, 18, 10, 2,
			60, 52, 44, 36, 28, 20, 12, 4,
			62, 54, 46, 38, 30, 22, 14, 6,
			64, 56, 48, 40, 32, 24, 16, 8,
			57, 49, 41, 33, 25, 17,  9, 1,
			59, 51, 43, 35, 27, 19, 11, 3,
			61, 53, 45, 37, 29, 21, 13, 5,
			63, 55, 47, 39, 31, 23, 15, 7,
		};

		private List<int> Permutation = new List<int>
		{
			16,  7, 20, 21, 29, 12, 28, 17,
			 1, 15, 23, 26,  5, 18, 31, 10,
			 2,  8, 24, 14, 32, 27,  3,  9,
			19, 13, 30,  6, 22, 11,  4, 25,
		};

		private List<int> RoundKeyPermutation = new List<int>
		{
			14, 17, 11, 24,  1,  5,  3, 28,
			15,  6, 21, 10, 23, 19, 12,  4,
			26,  8, 16,  7, 27, 20, 13,  2,
			41, 52, 31, 37, 47, 55, 30, 40,
			51, 45, 33, 48, 44, 49, 39, 56,
			34, 53, 46, 42, 50, 36, 29, 32,
		};

		private Dictionary<int, List<int>> S1 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 14, 04, 13, 01, 02, 15, 11, 08, 03, 10, 06, 12, 05, 09, 00, 07}},
			{1, new List<int>{ 00, 15, 07, 04, 14, 02, 13, 01, 10, 06, 12, 11, 09, 05, 03, 08}},
			{2, new List<int>{ 04, 01, 14, 08, 13, 06, 02, 11, 15, 12, 09, 07, 03, 10, 05, 00}},
			{3, new List<int>{ 15, 12, 08, 02, 04, 09, 01, 07, 05, 11, 03, 14, 10, 00, 06, 13}},
		};

		private Dictionary<int, List<int>> S2 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 15, 01, 08, 14, 06, 11, 03, 04, 09, 07, 02, 13, 12, 00, 05, 10}},
			{1, new List<int>{ 03, 13, 04, 07, 15, 02, 08, 14, 12, 00, 01, 10, 06, 09, 11, 05}},
			{2, new List<int>{ 00, 14, 07, 11, 10, 04, 13, 01, 05, 08, 12, 06, 09, 03, 02, 15}},
			{3, new List<int>{ 13, 08, 10, 01, 03, 15, 04, 02, 11, 06, 07, 12, 00, 05, 14, 09}},
		};

		private Dictionary<int, List<int>> S3 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 10, 00, 09, 14, 06, 03, 15, 05, 01, 13, 12, 07, 11, 04, 02, 08}},
			{1, new List<int>{ 13, 07, 00, 09, 03, 04, 06, 10, 02, 08, 05, 14, 12, 11, 15, 01}},
			{2, new List<int>{ 13, 06, 04, 09, 08, 15, 03, 00, 11, 01, 02, 12, 05, 10, 14, 07}},
			{3, new List<int>{ 01, 10, 13, 00, 06, 09, 08, 07, 04, 15, 14, 03, 11, 05, 02, 12}},
		};

		private Dictionary<int, List<int>> S4 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 07, 13, 14, 03, 00, 06, 09, 10, 01, 02, 08, 05, 11, 12, 04, 15}},
			{1, new List<int>{ 13, 08, 11, 05, 06, 15, 00, 03, 04, 07, 02, 12, 01, 10, 14, 09}},
			{2, new List<int>{ 10, 06, 09, 00, 12, 11, 07, 13, 15, 01, 03, 14, 05, 02, 08, 04}},
			{3, new List<int>{ 03, 15, 00, 06, 10, 01, 13, 08, 09, 04, 05, 11, 12, 07, 02, 14}},
		};

		private Dictionary<int, List<int>> S5 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 02, 12, 04, 01, 07, 10, 11, 06, 08, 05, 03, 15, 13, 00, 14, 09}},
			{1, new List<int>{ 14, 11, 02, 12, 04, 07, 13, 01, 05, 00, 15, 10, 03, 09, 08, 06}},
			{2, new List<int>{ 04, 02, 01, 11, 10, 13, 07, 08, 15, 09, 12, 05, 06, 03, 00, 14}},
			{3, new List<int>{ 11, 08, 12, 07, 01, 14, 02, 13, 06, 15, 00, 09, 10, 04, 05, 03}},
		};

		private Dictionary<int, List<int>> S6 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 12, 01, 10, 15, 09, 02, 06, 08, 00, 13, 03, 04, 14, 07, 05, 11}},
			{1, new List<int>{ 10, 15, 04, 02, 07, 12, 09, 05, 06, 01, 13, 14, 00, 11, 03, 08}},
			{2, new List<int>{ 09, 14, 15, 05, 02, 08, 12, 03, 07, 00, 04, 10, 01, 13, 11, 06}},
			{3, new List<int>{ 04, 03, 02, 12, 09, 05, 15, 10, 11, 14, 01, 07, 06, 00, 08, 13}},
		};

		private Dictionary<int, List<int>> S7 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 04, 11, 02, 14, 15, 00, 08, 13, 03, 12, 09, 07, 05, 10, 06, 01}},
			{1, new List<int>{ 13, 00, 11, 07, 04, 09, 01, 10, 14, 03, 05, 12, 02, 15, 08, 06}},
			{2, new List<int>{ 01, 04, 11, 13, 12, 03, 07, 14, 10, 15, 06, 08, 00, 05, 09, 02}},
			{3, new List<int>{ 06, 11, 13, 08, 01, 04, 10, 07, 09, 05, 00, 15, 14, 02, 03, 12}},
		};

		private Dictionary<int, List<int>> S8 = new Dictionary<int, List<int>>
		{
			{0, new List<int>{ 13, 02, 08, 04, 06, 15, 11, 01, 10, 09, 03, 14, 05, 00, 12, 07}},
			{1, new List<int>{ 01, 15, 13, 08, 10, 03, 07, 04, 12, 05, 06, 11, 00, 14, 09, 02}},
			{2, new List<int>{ 07, 11, 04, 01, 09, 12, 14, 02, 00, 06, 10, 13, 15, 03, 05, 08}},
			{3, new List<int>{ 02, 01, 14, 07, 04, 10, 08, 13, 15, 12, 09, 00, 03, 05, 06, 11}},
		};

		private List<int> shiftLeftRounds = new List<int>()
		{
			1,2,9,16
		};

		#endregion tables

		#endregion member variables

		#region properties

		public string Bit64
		{
			get => _bit64;
			set
			{
				_bit64 = value;
				OnPropertyChanged(nameof(Bit64));
			}
		}

		public string Bit64Value
		{
			get => _bit64Value;
			set
			{
				_bit64Value = value;
				_firstTime = true;
				_round = 1;
				SetCalculate();
				OnPropertyChanged(nameof(Bit64Value));
			}
		}

		public string CrossResult
		{
			get => _crossResult;
			set
			{
				_crossResult = value;
				OnPropertyChanged(nameof(CrossResult));
			}
		}

		public string ExpansionResult
		{
			get => _expansionResult;
			set
			{
				_expansionResult = value;
				OnPropertyChanged(nameof(ExpansionResult));
			}
		}

		public string FinalCrossResult
		{
			get => _finalCrossResult;
			set
			{
				_finalCrossResult = value;
				OnPropertyChanged(nameof(FinalCrossResult));
			}
		}

		public string InitialPermutationResult
		{
			get => _initialPermutationResult;
			set
			{
				_initialPermutationResult = value;
				OnPropertyChanged(nameof(InitialPermutationResult));
			}
		}

		public string Key
		{
			get => _key;
			set
			{
				_key = value;
				OnPropertyChanged(nameof(Key));
				_firstTime = true;
				_round = 1;
				SetCalculate();
			}
		}

		public string KeyPermutationResult
		{
			get => _keyPermutationResult;
			set
			{
				_keyPermutationResult = value;
				OnPropertyChanged(nameof(KeyPermutationResult));
			}
		}

		public string KeyShiftResult
		{
			get => _keyShiftResult;
			set
			{
				_keyShiftResult = value;
				OnPropertyChanged(nameof(KeyShiftResult));
			}
		}

		public string KeyValue
		{
			get => _keyValue;
			set
			{
				_keyValue = value;
				OnPropertyChanged(nameof(KeyValue));
			}
		}

		public string LeftSide
		{
			get => _leftSide;
			set
			{
				_leftSide = value;
				OnPropertyChanged(nameof(LeftSide));
			}
		}

		public string PermutationResult
		{
			get => _permutationResult;
			set
			{
				_permutationResult = value;
				OnPropertyChanged(nameof(PermutationResult));
			}
		}

		public string RightSide
		{
			get => _rightSide;
			set
			{
				_rightSide = value;
				OnPropertyChanged(nameof(RightSide));
			}
		}

		public string RoundKeyPermutationResult
		{
			get => _roundKeyPermutationResult;
			set
			{
				_roundKeyPermutationResult = value;
				OnPropertyChanged(nameof(RoundKeyPermutationResult));
			}
		}

		public int S1Result
		{
			get => _s1;
			set
			{
				_s1 = value;
				OnPropertyChanged(nameof(S1Result));
			}
		}

		public int S2Result
		{
			get => _s2;
			set
			{
				_s2 = value;
				OnPropertyChanged(nameof(S2Result));
			}
		}

		public int S3Result
		{
			get => _s3;
			set
			{
				_s3 = value;
				OnPropertyChanged(nameof(S3Result));
			}
		}

		public int S4Result
		{
			get => _s4;
			set
			{
				_s4 = value;
				OnPropertyChanged(nameof(S4Result));
			}
		}

		public int S5Result
		{
			get => _s5;
			set
			{
				_s5 = value;
				OnPropertyChanged(nameof(S5Result));
			}
		}

		public int S6Result
		{
			get => _s6;
			set
			{
				_s6 = value;
				OnPropertyChanged(nameof(S6Result));
			}
		}

		public int S7Result
		{
			get => _s7;
			set
			{
				_s7 = value;
				OnPropertyChanged(nameof(S7Result));
			}
		}

		public int S8Result
		{
			get => _s8;
			set
			{
				_s8 = value;
				OnPropertyChanged(nameof(S8Result));
			}
		}

		public string SBoxResult
		{
			get => _sBoxResult;
			set
			{
				_sBoxResult = value;
				OnPropertyChanged(nameof(SBoxResult));
			}
		}

		public string Calculate
		{
			get => _calculateText;
			set
			{
				_calculateText = value;
				OnPropertyChanged(nameof(Calculate));
			}
		}

		public string FirstBitPosition
		{
			get => _firstBitPosition;
			set
			{
				_firstBitPosition = value;
				OnPropertyChanged(nameof(FirstBitPosition));
			}
		}


		public string SboxChanged 
		{ 
			get => _sboxChanged;
			set
			{
				_sboxChanged = value;
				OnPropertyChanged(nameof(SboxChanged));
			}
		}


		#endregion properties

		#region commands

		public Command Add64BitsToBits64Command
		{
			get;
			private set;
		}

		public Command Add64BitsToKeySideCommand
		{
			get;
			private set;
		}

		public Command CalculateCommand
		{
			get;
			private set;
		}
	
		#endregion commands

		#region Constructor

		public DESFunctionClass()
		{
			CalculateCommand = new Command(() => CalculateResults());
			Add64BitsToBits64Command = new Command(() => Bit64 = AddBitsToString(64, Bit64Value));
			Add64BitsToKeySideCommand = new Command(() => Key = AddBitsToString(64, KeyValue));
			SetCalculate();
		}

		#endregion Constructor

		#region Methods

		public void CalculateCross()
		{
			FinalCrossResult = "";

			for (int i = 0; i < 32; i++)
			{
				FinalCrossResult += PermutationResult[i] ^ LeftSide[i];
			}
		}

		public void CalculateCrossWithKey()
		{
			CrossResult = "";
			for (int i = 0; i < 48; i++)
			{
				var expansionBit = int.Parse(ExpansionResult[i].ToString());
				var keyBit = int.Parse(RoundKeyPermutationResult[i].ToString());

				CrossResult += (expansionBit ^ keyBit).ToString();
			}
		}

		public void CalculateExpansion()
		{
			ExpansionResult = "";
			foreach (var bit in ExpansionPermutation)
			{
				ExpansionResult += RightSide[bit - 1];
			}
		}

		public void CalculateFinalPermuation()
		{
			PermutationResult = "";

			foreach (var bit in Permutation)
			{
				PermutationResult += SBoxResult[bit - 1];
			}
		}

		public void CalculateInitialPermuation()
		{
			InitialPermutationResult = "";

			foreach (var bit in InitialPermutation)
			{
				InitialPermutationResult += Bit64[bit - 1];
			}

			LeftSide = InitialPermutationResult.Substring(0, 32);
			RightSide = InitialPermutationResult.Substring(32, 32);
		}

		public void CalculateResults()
		{
			if (Bit64.Length > 0 && Key.Length > 0)
			{
				if (_firstTime)
				{
					CalculateInitialPermuation();
					CalculateInitialKeyPermutation();
					_firstTime = false;
				}
				else
				{
					LeftSide = RightSide;
					RightSide = FinalCrossResult;
				}

				CalculateExpansion();
				CalculateKeyShift();

				CalculateCrossWithKey();
				CalculateSBox();
				CalculateFinalPermuation();
				CalculateCross();
				_round++;
				SetCalculate();
				SetFirstBitAndSBox();
			}
		}

		private void SetFirstBitAndSBox()
		{
			var value = RoundKeyPermutationResult.IndexOf('1') + 1;
			FirstBitPosition = value.ToString();

			var result = (value / 6);
			if (value % 6 == 0) 
			{
				SboxChanged = result.ToString();
			}
			else
			{
				SboxChanged = (result + 1).ToString();
			}
			

		}

		public void CalculateSBox()
		{
			SBoxResult = "";

			var crossResultsSplit = new List<Tuple<string, string>>();
			for (int i = 0; i < 8; i++)
			{
				var bits = CrossResult.Substring(i * 6, 6);

				crossResultsSplit.Add(new Tuple<string, string>(bits[0].ToString() + bits[5].ToString(), bits.Substring(1, 4)));
			}

			S1Result = S1[GetRow(crossResultsSplit[0].Item1)][GetColumn(crossResultsSplit[0].Item2)];
			S2Result = S2[GetRow(crossResultsSplit[1].Item1)][GetColumn(crossResultsSplit[1].Item2)];
			S3Result = S3[GetRow(crossResultsSplit[2].Item1)][GetColumn(crossResultsSplit[2].Item2)];
			S4Result = S4[GetRow(crossResultsSplit[3].Item1)][GetColumn(crossResultsSplit[3].Item2)];
			S5Result = S5[GetRow(crossResultsSplit[4].Item1)][GetColumn(crossResultsSplit[4].Item2)];
			S6Result = S6[GetRow(crossResultsSplit[5].Item1)][GetColumn(crossResultsSplit[5].Item2)];
			S7Result = S7[GetRow(crossResultsSplit[6].Item1)][GetColumn(crossResultsSplit[6].Item2)];
			S8Result = S8[GetRow(crossResultsSplit[7].Item1)][GetColumn(crossResultsSplit[7].Item2)];

			SBoxResult += ConvertToBit(S1Result);
			SBoxResult += ConvertToBit(S2Result);
			SBoxResult += ConvertToBit(S3Result);
			SBoxResult += ConvertToBit(S4Result);
			SBoxResult += ConvertToBit(S5Result);
			SBoxResult += ConvertToBit(S6Result);
			SBoxResult += ConvertToBit(S7Result);
			SBoxResult += ConvertToBit(S8Result);
		}

		public int GetColumn(string column)
		{
			int result = 0;
			switch (column)
			{
				case "0000":
					result = 0;
					break;

				case "0001":
					result = 1;
					break;

				case "0010":
					result = 2;
					break;

				case "0011":
					result = 3;
					break;

				case "0100":
					result = 4;
					break;

				case "0101":
					result = 5;
					break;

				case "0110":
					result = 6;
					break;

				case "0111":
					result = 7;
					break;

				case "1000":
					result = 8;
					break;

				case "1001":
					result = 9;
					break;

				case "1010":
					result = 10;
					break;

				case "1011":
					result = 11;
					break;

				case "1100":
					result = 12;
					break;

				case "1101":
					result = 13;
					break;

				case "1110":
					result = 14;
					break;

				case "1111":
					result = 15;
					break;
			}
			return result;
		}

		public int GetRow(string row)
		{
			int result = 0;
			switch (row)
			{
				case "00":
					result = 0;
					break;

				case "01":
					result = 1;
					break;

				case "10":
					result = 2;
					break;

				case "11":
					result = 3;
					break;
			}
			return result;
		}

		private string AddBitsToString(int numberOfBits, string value)
		{
			var results = "";
			for (int i = 0; i < numberOfBits; i++)
			{
				results += value;
			}
			return results;
		}

		private void CalculateInitialKeyPermutation()
		{
			KeyPermutationResult = "";

			foreach (var bit in InitialKeyPermutation)
			{
				KeyPermutationResult += Key[bit - 1];
			}

			KeyShiftResult = KeyPermutationResult;
		}

		private void CalculateKeyShift()
		{
			ShiftKeyLeft();
			if (!shiftLeftRounds.Contains(_round))
			{
				ShiftKeyLeft();
			}

			CalculateRoundKeyPermutation();
		}

		private void CalculateRoundKeyPermutation()
		{
			RoundKeyPermutationResult = "";

			foreach (var bit in RoundKeyPermutation)
			{
				RoundKeyPermutationResult += KeyShiftResult[bit - 1];
			}
		}

		private string ConvertToBit(int value)
		{
			var bits = Convert.ToString(value, 2).PadLeft(4, '0');
			return bits;
		}

		private void SetCalculate()
		{
			Calculate = "Calculate Round " + _round.ToString();
		}

		private void ShiftKeyLeft()
		{
			var leftSide = KeyShiftResult.Substring(0, 28);
			var rightSide = KeyShiftResult.Substring(28, 28);

			KeyShiftResult = leftSide.Substring(1);
			KeyShiftResult += leftSide[0];
			KeyShiftResult += rightSide.Substring(1);
			KeyShiftResult += rightSide[0];
		}

		#endregion Methods
	}
}