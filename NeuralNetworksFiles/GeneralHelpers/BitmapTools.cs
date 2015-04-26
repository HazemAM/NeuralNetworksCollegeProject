using System;
using System.Drawing;

namespace NeuralNetworks
{
	static class BitmapTools
	{
		public static Bitmap toGrayScale(Bitmap bitmap)
		{
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

			Color oldColor, newColor;
			int greyValue;
            for(int j=0; j < newBitmap.Height; j++)
                for(int i=0; i < newBitmap.Width; i++){
                    oldColor = bitmap.GetPixel(i, j);
                    greyValue = (int)(0.2126*oldColor.R + 0.7152*oldColor.G + 0.0722*oldColor.B);
                    newColor = Color.FromArgb(greyValue, greyValue, greyValue);
                    newBitmap.SetPixel(i, j, newColor);
                }
            
			return newBitmap;
        }

		public static double[] to1D(Bitmap bitmap)
		{
			double[] data = new double[bitmap.Width * bitmap.Height];

			for(int i=0; i < bitmap.Width; i++)
                for(int j=0; j < bitmap.Height; j++)
					data[(bitmap.Width * j) + i] = bitmap.GetPixel(i, j).R;

			return data;
		}
	}
}
