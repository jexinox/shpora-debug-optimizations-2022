using System;

namespace JPEG.Utilities
{
    public static class MatrixUtils
    {
        public static float[,] MultiplyMatrix(float[,] a, float[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) 
                throw new ArgumentException("First matrix height should be equal second matrix width");

            var result = new float[a.GetLength(0), b.GetLength(1)];
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < b.GetLength(1); j++)
                {
                    for (var k = 0; k < b.GetLength(0); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public static float[,] TransposeMatrix(float[,] matrix)
        {
            var width = matrix.GetLength(0);
            var height = matrix.GetLength(1);
            
            var result = new float[height, width];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
    }
}