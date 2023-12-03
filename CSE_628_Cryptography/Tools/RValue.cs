namespace CSE_628_Cryptography.Tools
{
	public class RValue
	{
		private string result = string.Empty;

		public int? R0 { get; set; } = null;
		public int? R1 { get; set; } = null;
		public int RiValue { get; set; }

		public string R0ToString() => R0 + "r₀";

		public string R1ToString() => R1 + "r₁ ";

		public string Result()
		{
			if (string.Empty == result)
			{
				if (R0 != null && R1 != null)
				{
					var isR0Larger = R0 > R1;

					var showMinus = isR0Larger && R1 > 0 || (!isR0Larger && R0 > 0 ? true : false);

					result = "(" + (isR0Larger ? R0 + "r₀ " : R1 + "r₁") + (showMinus ? " - " : " + ") + (!isR0Larger ? R0 + "r₀" : R1 + "r₁ ") + ") ";
				}
				else if (R0 == null)
				{
					result = $"[1]r₁";
				}
				else if (R1 == null)
				{
					result = $"[1]r₀";
				}
			}

			return result;
		}
	}
}