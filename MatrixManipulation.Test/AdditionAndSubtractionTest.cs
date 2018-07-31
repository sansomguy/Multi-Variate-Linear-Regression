using Xunit;

namespace MatrixManipulation.Test
{
    public class AdditionAndSubtractionTest
    {

        [Fact]
        public void Should_AddMatrices()
        {
            var matrixA = new double[2, 2]
            { { 2, 3 }, { 4, 5 }
            };

            var matrixB = new double[2, 2]
            { { 5, 6 }, { 7, 8 }
            };

            var resultMatrix = matrixA.Plus(matrixB);

            Assert.True(resultMatrix[0, 0] == 7);
            Assert.True(resultMatrix[0, 1] == 9);
            Assert.True(resultMatrix[1, 0] == 11);
            Assert.True(resultMatrix[1, 1] == 13);

        }

        [Fact]
        public void Should_SubtractMatrices()
        {
            var matrixA = new double[2, 2]
            { { 2, 3 }, { 4, 5 }
            };

            var matrixB = new double[2, 2]
            { { 5, 6 }, { 7, 8 }
            };

            var resultMatrix = matrixB.Minus(matrixA);

            Assert.True(resultMatrix[0, 0] == 3);
            Assert.True(resultMatrix[0, 1] == 3);
            Assert.True(resultMatrix[1, 0] == 3);
            Assert.True(resultMatrix[1, 1] == 3);

        }

        [Fact]
        public void Should_SubstractToZero()
        {
            var matrixA = new double[2, 2]
            { { 2, 3 }, { 4, 5 }
            };

            var resultMatrix = matrixA.Minus(matrixA);

            Assert.True(resultMatrix[0, 0] == 0);
            Assert.True(resultMatrix[0, 1] == 0);
            Assert.True(resultMatrix[1, 0] == 0);
            Assert.True(resultMatrix[1, 1] == 0);

        }

    }
}