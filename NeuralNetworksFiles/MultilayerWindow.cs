using System;
using System.Windows.Forms;
using NeuralNetworks.MultilayerNetworks;

namespace NeuralNetworks
{
	public partial class MultilayerWindow : Form
	{
		static string originPath = "../../../DataSets/HeadOrientation/";
		DataSetReader headDataSet = new DataSetReader(originPath, DataSetType.HeadOrientation, true);
		MultilayerNeuralNetwork network;

		public MultilayerWindow()
		{
			InitializeComponent();
		}

		private void constructNetwork()
		{
			if(chkBestModel.Checked){
				loadBestModel();
				return;
			}

			int neuronsCount = (int)numNeurons.Value;
			int layersCount = (int)numLayers.Value;
			int biasValue = (int)numBias.Value;

			Layer[] layers = new Layer[layersCount];

			//First layer:
			Neuron[] firstNeurons = new Neuron[neuronsCount];
			for(int i=0; i < firstNeurons.Length; i++)
				firstNeurons[i] = new Neuron(VectorTools.zeros(headDataSet.featuresPerSample), biasValue, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff);
			layers[0] = new Layer(firstNeurons);

			//Middle hidden layers:
			for(int l = 1; l < layersCount - 1; l++)
			{
				Neuron[] tempNeurons = new Neuron[neuronsCount];
				for(int i=0; i < tempNeurons.Length; i++)
					tempNeurons[i] = new Neuron(VectorTools.zeros(neuronsCount), biasValue, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff);
				layers[l] = new Layer(tempNeurons);
			}

			//Output layer:
			Neuron[] lastNeurons = new Neuron[3];
			for(int i=0; i < lastNeurons.Length; i++)
				lastNeurons[i] = new Neuron(VectorTools.zeros(neuronsCount), biasValue, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff);
			layers[layersCount - 1] = new Layer(lastNeurons);


			//Constructing:
			double eta = (double)numEta.Value;
			int epochs = (int)numMaxEpochs.Value;
			network = new BackPropagation(layers, headDataSet, eta, epochs);
		}
        private void TestRBF()
        {
            //need to look into random init vectors from -1 to 1
            int numCluster = 3;
            Layer output = new Layer(
                new Neuron[] {
					new Neuron(VectorTools.zeros(numCluster), 1, 0, null, null),
					new Neuron(VectorTools.zeros(numCluster), 1, 0, null, null),
					new Neuron(VectorTools.zeros(numCluster), 1, 0, null, null),
				}
                );
            double eta = 0.25;
            int epochs = 50;
            network = new RBF(new Layer[] { output }, headDataSet, eta, epochs, numCluster);
        }
		private void loadBestModel()
		{
			Layer hidden = new Layer(
				new Neuron[] {
					new Neuron(VectorTools.zeros(headDataSet.featuresPerSample), 1, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(VectorTools.zeros(headDataSet.featuresPerSample), 1, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(VectorTools.zeros(headDataSet.featuresPerSample), 1, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff)
				}
			);
			Layer output = new Layer(
				new Neuron[] {
					new Neuron(VectorTools.zeros(3), 1, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(VectorTools.zeros(3), 1, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(VectorTools.zeros(3), 1, 0, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff)
				}
			);

			double eta = 0.25;
			int epochs = 50;
			network = new BackPropagation(new Layer[] { hidden, output }, headDataSet, eta, epochs);
		}

		private void btnTrainMachine_Click(object sender, EventArgs e)
		{
			//constructNetwork();
            TestRBF();
			//Training:
			if(chkBestModel.Checked)
				network.loadWeights(originPath + "Training/(trained_weights)/");
			else
				network.train();

			//Enable testing after training is finished:
			btnTestMachine.Enabled = true;
			btnClassify.Enabled = true;
		}

		private void btnTestMachine_Click(object sender, EventArgs e)
		{
			//Testing:
			int[,] testMatrix = network.test();

			UiTools.drawMatrix(gridConfMatrix, testMatrix);
			double accuracy = VectorTools.confusionAccuracy(testMatrix);
			lblAccuracy.Text = Math.Round(accuracy, 4).ToString();
		}

		private void btnClassify_Click(object sender, EventArgs e)
		{
			if(network == null)
				return;

			double[] sampleData = headDataSet.readImage(txtClassifyPath.Text);
			int classOut = network.classify(sampleData);
			txtClassifyOutput.Text = headDataSet.classLabels[classOut] + " (" + (classOut + 1).ToString() + ")";
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			//Configurations:
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "PNG images|*.png";
			dialog.DefaultExt = ".*";

			//Show the dialog:
			DialogResult result = dialog.ShowDialog();

			//Process results:
			string path;
			if(result == DialogResult.OK){
				path = dialog.FileName;
				txtClassifyPath.Text = path;
			}
		}

		private void chkBestModel_CheckedChanged(object sender, EventArgs e)
		{
			bool newValue = !(sender as CheckBox).Checked;
			
			numLayers.Enabled = newValue;
			numNeurons.Enabled = newValue;
			numBias.Enabled = newValue;
			numMaxEpochs.Enabled = newValue;
			numEta.Enabled = newValue;

			btnTestMachine.Enabled = false;
			btnClassify.Enabled = false;
		}
	}
}
