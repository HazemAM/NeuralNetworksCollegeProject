using System;
using System.Data;
using System.Windows.Forms;

namespace NeuralNetworks
{
	static class UiTools
	{
		public static void drawMatrix(DataGridView dataGridView, int[,] matrix)
		{
			DataTable dt = new DataTable();

			for(int i=0; i<matrix.GetLength(1); i++)
				dt.Columns.Add();

			DataRow dr = dt.NewRow();
			for(int i=0; i<matrix.GetLength(0); i++){
				dr = dt.NewRow();
				for(int j=0; j<matrix.GetLength(1); j++)
					dr[j] = matrix[i,j];
				dt.Rows.Add(dr);
			}

			dataGridView.DataSource = dt;
		}
	}
}
