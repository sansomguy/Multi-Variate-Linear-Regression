using System.Linq;
using MatrixManipulation;

namespace GradientDescent
{

    public interface ILinearRegression
    {
        /**
         * Learn
         * description: Give some data learn the coefficients for the multivariate regression
         */
        /// Xs is a matrix that defines the number of examples in rows, and the dimensions in width, and entries in rows
        /// Ys is simply an array of the outcomes (1 dimension) given the various attributes defined for a row in Xs
        void Learn(double[, ] Xs, double[, ] Ys);

        // predict the outcome given the model and the input
        double Predict(double[] x);
    }

    public class GradientDescent : ILinearRegression
    {
        private double _LearningRate { get; set; }
        private double _Tolerance { get; set; }
        private int _MaxIterations { get; set; }

        private double[, ] _Coefficients { get; set; }
        private int _ExampleSize { get; set; }
        private int _NumberOfCoefficients { get; set; }
        private double _FinalError { get; set; }

        public GradientDescent(
            double learningRate,
            double tolerance,
            int maxIterations
        )
        {
            _LearningRate = learningRate;
            _Tolerance = tolerance;
            _MaxIterations = maxIterations;

        }

        private double[,] GetLossVector(double[,] Xs, double[,] Ys)
        {
            return Xs.DotProduct(_Coefficients).Minus(Ys);
        }

        private double GetGradient(int coefficientIndex, double[,] Xs, double[,] Ys)
        {
            var gradient = 0d;

            var lossVector = GetLossVector(Xs, Ys);
            var coefficient = _Coefficients[coefficientIndex, 0];

            for (var i = 0; i < _ExampleSize; i++)
            {
                gradient += coefficient * lossVector[i, 0];
            }

            return gradient / _ExampleSize;
        }

        public void Learn(double[, ] Xs, double[, ] Ys)
        {
            // initialize the coefficients with the same number of rows as are features
            _Coefficients = (new double[Xs.GetLength(1), 1]).InitializeWithValue(1.0d);

            _ExampleSize = Xs.GetLength(0); // size of training data
            _NumberOfCoefficients = Xs.GetLength(1); // get the number of features

            var gradients = new double[_NumberOfCoefficients, 1];
            for (var i = 0; i < _MaxIterations; i++)
            {
                // Calculate the loss of our predictions thus far
                var lossMatrix = GetLossVector(Xs, Ys);
                // sum of squares
                var error = lossMatrix.DotProduct(lossMatrix.Transpose()).Sum() / 2 * _ExampleSize;

                for (var j = 0; j < _NumberOfCoefficients; j++)
                {
                    var gradient = GetGradient(j, Xs, Ys);
                    gradients[j, 0] = gradient;
                    _Coefficients[j, 0] = _Coefficients[j, 0] - gradient * _LearningRate;
                }

                _FinalError = error;
                if (error < _Tolerance)
                {
                    return;
                }
            }

        }


        public double Predict(double[] attributes)
        {
            var result = 0d;
            for (var i = 0; i < attributes.Count(); i++)
            {
                result += _Coefficients[i, 0] * attributes[i];
            }
            return result;
        }

    }
}