using System;
using System.IO;

namespace NeuralNetworks.MultilayerNetworks
{
	public class BackPropagation : MultilayerNeuralNetwork
	{
		public BackPropagation(Layer[] layers, DataSetReader dataSet, double eta, int maxEpochs)
			: base(layers, dataSet, eta, maxEpochs)
		{
			//Nothing here.
		}

		public override void train()
		{
			int epochs = 0;
			double[][] outputValue,	//Holding output data for every iteration.
					   error;		//Holding error data for every iteration.
			double[] input;			//Holding input for every sample.

			while(epochs < this.maxEpochs)
			{
				while((input = this.dataSet.getNextTrainSample()) != null) //Samples loop.
				{
					error = new double[this.layer.Length][];


					/*
					* FORWARD STEP
					* Target vs. output
					*/
					outputValue = forwardStep(input);


					/*
					* BACKWARD STEP
					* Error calculations
					*/
					bool isOutputLayer = true;
					double tempPlus;
					int desiredOutput;
					for(int i = this.layer.Length - 1; i >= 0; i--) //The layers loop, REVERSED.
					{
						error[i] = new double[this.layer[i].nodes]; //Define error inner array of layer's neuron count.
						isOutputLayer = (i == this.layer.Length - 1);

						for(int j=0; j < this.layer[i].nodes; j++) //The neurons loop (for each layer).
						{
							error[i][j] = this.layer[i].neuron[j].activationFunctionDerivative(outputValue[i][j]);

							if(isOutputLayer){ //Special treatment for output layer.
								desiredOutput = (dataSet.currentTrainClass == j) ? 1 : 0;
								error[i][j] *= (desiredOutput - outputValue[i][j]);
							}
							else{
								tempPlus = 0;
								for(int k=0; k < this.layer[i + 1].nodes; k++)
									tempPlus += this.layer[i + 1].neuron[k].weight[j] * error[i + 1][k];
								error[i][j] *= tempPlus;
							}
						}
					}

					/* ITERATION CONTINUE CHECK */
					//TODO: Minimum error stopping condition?


					/*
					* SECOND FORWARD STEP
					* Weights update
					*/
					bool isFirstLayer = true;
					double tempMult = 0;
					for(int i=0; i < this.layer.Length; i++) //The layers loop.
					{
						isFirstLayer = (i == 0); //Indicates: This is the first layer after input layer.
						for(int j=0; j < this.layer[i].nodes; j++) //The neurons loop (for each layer).
						{
							this.layer[i].neuron[j].biasWeight += this.eta * error[i][j] * this.layer[i].neuron[j].bias; //Update bias weight.

							for(int k=0; k < this.layer[i].neuron[j].weight.Length; k++){ //Update other weights.
								tempMult = isFirstLayer ? input[k] : outputValue[i - 1][k];
								this.layer[i].neuron[j].weight[k] += this.eta * error[i][j] * tempMult;
							}
						}
					}
				} //End of sample loop.

				/* END OF CURRENT EPOCH */
				epochs++;
			} //End of mother loop.
		}

		private double[][] forwardStep(double[] input)
		{
			double[][] outputValue = new double[this.layer.Length][];

			int weightsCount;
			double tempNet = 0, tempMult = 0;
			bool isFirstLayer = true;
			for(int i=0; i < this.layer.Length; i++) //The layers loop.
			{
				outputValue[i] = new double[this.layer[i].nodes]; //Define output inner array of layer's neuron count.
				for(int j=0; j < this.layer[i].nodes; j++) //The neurons loop (for each layer).
				{
					tempNet = this.layer[i].neuron[j].biasWeight * this.layer[i].neuron[j].bias; //Interaction with bias.					
					isFirstLayer = (i == 0); //Indicates: This is the first layer after input layer.

					//In case weights doesn't equal previous layer's neurons:
					weightsCount = this.layer[i].neuron[j].weight.Length;
					if((i > 0 && weightsCount != this.layer[i - 1].nodes) || (i == 0 && weightsCount != input.Length))
						throw new ArgumentException("Neuron must have weight length of the previous layer's neurons");

					for(int k=0; k < weightsCount; k++){ //The weights loop (for each neuron).
						tempMult = isFirstLayer ? input[k] : outputValue[i - 1][k]; //If this is the first layer, multiply with input layer.
						tempNet += this.layer[i].neuron[j].weight[k] * tempMult;
					}

					outputValue[i][j] = this.layer[i].neuron[j].activationFunction(tempNet); //Calculating net for current neuron.
				}
			}

			return outputValue;
		}

		public override void loadWeights(string parentPath)
		{
			string weightsFormat = "weights_layer{0}neuron{1}.txt",
				   biasFormat = "bias_layer{0}neuron{1}.txt";

			string tempString;
			string[] tempSplit;
			double[] newWeights;
			double[] newBias;

			for(int i=0; i < this.layer.Length; i++)
				for(int j=0; j < this.layer[i].neuron.Length; j++){
					tempString = File.ReadAllText(parentPath + string.Format(weightsFormat, i, j));
					tempSplit = tempString.Split(',');
					newWeights = Array.ConvertAll(tempSplit, Convert.ToDouble);

					tempString = File.ReadAllText(parentPath + string.Format(biasFormat, i, j));
					tempSplit = tempString.Split(' ');
					newBias = Array.ConvertAll(tempSplit, Convert.ToDouble);

					if(this.layer[i].neuron[j].weight.Length != newWeights.Length)
						throw new ArgumentOutOfRangeException("New weights' count do not equal old weights' count");

					this.layer[i].neuron[j].weight = newWeights;
					this.layer[i].neuron[j].bias = newBias[0];
					this.layer[i].neuron[j].biasWeight = newBias[1];
				}
		}

		public override int classify(double[] input)
		{
			double[][] output = forwardStep(input);
			int max = VectorTools.maxIndex(output[output.Length - 1]);
			return max;
		}

		public override int[,] test()
		{
			int[,] confMatrix = new int[this.dataSet.classes, this.dataSet.classes];

			int classOut;
			double[] lineData;

			while((lineData = this.dataSet.getNextTestSample()) != null)
			{
				classOut = classify(lineData);
				confMatrix[this.dataSet.currentTestClass, classOut]++;
			}

			return confMatrix;
		}
	}
}
