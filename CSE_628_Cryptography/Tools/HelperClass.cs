using System.Collections.Generic;
using System.Linq;

namespace CSE_628_Cryptography.Tools
{
	public static class HelperClass
	{
		public static List<int> CalculateFactors(int value)
		{
			var results = new List<int>();

			for (int i = 1; i <= value; i++)
			{
				if (value % i == 0)
				{
					results.Add(i);
				}
			}

			return results;
		}

		public static int CalculateGCD(int x, int y)
		{
			var gcd = 1;
			var xFactors = CalculateFactors(x);
			var yFactors = CalculateFactors(y);
			var results = xFactors?.Intersect(yFactors);

			if (results != null && results.Any())
				gcd = results.Last();

			return gcd;
		}
	}
}