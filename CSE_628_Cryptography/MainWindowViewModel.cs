using CSE_628_Cryptography.Ciphers;
using CSE_628_Cryptography.Frequencies;
using CSE_628_Cryptography.Modern;
using CSE_628_Cryptography.MultiplicativeInverse;
using CSE_628_Cryptography.Tools;
using MaterialDesignThemes.Wpf;
using MvvmHelpers;

namespace CSE_628_Cryptography
{
	public class MainWindowViewModel : BaseViewModel
	{
		public AdvancedEuclideanAlgorithm AdvancedEuclideanAlgorithm
		{
			get;
			set;
		} = new AdvancedEuclideanAlgorithm();

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

		public CalculateFactors CalculateFactors
		{
			get;
			set;
		} = new CalculateFactors();

		public DESFunctionClass DESFunctionClass
		{
			get;
			set;
		} = new DESFunctionClass();

		public DiffieHellmanCalculator DiffieHellmanCalculator
		{
			get;
			set;
		} = new DiffieHellmanCalculator();

		public FactorClass Factors
		{
			get;
			set;
		} = new FactorClass();

		public FiAlgorithm FiAlgorithm
		{
			get;
			set;
		} = new FiAlgorithm();

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

		public SnackbarMessageQueue SnackBoxMessage
		{
			get;
			set;
		} = new SnackbarMessageQueue();

		public SquareAndMultiply SquareAndMultiply
		{
			get;
			set;
		} = new SquareAndMultiply();

		public StreamCipher StreamCipherClass
		{
			get;
			set;
		} = new StreamCipher();
	}
}