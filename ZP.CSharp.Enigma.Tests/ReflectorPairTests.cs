using System;
using Xunit;
namespace ZP.CSharp.Enigma.Tests
{
    public class ReflectorPairTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 3)]
        public void ReflectorPairCanBeSetWithTwoChars(int e, int r)
        {
            var pair = ReflectorPair<int>.New(e, r);
            var map = new[]{pair.Map.One, pair.Map.Two};
            Assert.IsType<(int, int)>(pair.Map);
            Assert.Contains(e, map);
            Assert.Contains(r, map);
            Assert.True(map[0] < map[1]);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ReflectorPairCannotHaveSameCharOnBothSides(int c)
        {
            var action = () => {var pair = ReflectorPair<int>.New(c, c);};
            Assert.Throws<ArgumentException>(action);
        }
    }
}