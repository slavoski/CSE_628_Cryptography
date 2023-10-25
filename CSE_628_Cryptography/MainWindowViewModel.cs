using CSE_628_Cryptography.Ciphers;
using CSE_628_Cryptography.Frequencies;
using CSE_628_Cryptography.MultiplicativeInverse;
using CSE_628_Cryptography.Tools;
using MvvmHelpers;

namespace CSE_628_Cryptography
{
	public class MainWindowViewModel : BaseViewModel
	{
		public AffineCipherClass AffineCipherClass
		{
			get;
			set;
		} = new AffineCipherClass();

		public Caeser CaeserCipher
		{
			get;
			set;
		} = new Caeser();

		public FactorClass Factors
		{
			get;
			set;
		} = new FactorClass();

		public GCDClass GCD
		{
			get;
			set;
		} = new GCDClass();

		public MultiplicativeInverseClass MultiplicativeInverse
		{
			get;
			set;
		} = new MultiplicativeInverseClass();

		public RelativeFrequencies RelativeFrequencies
		{
			get;
			set;
		} = new RelativeFrequencies();

		public RelativePrimeClass RelativePrimeClass
		{
			get;
			set;
		} = new RelativePrimeClass();
	}
}