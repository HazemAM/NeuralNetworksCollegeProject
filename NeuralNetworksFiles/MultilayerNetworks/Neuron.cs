using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class Neuron
	{
		public delegate double ActivationFunction(double num);

		public double[] weight;
		public double bias;
		public double biasWeight;
		public readonly ActivationFunction activationFunction;
		public readonly ActivationFunction activationFunctionDerivative;

		public Neuron(double[] weights, double bias, double biasWeight,
			ActivationFunction activationFunction, ActivationFunction activationFunctionDerivative)
		{
			this.weight = weights;
			this.bias = bias;
			this.biasWeight = biasWeight;
			this.activationFunction = activationFunction;
			this.activationFunctionDerivative = activationFunctionDerivative;
		}
	}
}
