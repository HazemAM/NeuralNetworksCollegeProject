using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class Layer
	{
		public readonly Neuron[] neuron;
		public readonly double[] value;
		public readonly int nodes;

		public Layer(Neuron[] neurons)
		{
			this.neuron = neurons;
			this.nodes = neuron.Length;
		}

		public Layer(Neuron neuron)
		{
			this.neuron = new Neuron[]{neuron};
			this.nodes = 1;
		}

		public Layer(double[] values)
		{
			this.value = values;
			this.nodes = value.Length;
		}
	}
}
