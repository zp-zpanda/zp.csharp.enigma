using Xunit;
namespace ZP.CSharp.Enigma.Tests
{
    public class RotorPairTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 3)]
        public void RotorPairCanBeSetWithTwoChars(int e, int r)
        {
            var pair = RotorPair<int>.New(e, r);
            Assert.Equal(e, pair.Map.EntryWheelSide);
            Assert.Equal(r, pair.Map.ReflectorSide);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void RotorPairCanHaveSameCharOnBothSides(int c)
        {
            var pair = RotorPair<int>.New(c, c);
            Assert.Equal(pair.Map.EntryWheelSide, pair.Map.ReflectorSide);
        }
    }
}