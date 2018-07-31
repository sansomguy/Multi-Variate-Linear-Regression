using Xunit;

namespace MatrixManipulation.Test
{
    public class SumTest
    {
        [Fact]
        public void Should_SumAllValues()
        {
            //Given
            var matrix = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //When
            var result = matrix.Sum();
            //Then
            Assert.True(result == (45));
        }
    }
}