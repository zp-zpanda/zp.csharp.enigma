using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class ReflectorPairTests
    {
        [Theory]
        [InlineData('a', 'z')]
        [InlineData('m', 'n')]
        [InlineData('我', '你')]
        public void ReflectorPairCanBeSetWithTwoChars(char e, char r)
        {
            var pair = ReflectorPair.WithTwoCharacters(e, r);
            var map = new[]{pair.Map.One, pair.Map.Two};
            Assert.IsType<(char, char)>(pair.Map);
            Assert.Contains(e, map);
            Assert.Contains(r, map);
            Assert.True(map[0] < map[1]);
        }
        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('你')]
        public void ReflectorPairCannotHaveSameCharOnBothSides(char c)
        {
            Assert.Throws<ArgumentException>(() => {var pair = ReflectorPair.WithTwoCharacters(c, c);});
        }
    }
}