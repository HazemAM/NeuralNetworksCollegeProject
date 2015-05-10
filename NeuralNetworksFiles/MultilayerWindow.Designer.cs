namespace NeuralNetworks
{
	partial class MultilayerWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.numEta = new System.Windows.Forms.NumericUpDown();
            this.lblAccuracy = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridConfMatrix = new System.Windows.Forms.DataGridView();
            this.btnTrainMachine = new System.Windows.Forms.Button();
            this.numMaxEpochs = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.numLayers = new System.Windows.Forms.NumericUpDown();
            this.numNeurons = new System.Windows.Forms.NumericUpDown();
            this.numBias = new System.Windows.Forms.NumericUpDown();
            this.numClusters = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassifyPath = new System.Windows.Forms.TextBox();
            this.btnClassify = new System.Windows.Forms.Button();
            this.txtClassifyOutput = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkBestModel = new System.Windows.Forms.CheckBox();
            this.btnTestMachine = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmboNetworkType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numEta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConfMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNeurons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClusters)).BeginInit();
            this.SuspendLayout();
            // 
            // numEta
            // 
            this.numEta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numEta.BackColor = System.Drawing.SystemColors.Window;
            this.numEta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEta.DecimalPlaces = 2;
            this.numEta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numEta.Location = new System.Drawing.Point(166, 159);
            this.numEta.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numEta.Name = "numEta";
            this.numEta.Size = new System.Drawing.Size(54, 20);
            this.numEta.TabIndex = 17;
            this.toolTip.SetToolTip(this.numEta, "Learning rate (eta)");
            this.numEta.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Location = new System.Drawing.Point(135, 44);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(13, 13);
            this.lblAccuracy.TabIndex = 16;
            this.lblAccuracy.Text = "--";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Overall accuracy:";
            // 
            // gridConfMatrix
            // 
            this.gridConfMatrix.AllowUserToAddRows = false;
            this.gridConfMatrix.AllowUserToDeleteRows = false;
            this.gridConfMatrix.AllowUserToResizeColumns = false;
            this.gridConfMatrix.AllowUserToResizeRows = false;
            this.gridConfMatrix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gridConfMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridConfMatrix.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridConfMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridConfMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConfMatrix.ColumnHeadersVisible = false;
            this.gridConfMatrix.Location = new System.Drawing.Point(33, 60);
            this.gridConfMatrix.Name = "gridConfMatrix";
            this.gridConfMatrix.ReadOnly = true;
            this.gridConfMatrix.RowHeadersVisible = false;
            this.gridConfMatrix.Size = new System.Drawing.Size(241, 101);
            this.gridConfMatrix.TabIndex = 14;
            // 
            // btnTrainMachine
            // 
            this.btnTrainMachine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrainMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainMachine.Location = new System.Drawing.Point(182, 185);
            this.btnTrainMachine.Name = "btnTrainMachine";
            this.btnTrainMachine.Size = new System.Drawing.Size(79, 46);
            this.btnTrainMachine.TabIndex = 13;
            this.btnTrainMachine.Text = "Train";
            this.btnTrainMachine.UseVisualStyleBackColor = true;
            this.btnTrainMachine.Click += new System.EventHandler(this.btnTrainMachine_Click);
            // 
            // numMaxEpochs
            // 
            this.numMaxEpochs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numMaxEpochs.BackColor = System.Drawing.SystemColors.Window;
            this.numMaxEpochs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMaxEpochs.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMaxEpochs.Location = new System.Drawing.Point(226, 159);
            this.numMaxEpochs.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.numMaxEpochs.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxEpochs.Name = "numMaxEpochs";
            this.numMaxEpochs.Size = new System.Drawing.Size(54, 20);
            this.numMaxEpochs.TabIndex = 18;
            this.toolTip.SetToolTip(this.numMaxEpochs, "Maximum epochs");
            this.numMaxEpochs.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numLayers
            // 
            this.numLayers.Location = new System.Drawing.Point(89, 161);
            this.numLayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numLayers.Name = "numLayers";
            this.numLayers.Size = new System.Drawing.Size(47, 20);
            this.numLayers.TabIndex = 28;
            this.toolTip.SetToolTip(this.numLayers, "Number of layers in the network");
            this.numLayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numNeurons
            // 
            this.numNeurons.Location = new System.Drawing.Point(89, 187);
            this.numNeurons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNeurons.Name = "numNeurons";
            this.numNeurons.Size = new System.Drawing.Size(47, 20);
            this.numNeurons.TabIndex = 30;
            this.toolTip.SetToolTip(this.numNeurons, "Number of neurons per layer");
            this.numNeurons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numBias
            // 
            this.numBias.Location = new System.Drawing.Point(89, 213);
            this.numBias.Name = "numBias";
            this.numBias.Size = new System.Drawing.Size(47, 20);
            this.numBias.TabIndex = 32;
            this.toolTip.SetToolTip(this.numBias, "Bias value in every neuron");
            this.numBias.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numClusters
            // 
            this.numClusters.Location = new System.Drawing.Point(89, 239);
            this.numClusters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numClusters.Name = "numClusters";
            this.numClusters.Size = new System.Drawing.Size(47, 20);
            this.numClusters.TabIndex = 35;
            this.toolTip.SetToolTip(this.numClusters, "Number of clusters in RBF");
            this.numClusters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(29, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 2);
            this.label1.TabIndex = 19;
            // 
            // txtClassifyPath
            // 
            this.txtClassifyPath.Location = new System.Drawing.Point(45, 333);
            this.txtClassifyPath.Name = "txtClassifyPath";
            this.txtClassifyPath.Size = new System.Drawing.Size(152, 20);
            this.txtClassifyPath.TabIndex = 20;
            // 
            // btnClassify
            // 
            this.btnClassify.Enabled = false;
            this.btnClassify.Location = new System.Drawing.Point(115, 359);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(70, 25);
            this.btnClassify.TabIndex = 21;
            this.btnClassify.Text = "Classify";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // txtClassifyOutput
            // 
            this.txtClassifyOutput.Location = new System.Drawing.Point(76, 387);
            this.txtClassifyOutput.Name = "txtClassifyOutput";
            this.txtClassifyOutput.Size = new System.Drawing.Size(150, 15);
            this.txtClassifyOutput.TabIndex = 23;
            this.txtClassifyOutput.Text = "--";
            this.txtClassifyOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(198, 332);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(61, 22);
            this.btnBrowse.TabIndex = 24;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkBestModel
            // 
            this.chkBestModel.AutoSize = true;
            this.chkBestModel.Location = new System.Drawing.Point(100, 281);
            this.chkBestModel.Name = "chkBestModel";
            this.chkBestModel.Size = new System.Drawing.Size(99, 17);
            this.chkBestModel.TabIndex = 25;
            this.chkBestModel.Text = "Use best model";
            this.chkBestModel.UseVisualStyleBackColor = true;
            this.chkBestModel.CheckedChanged += new System.EventHandler(this.chkBestModel_CheckedChanged);
            // 
            // btnTestMachine
            // 
            this.btnTestMachine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTestMachine.Enabled = false;
            this.btnTestMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestMachine.Location = new System.Drawing.Point(182, 231);
            this.btnTestMachine.Name = "btnTestMachine";
            this.btnTestMachine.Size = new System.Drawing.Size(79, 23);
            this.btnTestMachine.TabIndex = 26;
            this.btnTestMachine.Text = "Test";
            this.btnTestMachine.UseVisualStyleBackColor = true;
            this.btnTestMachine.Click += new System.EventHandler(this.btnTestMachine_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(150, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 125);
            this.label2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Layers:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Neurons:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Bias:";
            // 
            // cmboNetworkType
            // 
            this.cmboNetworkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboNetworkType.FormattingEnabled = true;
            this.cmboNetworkType.Items.AddRange(new object[] {
            "Backpropagation",
            "Radial Basis Function"});
            this.cmboNetworkType.Location = new System.Drawing.Point(29, 13);
            this.cmboNetworkType.Name = "cmboNetworkType";
            this.cmboNetworkType.Size = new System.Drawing.Size(142, 21);
            this.cmboNetworkType.TabIndex = 34;
            this.cmboNetworkType.SelectedIndexChanged += new System.EventHandler(this.cmboNetworkType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Clusters:";
            // 
            // MultilayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(309, 418);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numClusters);
            this.Controls.Add(this.cmboNetworkType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numBias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numNeurons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numLayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTestMachine);
            this.Controls.Add(this.chkBestModel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtClassifyOutput);
            this.Controls.Add(this.btnClassify);
            this.Controls.Add(this.txtClassifyPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMaxEpochs);
            this.Controls.Add(this.numEta);
            this.Controls.Add(this.lblAccuracy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridConfMatrix);
            this.Controls.Add(this.btnTrainMachine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MultilayerWindow";
            this.Text = "Multilayer Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.numEta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConfMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNeurons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClusters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numEta;
		private System.Windows.Forms.Label lblAccuracy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView gridConfMatrix;
		private System.Windows.Forms.Button btnTrainMachine;
		private System.Windows.Forms.NumericUpDown numMaxEpochs;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtClassifyPath;
		private System.Windows.Forms.Button btnClassify;
		private System.Windows.Forms.Label txtClassifyOutput;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.CheckBox chkBestModel;
		private System.Windows.Forms.Button btnTestMachine;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numLayers;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numNeurons;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numBias;
        private System.Windows.Forms.ComboBox cmboNetworkType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numClusters;

	}
}