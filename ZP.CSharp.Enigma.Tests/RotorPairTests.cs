using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Models;
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
        [Theory]
        [InlineData("ab", "cd", new char[]{'a', 'b'}, new char[]{'c', 'd'})]
        [InlineData("你我他", "大熊貓", new char[]{'你', '我', '他'}, new char[]{'大', '熊', '貓'})]
        public void RotorPairsCanBeMassConstructed(string e, string r, char[] eChars, char[] rChars)
        {
            var rotor = new Rotor(e, r);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, new RotorPair(eChars[i], rChars[i]));
                i++;
            });
        }
    }
}