using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace NeuralNetworks
{
	public class DataSetReader
	{
		private string globalPath;
		
		public int currentTrainSample; //One-based.
		public int currentTrainClass;  //Zero-based.
		public int currentTestSample; //One-based.
		public int currentTestClass;  //Zero-based.

		private string sampleNameFormat;
		public readonly string[] classLabels;

		public readonly DataSetType type;
		public readonly int classes;	//Number of classes in the data set.
		public readonly int trainSamplesPerClass;	//Number of train samples per class.
		public readonly int testSamplesPerClass;	//Number of test samples per class.
		public readonly int featuresPerSample;	//Number of features per sample.

		//Normalization data:
		public readonly bool normalized;
		private double[] mean;
		private double[] max;

		public DataSetReader(string path, DataSetType type, bool normalizeData)
		{
			this.globalPath = path;
			this.type = type;
			this.normalized = normalizeData;

			this.currentTrainSample = 0;
			this.currentTrainClass = 0;

			this.currentTestSample = 0;
			this.currentTestClass = 0;

			switch(type){
			case DataSetType.HeadOrientation:
				this.classes = 3;
				this.featuresPerSample = 2500;
				this.trainSamplesPerClass = 50;
				this.testSamplesPerClass = 30;
				this.sampleNameFormat = "head ({0}).png";
				this.classLabels = new string[] {"Front", "Left", "Right"};
				break;
			}

			if(normalized){
				readDataFromFile("mean");
				readDataFromFile("max");
			}
		}

		public double[] getNextTrainSample()
		{
			string trainPath = globalPath + "Training/";
			double[] sampleData = new double[featuresPerSample]; //Initialize data container.

			string fullPath;
			if(nextTrainIndex()){
				fullPath = trainPath + this.classLabels[currentTrainClass]
					+ "/" + string.Format(this.sampleNameFormat, currentTrainSample);
				sampleData = readImage(fullPath);
			}
			else sampleData = null;

			return sampleData;
		}

		public double[] getNextTestSample()
		{
			string testPath = globalPath + "Testing/";
			double[] sampleData = new double[featuresPerSample]; //Initialize data container.

			string fullPath;
			if(nextTestIndex()){
				fullPath = testPath + this.classLabels[currentTestClass]
					+ "/" + string.Format(this.sampleNameFormat, currentTestSample);
				sampleData = readImage(fullPath);
			}
			else sampleData = null;

			return sampleData;
		}

		private bool nextTrainIndex()
		{
			if(this.currentTrainSample > this.trainSamplesPerClass
				&& this.currentTrainClass >= this.classes)
				return false;

			this.currentTrainSample++;
			if(this.currentTrainSample > this.trainSamplesPerClass){
				this.currentTrainClass++;
				this.currentTrainSample = 1;
				if(this.currentTrainClass >= this.classes){
					resetTrainIndex();
					return false;
				}
			}

			return true;
		}

		private bool nextTestIndex()
		{
			if(this.currentTestSample > this.testSamplesPerClass
				&& this.currentTestClass >= this.classes)
				return false;

			this.currentTestSample++;
			if(this.currentTestSample > this.testSamplesPerClass){
				this.currentTestClass++;
				this.currentTestSample = 1;
				if(this.currentTestClass >= this.classes){
					resetTestIndex();
					return false;
				}
			}

			return true;
		}

		public double[] readImage(string path)
		{
			Bitmap bitmap = BitmapTools.toGrayScale(new Bitmap(path));
			double[] data = BitmapTools.to1D(bitmap);

			//Normalize?
			if(this.normalized)
				data = norm(data);

			return data;
		}

		private void readDataFromFile(string type)
		{
			string[] temp;
			if(type == "mean"){
				string mean = File.ReadAllText(globalPath + "Training/" + "mean.txt");
				temp = mean.Split(',');
				this.mean = Array.ConvertAll(temp, Convert.ToDouble);
			}
			else if(type == "max"){
				string max = File.ReadAllText(globalPath + "Training/" + "max.txt");
				temp = max.Split(',');
				this.max = Array.ConvertAll(temp, Convert.ToDouble);
			}
		}

		public void resetTrainIndex()
		{
			this.currentTrainSample = 0;
			this.currentTrainClass = 0;
		}

		public void resetTestIndex()
		{
			this.currentTestSample = 0;
			this.currentTestClass = 0;
		}
        public void setTrain(int train,int cl)
        {
            this.currentTrainSample = train;
            this.currentTrainClass = cl;
        }

		/// <summary>Normalize a single value using the data set normalization parameters.</summary>
		/// <returns>The normalized value.</returns>
		public double[] norm(double[] value)
		{
			double[] result = new double[value.Length];
			for(int i=0; i<result.Length; i++)
				result[i] = (value[i] - this.mean[i]) / this.max[i];

			return result;
		}

	}
}
