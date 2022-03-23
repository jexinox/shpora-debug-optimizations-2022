using System;
using JPEG.Utilities;

namespace JPEG
{
	public class DCT
	{
		public static float[,] DCT2D(float[,] input, int dctSize)
		{
			var dct = BuildDCTMatrix(dctSize);

			var tmp = MatrixUtils.MultiplyMatrix(dct, input);

			var coeffs = MatrixUtils.MultiplyMatrix(tmp, MatrixUtils.TransposeMatrix(dct));
			
			return coeffs;
		}

		public static float[,] IDCT2D(float[,] input, int dctSize)
		{
			var dct = BuildDCTMatrix(dctSize);

			var tmp = MatrixUtils.MultiplyMatrix(input, dct);

			var coeffs = MatrixUtils.MultiplyMatrix(MatrixUtils.TransposeMatrix(dct), tmp);
			
			return coeffs;
		}
		
		private static float[,] BuildDCTMatrix(int dctSize)
		{
			var matrix = new float[dctSize, dctSize];

			for (var i = 0; i < dctSize; ++i)
			{
				for (var j = 0; j < dctSize; ++j)
				{
					if (i == 0)
					{
						matrix[i, j] = (float) (1 / Math.Sqrt(dctSize));
					}
					else
					{
						matrix[i, j] = (float) (Math.Sqrt(2d / dctSize) * Math.Cos((2 * j + 1) * i * Math.PI / (2 * dctSize)));
					}
				}
			}
			
			return matrix;
		}
	}
}