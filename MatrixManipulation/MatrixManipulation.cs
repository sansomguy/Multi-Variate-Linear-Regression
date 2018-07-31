using System;

namespace MatrixManipulation
{
    public static class MatricesExtensions
    {

        public delegate void ActionDelegate<T>(T value, int row, int column);

        public static T[, ] Iterate<T>(this T[, ] matrix, ActionDelegate<T> callback)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    callback(matrix[i, j], i, j);
                }
            }
            return matrix;
        }

        public static T Sum<T>(this T[, ] matrix)
        {
            var result = default(T);
            matrix.Iterate((value, row, column) =>
            {
                result += (value as dynamic);
            });

            return result;
        }

        public static T[, ] InitializeWithValue<T>(this T[, ] input, T initializer)
        {
            input.Iterate((value, row, column) =>
            {
                input[row, column] = initializer;
            });
            return input;
        }

        public static T[, ] Plus<T>(this T[, ] matrix, T additive)
        {
            var newMatrix = new T[matrix.GetLength(0), matrix.GetLength(1)];
            matrix.Iterate((value, row, column) =>
            {
                newMatrix[row, column] = (value as dynamic) * (additive as dynamic);
            });
            return newMatrix;
        }

        public static T[, ] Plus<T>(this T[, ] matrix, T[, ] additiveMatrix)
        {
            var newMatrix = new T[matrix.GetLength(0), matrix.GetLength(1)];

            matrix.Iterate((value, row, column) =>
            {
                newMatrix[row, column] = (matrix[row, column] as dynamic) + (additiveMatrix[row, column] as dynamic);
            });

            return newMatrix;
        }

        public static T[, ] Minus<T>(this T[, ] matrix, T[, ] additiveMatrix)
        {
            var minusMatrix = new T[matrix.GetLength(0), matrix.GetLength(1)];

            additiveMatrix.Iterate((value, row, column) => minusMatrix[row, column] = (additiveMatrix[row, column] as dynamic) * -1);

            return Plus(matrix, minusMatrix);
        }

        public static T[, ] Minus<T>(this T[, ] matrix, T value)
        {
            return Plus<T>(matrix, -1 * (value as dynamic));
        }

        /**
         * Scale
         */

        public static MatrixType[, ] Scale<MatrixType, ScaleType>(this MatrixType[, ] initial, ScaleType scaleBy)
        {
            var resultingMatrix = new MatrixType[initial.GetLength(0), initial.GetLength(1)];

            initial.Iterate((value, row, column) =>
            {
                resultingMatrix[row, column] = (value as dynamic) * (scaleBy as dynamic);
            });

            return resultingMatrix;
        }

        /**
         * Multiply MxN array by NxM array
         */
        public static T[, ] DotProduct<T>(this T[, ] matrixA, T[, ] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                throw new MatrixMultiplicationException("Matrix A, does not have the same number of columns as Matrix B has rows");
            }

            var resultMatrix = new T[matrixA.GetLength(0), matrixB.GetLength(1)];
            resultMatrix = InitializeWithValue<T>(resultMatrix, 0d as dynamic);

            for (var newRow = 0; newRow < resultMatrix.GetLength(0); newRow++)
            {
                for (var newColumn = 0; newColumn < resultMatrix.GetLength(1); newColumn++)
                {
                    for (var rowColumnIndex = 0; rowColumnIndex < matrixA.GetLength(1); rowColumnIndex++)
                    {
                        resultMatrix[newRow, newColumn] += (matrixA[newRow, rowColumnIndex] as dynamic) * (matrixB[rowColumnIndex, newColumn] as dynamic);
                    }

                }
            }

            return resultMatrix;
        }

        public static T[, ] Transpose<T>(this T[, ] matrix)
        {
            var transposedMatrix = new T[matrix.GetLength(1), matrix.GetLength(0)];

            matrix.Iterate<T>((value, row, column) =>
            {
                transposedMatrix[column, row] = value;
            });

            return transposedMatrix;
        }

        public static T[, ] ToMatrix<T>(this T[] array, int columns)
        {
            var numberOfItems = (int)(array.Length / columns);
            var matrix = new T[numberOfItems, columns];

            for (var i = 0; i < numberOfItems; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[i * j];
                }
            }

            return matrix;
        }

    }

    public class MatrixMultiplicationException : Exception
    {
        public MatrixMultiplicationException(string message):
            base(message) { }
    }

}