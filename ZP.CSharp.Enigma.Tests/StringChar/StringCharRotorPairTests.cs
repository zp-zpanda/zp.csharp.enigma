using Xunit;
namespace ZP.CSharp.Enigma.Tests
{
    public class StringCharRotorPairTests
    {
        [Theory]
        [InlineData('a', 'z')]
        [InlineData('m', 'n')]
        [InlineData('你', '我')]
        public void RotorPairCanBeSetWithTwoChars(char e, char r)
        {
            var pair = StringCharRotorPair.New(e, r);
            Assert.Equal(e, pair.Map.EntryWheelSide);
            Assert.Equal(r, pair.Map.ReflectorSide);
        }
        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('你')]
        public void RotorPairCanHaveSameCharOnBothSides(char c)
        {
            var pair = StringCharRotorPair.New(c, c);
            Assert.Equal(pair.Map.EntryWheelSide, pair.Map.ReflectorSide);
        }
    }
}