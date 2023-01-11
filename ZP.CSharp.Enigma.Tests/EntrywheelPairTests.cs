using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class EntrywheelPairTests
    {
        [Theory]
        [InlineData('a', 'z')]
        [InlineData('m', 'n')]
        [InlineData('你', '我')]
        public void EntrywheelPairCanBeSetWithTwoChars(char p, char r)
        {
            var pair = EntrywheelPair.New(p, r);
            Assert.Equal(p, pair.Map.PlugboardSide);
            Assert.Equal(r, pair.Map.ReflectorSide);
        }
        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('你')]
        public void EntrywheelPairCanHaveSameCharOnBothSides(char c)
        {
            var pair = EntrywheelPair.New(c, c);
            Assert.Equal(pair.Map.PlugboardSide, pair.Map.ReflectorSide);
        }
    }
}