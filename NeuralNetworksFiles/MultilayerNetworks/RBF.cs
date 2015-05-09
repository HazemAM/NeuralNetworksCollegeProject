using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.MultilayerNetworks
{
    class RBF:MultilayerNeuralNetwork
    {
        List<double[]>[] clusters;
        double[][] centroids;
        double[] sigma;
        int numClusters;
        //double centThresh = 1E-3;
        double mseThresh = 0.1;
        public RBF(Layer[] layers, DataSetReader dataSet, double eta, int maxEpochs,int numClusters)
            : base(layers, dataSet, eta, maxEpochs)
        {
            this.numClusters = numClusters;
        }
        
        public override void train()
        {
            initClusters();
            ClusterInput();
            int numOut=layer[0].nodes;
            int epoch;
            double[] o,	//Holding output data for every iteration.
                       error;		//Holding error data for every iteration.
            double[] input;
            double[] mse = new double[maxEpochs];
            List<double[]> Error = new List<double[]>();
            for(epoch=0;epoch<maxEpochs;epoch++)
            {
                
                while((input = this.dataSet.getNextTrainSample()) != null)
                {
                    double[] gaussian = getGaussian(input); //calculating gaussians
                    o = new double[numOut];
                    error = new double[numOut];
                    for (int i = 0; i < numOut; i++)
                    {
                        o[i] = calcMult(gaussian, layer[0].neuron[i].weight);
                        double desiredOutput = (dataSet.currentTrainClass == i) ? 1 : 0;
                        error[i] = (desiredOutput - o[i]);
                        double temp=eta*error[i];
                        double[] delta = mulScaler(gaussian, temp);
                        layer[0].neuron[i].weight = addVec(layer[0].neuron[i].weight, delta);
                    }
                    Error.Add(error);
                }
                mse[epoch] = calcMean(Error);
                if (mse[epoch] < mseThresh)
                    break;
            }
        }

        private double calcMean(List<double[]> Error)
        {
            int numErrors = Error.Count;
            double error;
            int errorper=Error[0].Length;
            double realError=0;
            for(int i=0;i<numErrors;i++)
            {
                error = 0;
                for(int j=0;j<errorper;j++)
                {
                    error += Math.Pow(Error[i][j],2);
                }
                error /= errorper;
                realError += error;
            }
            realError /= numErrors;
            return realError;
        }

        private double[] addVec(double[] p, double[] delta)
        {
            int size = p.Length;
            double[] res= new double[size];
            for (int i = 0; i < size; i++)
                res[i] = p[i] + delta[i];
            return res;
        }

        private double[] mulScaler(double[] gaussian, double temp)
        {
            int size = gaussian.Length;
            double [] res= new double[size];
            for (int i = 0; i < size; i++)
                res[i] = gaussian[i] * temp;
            return res;
        }

        private double[] getGaussian(double[] input)
        {
            double[] res = new double[numClusters];
            
            for (int i = 0; i < numClusters;i++ )
            {
                double[] def = calcDef(input, centroids[i]);
                double mulRes = calcMult(def, def);
                res[i] = Math.Exp(-mulRes/(2*Math.Pow(sigma[i],2)));
            }
                return res;
        }

        private double calcMult(double[] def1, double[] def2)
        {
            int size = def1.Length;
            double res = 0;
            for (int i = 0; i < size; i++)
                res += def1[i] * def2[i];
            return res;
        }

        private double[] calcDef(double[] input, double[] p)
        {
            int size = input.Length;
            double [] res= new double[size];
            for (int i = 0; i < size; i++)
                res[i] = input[i] - p[i];
            return res;
        }

        private void initClusters()
        {
            centroids = new double[numClusters][];
            Random r = new Random(Guid.NewGuid().GetHashCode()); ;
            for (int i = 0; i < numClusters; i++)
            {
                dataSet.setTrain(r.Next(0,150));
                centroids[i] = dataSet.getNextTrainSample();
                if (centroids[i] == null)
                    i--;
            }
            dataSet.resetTrainIndex();
        }

        private void ClusterInput()
        {
            bool clustChanged = true;
            double[] input;
            double[] dist;
            while (clustChanged)
            {
                clusters = new List<double[]>[numClusters];
                for (int i = 0; i < numClusters; i++)
                    clusters[i] = new List<double[]>();
                while ((input = this.dataSet.getNextTrainSample()) != null)
                {
                        dist = new double[numClusters];
                    for (int i = 0; i < numClusters; i++)
                    {
                        dist[i] = getDistance(centroids[i], input);
                    }
                    int cent = Array.IndexOf(dist, dist.Min());
                    clusters[cent].Add(input);
                }
                double[][] newCentroids = calcNewCentroids();
                clustChanged = getChange(newCentroids);
                centroids = newCentroids;
            }
            calcSigma();
        }

        private void calcSigma()
        {
            sigma = new double[numClusters];
            for(int i=0;i<numClusters;i++)
            {
                foreach(double [] vec in clusters[i])
                {
                    sigma[i] += getDistance(centroids[i], vec);
                }
                sigma[i] /= clusters[i].Count;
            }
        }

        private bool getChange(double[][] newCentroids)// need to check if this feasible or not if not use distance with threshhold
        {
            for (int i = 0; i < numClusters; i++)
                if (!centroids[i].SequenceEqual(newCentroids[i]))
                    return true;
            return false;
        }

        private double[][] calcNewCentroids()
        {
            double[][] res = new double[numClusters][];
            int size = centroids[0].Length;
            for (int i = 0; i < numClusters;i++ )
            {
                int clustSize = clusters[i].Count;
                res[i] = new double[size];
                for (int k = 0; k < clustSize; k++)
                    for (int j = 0; j < size; j++)
                        res[i][j] += clusters[i][k][j];
                for (int j = 0; j < size; j++)
                    res[i][j] /= (double)clustSize;
            }
                return res;
        }

        private double getDistance(double[] centroid, double[] input)
        {
            int len = centroid.Length;
            double dist=0;
            for (int i = 0; i < len; i++)
                dist += Math.Pow((centroid[i] - input[i]), 2);
            return Math.Sqrt(dist);
        }

        public override int[,] test()
        {
            
            int[,] confMatrix = new int[this.dataSet.classes, this.dataSet.classes];

            int classOut;
            double[] lineData;

            while ((lineData = this.dataSet.getNextTestSample()) != null)
            {
                classOut = classify(lineData);
                confMatrix[this.dataSet.currentTestClass, classOut]++;
            }

            return confMatrix;
        }

        public override int classify(double[] input)
        {
            int numOut = layer[0].nodes;
            double[] o = new double[numOut];
                double[] gaussian = getGaussian(input); //calculating gaussians
                for (int i = 0; i < numOut; i++)
                {
                    o[i] = calcMult(gaussian, layer[0].neuron[i].weight);
                }
                return Array.IndexOf(o, o.Max());
        }

        public override void loadWeights(string parentPath)
        {
            throw new NotImplementedException();
        }
    }
}
