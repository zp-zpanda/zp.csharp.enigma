using Xunit;
namespace ZP.CSharp.Enigma.Tests
{
    public class EntrywheelPairTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 3)]
        public void EntrywheelPairCanBeSetWithTwoChars(char p, char r)
        {
            var pair = EntrywheelPair<int>.New(p, r);
            Assert.Equal(p, pair.Map.PlugboardSide);
            Assert.Equal(r, pair.Map.ReflectorSide);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void EntrywheelPairCanHaveSameCharOnBothSides(char c)
        {
            var pair = EntrywheelPair<int>.New(c, c);
            Assert.Equal(pair.Map.PlugboardSide, pair.Map.ReflectorSide);
        }
    }
}