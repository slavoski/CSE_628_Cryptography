using CSE_628_Cryptography.Ciphers;
using CSE_628_Cryptography.Frequencies;
using CSE_628_Cryptography.MultiplicativeInverse;
using MvvmHelpers;

namespace CSE_628_Cryptography
{
	public class MainWindowViewModel : BaseViewModel
	{
		private MultiplicativeInverseClass multiplicativeInverse = new MultiplicativeInverseClass();
		private RelativeFrequencies relativeFrequencies = new RelativeFrequencies();

		public Caeser CaeserCipher
		{
			get;
			set;
		} = new Caeser();

		public MultiplicativeInverseClass MultiplicativeInverse
		{
			get => multiplicativeInverse;
			set
			{
				multiplicativeInverse = value;
				OnPropertyChanged(nameof(MultiplicativeInverse));
			}
		}

		public RelativeFrequencies RelativeFrequencies
		{
			get => relativeFrequencies;
			set
			{
				relativeFrequencies = value;
				OnPropertyChanged(nameof(RelativeFrequencies));
			}
		}
	}
}