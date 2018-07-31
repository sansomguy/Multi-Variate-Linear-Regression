using Xunit;

namespace MatrixManipulation.Test
{
    public class MultiplicationTest
    {
        [Fact]
        public void Should_MultiplyByMatrix()
        {
            var matrixA = new double[2, 2]
            { { 2, 7 }, //row
                { 13, 21 } //row
            };

            var matrixB = new double[2, 2]
            { { 1, 0 }, //row 
                { 2, 0 } // row
            };

            var resultingMatrix = matrixA.DotProduct(matrixB);

            // first row * first column summed up
            // 2* 1 + 7*2
            // first row * second column
            // should be zero as second column is zero

            Assert.True(resultingMatrix[0, 0] == (2 * 1 + 7 * 2));
            Assert.True(resultingMatrix[0, 1] == (2 * 0 + 7 * 0));
            Assert.True(resultingMatrix[1, 0] == (13 * 1 + 21 * 2));
            Assert.True(resultingMatrix[1, 1] == (13 * 0 + 21 * 0));
        }

        [Fact]
        public void Should_MultiplyVector()
        {
            var matrix = new double[2, 2] { { 2, 2 }, { 2, 2 } };
            var vector = new double[2, 1] { { 3 }, { 3 } };
            var newMatrix = matrix.DotProduct(vector);

            Assert.True(newMatrix[0, 0] == 12);
            Assert.True(newMatrix[1, 0] == 12);
        }

        [Fact]
        public void Should_MultiplyVectors()
        {
            var vector1 = new double[2, 1] { { 2 }, { 3 } };
            var vector2 = new double[2, 1] { { 2 }, { 3 } };

            var result = vector1.Transpose().DotProduct(vector2);

            Assert.True(result[0, 0] == 13);
        }
    }
}