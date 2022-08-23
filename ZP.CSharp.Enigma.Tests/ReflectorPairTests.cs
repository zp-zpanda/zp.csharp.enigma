using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Models;
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
            var pair = new ReflectorPair(e, r);
            var map = pair.Map;
            Assert.Equal(2, map.Length);
            Assert.Contains(e, map);
            Assert.Contains(r, map);
            Assert.True(map[0] < map[1]);
        }
        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('你')]
        public void RotorPairCannotHaveSameCharOnBothSides(char c)
        {
            Assert.Throws<ArgumentException>(() => {var pair = new ReflectorPair(c, c);});
        }
    }
}