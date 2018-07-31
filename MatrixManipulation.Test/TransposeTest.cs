using System;
using MatrixManipulation;
using Xunit;

namespace MatrixManipulation.Test
{
    public class TransposeTest
    {
        [Fact]
        public void Should_Transpose_2x2Matrix()
        {
            var simple4x4 = new double[2, 2] { { 1, 2 }, { 3, 4 } };

            var transposed = simple4x4.Transpose();

            Assert.True(transposed[0, 0] == simple4x4[0, 0], "Transpose failed [0,0]");
            Assert.True(transposed[0, 1] == simple4x4[1, 0], "Transpose failed [0,1]");
            Assert.True(transposed[1, 0] == simple4x4[0, 1], "Transpose failed [1,0]");
            Assert.True(transposed[1, 1] == simple4x4[1, 1], "Transpose failed [1,1]");
        }

        [Fact]
        public void Should_Transpose_4x4Matrix()
        {
            var simple4x4 = new double[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };

            var transposed = simple4x4.Transpose();

            Assert.True(transposed[0, 0] == simple4x4[0, 0], "Transpose failed [0,0]");
            Assert.True(transposed[0, 1] == simple4x4[1, 0], "Transpose failed [0,1]");
            Assert.True(transposed[0, 2] == simple4x4[2, 0], "Transpose failed [0,2]");
            Assert.True(transposed[0, 3] == simple4x4[3, 0], "Transpose failed [0,3]");

            Assert.True(simple4x4[0, 0] == transposed[0, 0], "Transpose failed [0,0]");
            Assert.True(simple4x4[0, 1] == transposed[1, 0], "Transpose failed [0,1]");
            Assert.True(simple4x4[0, 2] == transposed[2, 0], "Transpose failed [0,2]");
            Assert.True(simple4x4[0, 3] == transposed[3, 0], "Transpose failed [0,3]");
        }
    }
}