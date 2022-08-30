using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class RotorPairTests
    {
        [Theory]
        [InlineData('a', 'z')]
        [InlineData('m', 'n')]
        [InlineData('你', '我')]
        public void RotorPairCanBeSetWithTwoChars(char e, char r)
        {
            var pair = new RotorPair(e, r);
            Assert.Equal(e, pair.EntryWheelSide);
            Assert.Equal(r, pair.ReflectorSide);
        }
        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('你')]
        public void RotorPairCanHaveSameCharOnBothSides(char c)
        {
            var pair = new RotorPair(c, c);
            Assert.Equal(pair.EntryWheelSide, pair.ReflectorSide);
        }
    }
}