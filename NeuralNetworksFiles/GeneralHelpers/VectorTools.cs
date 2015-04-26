using System;

namespace NeuralNetworks
{
	static class VectorTools
	{
		/*
		 * MULTIPLICATIONS
		 */
		public static double multiply(double[] arrOne, double[] arrTwo)
		{
			if(arrOne.Length != arrTwo.Length)
				throw new ArgumentException("The two vectors are not of the same length");
			
			double result = 0;
			for(int i=0; i<arrOne.Length; i++)
				result += arrOne[i] * arrTwo[i];

			return result;
		}

		public static double[] multiply(double[] arr, double value)
		{
			double[] result = new double[arr.Length];
			for(int i=0; i<arr.Length; i++)
				result[i] = arr[i] * value;

			return result;
		}


		/*
		 * SUMMATIONS
		 */
		public static double[] sum(double[] arrOne, double[] arrTwo)
		{
			if(arrOne.Length != arrTwo.Length)
				throw new ArgumentException("The two vectors are not of the same length");
			
			double[] result = new double[arrOne.Length];
			for(int i=0; i<arrOne.Length; i++)
				result[i] = arrOne[i] + arrTwo[i];

			return result;
		}

		/*
		 * OTHERS
		 */
		public static double[] trim(double[] arr, double[] mask)
		{
			if(arr.Length == mask.Length)
				return arr;
			else if(mask.Length > arr.Length)
				throw new ArgumentOutOfRangeException("Trimming length is bigger than the vector length");

			double[] newArr = new double[mask.Length];

			int index;
			for(int i=0; i<newArr.Length; i++){
				if(mask[i] > arr.Length) throw new FormatException("Bad mask index");
				index = (int)mask[i] - 1;
				newArr[i] = arr[index];
			}

			return newArr;
		}

		public static double[] ones(int length)
		{
			double[] result = new double[length];
			for(int i=0; i < result.Length; i++)
				result[i] = 1;

			return result;
		}

		public static double[] zeros(int length)
		{
			double[] result = new double[length];
			for(int i=0; i < result.Length; i++)
				result[i] = 0;

			return result;
		}

		public static double[] sequence(int length)
		{
			double[] result = new double[length];
			for(int i=0; i < result.Length; i++)
				result[i] = i+1;

			return result;
		}

		private static int count(double[] arr, double num)
		{
			int result = 0;
			foreach(double e in arr)
				if(e == num) result++;
			
			return result;
		}

		/// <summary>Calculates the accuracy of a confusion matrix.</summary>
		/// <param name="matrix">The confusion matrix.</param>
		/// <returns>The accuracy of the confusion matrix.</returns>
		public static double confusionAccuracy(int[,] matrix)
		{
			int sum;
			double accuracy = 0;
			for(int i=0; i<matrix.GetLength(0); i++){
				sum = 0;
				for(int j=0; j<matrix.GetLength(1); j++)
					sum += matrix[i,j];
				accuracy += (double)matrix[i,i] / (double)sum;
			}

			accuracy /= matrix.GetLength(0);
			return accuracy;
		}

		public static double[] prepend(double[] arr, double p)
		{
			double[] newArr = new double[arr.Length + 1];
			newArr[0] = p;

			Array.Copy(arr, 0, newArr, 1, arr.Length);
			return newArr;
		}

		/// <summary>Finds the maximum in a double array.</summary>
		/// <returns>The maximum value.</returns>
		public static double max(double[] arr)
		{
			double size = arr.Length;
			double max = double.NegativeInfinity;

			for(int i = 0; i < size; i++)
				max = arr[i] > max ? arr[i] : max;

			return max;
		}

		/// <summary>Finds the maximum in a double array.</summary>
		/// <returns>The index of maximum value.</returns>
		public static int maxIndex(double[] arr)
		{
			double size = arr.Length;
			int max = 0;

			for(int i = 0; i < size; i++)
				max = arr[i] > arr[max] ? i : max;

			return max;
		}

		public static double max(System.Collections.Generic.List<double[]> list, double[] featureMask)
		{
			double max = double.NegativeInfinity;

			int f; //Feature index.
			for(int i=0; i < list.Count; i++)
				for(int j=0; j < featureMask.Length; j++){
					f = (int)featureMask[j] - 1;
					max = list[i][f] > max ? list[i][f] : max;
				}

			return max;
		}

		public static double min(System.Collections.Generic.List<double[]> list, double[] featureMask)
		{
			double min = double.PositiveInfinity;

			int f; //Feature index.
			for(int i=0; i < list.Count; i++)
				for(int j=0; j < featureMask.Length; j++){
					f = (int)featureMask[j] - 1;
					min = list[i][f] < min ? list[i][f] : min;
				}

			return min;
		}

		/// <summary>Finds the minimum in a double array.</summary>
		/// <returns>The index of minimum value.</returns>
		public static int minIndex(double[] arr)
		{
			double size = arr.Length;
			int max = 0;

			for(int i = 0; i < size; i++)
				max = arr[i] < arr[max] ? i : max;

			return max;
		}

        public static double mean(double[] vec)
        {
            double size = vec.Length;
            double res = 0;
            for (int i = 0; i < size; i++)
                res += vec[i];
            res /= size;
            return res;
        }

        public static double[] get1D(double[][] array)
        {
            int D1=array.Length, D2=array[0].Length;
            double[] res = new double[D1 * D2];
            int count=0;
            for(int i=0;i<D1;i++)
                for (int j = 0; j < D2; j++)
                {
                    res[count] = array[i][j];
                    count++;
                }
            return res;
        }
    }
}
