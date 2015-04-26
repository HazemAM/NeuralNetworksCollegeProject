using System;

namespace NeuralNetworks
{
	static class ActivationFunctions
	{
		/// <summary>The step (hard limit) function.</summary>
		/// <param name="num">The input to apply the function on.</param>
		/// <returns><value>1</value> if <paramref name="num"/> is bigger than or equal to 0,
		///		and <value>0</value> if <paramref name="num"/> is less than 0.</returns>
		public static int step(double num)
		{
			if(num >= 0) return 1;
					else return 0;
		}

		/// <summary>The signum (sign) function.</summary>
		/// <param name="num">The input to apply the function on.</param>
		/// <returns><value>1</value> if <paramref name="num"/> is bigger than 0, <value>0</value> if <paramref name="num"/> equals 0,
		///		and <value>-1</value> if <paramref name="num"/> is less than 0.</returns>
		public static int signum(double num)
		{
			if(num > 0)
				return 1;
			else if(num == 0)
				return 0;
			else 
				return -1;
		}

		/// <summary>The sigmoid function.</summary>
		public static double sigmoid(double num)
		{
			double exp = Math.Exp(-1 * num);
			return (1 / (1 + exp));
		}

		/// <summary>The derivative of the sigmoid function, given sigmoid function output as input.</summary>
		public static double sigmoidDiff(double sigmoidOut)
		{
			return sigmoidOut * (1 - sigmoidOut);
		}

		/// <summary>The tanh function.</summary>
		public static double tanh(double num)
		{
			return Math.Tanh(num);
		}

		/// <summary>The derivative of the tanh function.</summary>
		public static double tanhDiff(double num)
		{
			double tanhOut = tanh(num);
			return (1 - tanhOut) * (1 + tanhOut);
		}
	}
}
