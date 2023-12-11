using MvvmHelpers;
using MvvmHelpers.Commands;
using System;

namespace CSE_628_Cryptography.Tools
{
	public class DiffieHellmanCalculator : BaseViewModel
	{
		#region member variables

		private int _a;
		private int _alpha;
		private int _b;
		private int _p;

		private double _pkA;
		private double _pkB;
		private double _ckA;
		private double _ckB;

		#endregion member variables

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

		public int Alpha
		{
			get => _alpha;
			set
			{
				_alpha = value;
				OnPropertyChanged(nameof(Alpha));
			}
		}

		public int B
		{
			get => _b;
			set
			{
				_b = value;
				OnPropertyChanged(nameof(B));
			}
		}

		public Command CalculateDFKECommand
		{
			get;
			private set;
		}

		public int P
		{
			get => _p;
			set
			{
				_p = value;
				OnPropertyChanged(nameof(P));
			}
		}

		public double PKA
		{
			get => _pkA;
			set
			{
				_pkA = value;
				OnPropertyChanged(nameof(PKA));
			}
		}

		public double PKB
		{
			get => _pkB;
			set
			{
				_pkB = value;
				OnPropertyChanged(nameof(PKB));
			}
		}

		public double CKA
		{
			get => _ckA;
			set
			{
				_ckA = value;
				OnPropertyChanged(nameof(CKA));
			}
		}

		public double CKB
		{
			get => _ckB;
			set
			{
				_ckB = value;
				OnPropertyChanged(nameof(CKB));
			}
		}

		public ObservableRangeCollection<string> Results
		{
			get;
			set;
		} = new ObservableRangeCollection<string>();

		#endregion properties

		#region constructor

		public DiffieHellmanCalculator()
		{
			CalculateDFKECommand = new Command(() => CalculateDFKE());
		}

		#endregion constructor

		#region methods

		public void CalculateDFKE()
		{
			Results.Clear();

			


			PKA = Math.Pow(Alpha, A) % P;
			PKB = Math.Pow(Alpha, B) % P;
			var ckaValue = Math.Pow(PKA, B);
			var ckbValue = Math.Pow(PKB, A);
			CKA = CalculateSquareandMultiply(Convert.ToInt32(PKA), B, P);
			CKB = CalculateSquareandMultiply(Convert.ToInt32(PKB), A, P);

			Results.Add($"A {GetPublicKey(A, PKA)}");
			Results.Add($"B {GetPublicKey(B, PKB)}");
			Results.Add($"B^a {GetPrivateKey(PKB, A, ckbValue, CKA)}");
			Results.Add($"A^b {GetPrivateKey(PKA, B, ckaValue, CKB)}");
		}

		private string GetPrivateKey(double leftValue, int rightValue, double finalValue, double modValue)
		{
			var result = $"= {leftValue}^{rightValue} mod {P} = {finalValue} mod {P} = {modValue} mod {P} ";

			return result;
		}

		private string GetPublicKey(int value, double newValue) =>
					$"= {Alpha}^{value} mod {P} = {newValue} mod {P}";

		private double CalculateSquareandMultiply(int x, int e, int m)
		{
			var square = new SquareAndMultiply
			{
				X = x,
				E = e,
				M = m
			};

			square.CalculateSquareandMultiply();

			return square.Result;
		}

		#endregion methods
	}
}