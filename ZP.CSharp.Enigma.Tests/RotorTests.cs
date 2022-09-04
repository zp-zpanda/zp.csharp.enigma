using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class RotorTests
    {
        [Fact]
        public void RotorDefaultsToZeroRotorPairs()
        {
            var rotor = new Rotor();
            Assert.Empty(rotor.Pairs);
        }
        [Fact]
        public void RotorPairsCanBeAddedToRotor()
        {
            var pair1 = new RotorPair('a', 'z');
            var pair2 = new RotorPair('z', 'a');
            var rotor = new Rotor(pair1, pair2);
            Assert.Contains(pair1, rotor.Pairs);
            Assert.Contains(pair2, rotor.Pairs);
        }
        [Theory]
        [InlineData("ab", "cd", new char[]{'a', 'b'}, new char[]{'c', 'd'})]
        [InlineData("你我他", "大熊貓", new char[]{'你', '我', '他'}, new char[]{'大', '熊', '貓'})]
        public void RotorPairsCanBeMassConstructedFromTwoMappings(string e, string r, char[] eChars, char[] rChars)
        {
            var rotor = new Rotor(e, r);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, new RotorPair(eChars[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(new char[]{'a', 'b'}, new char[]{'c', 'd'}, "ac", "bd")]
        [InlineData(new char[]{'你', '我', '他'}, new char[]{'大', '熊', '貓'}, "你大", "我熊", "他貓")]
        public void RotorPairsCanBeMassConstructedFromTwoCharLongMappings(char[] eChars, char[] rChars, params string[] maps)
        {
            var rotor = new Rotor(maps);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, new RotorPair(eChars[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(true, true, new[]{"aa", "bb", "cc"})]
        [InlineData(false, true, new[]{"abc", "abc"})]
        [InlineData(true, true, new[]{"ac", "bb", "ca"})]
        [InlineData(false, true, new[]{"abc", "cba"})]
        [InlineData(true, true, new[]{"ab", "bc", "ca"})]
        [InlineData(false, true, new[]{"abc", "bca"})]
        [InlineData(true, false, new[]{"aa", "ba", "cc"})]
        [InlineData(false, false, new[]{"abc", "aac"})]
        [InlineData(true, false, new[]{"aa", "ab", "cc"})]
        [InlineData(false, false, new[]{"aac", "abc"})]
        [InlineData(true, false, new[]{"aa", "ab", "cc", "dc"})]
        [InlineData(false, false, new[]{"aacd", "abcc"})]
        public void RotorCanBeValidated(bool twoStrings, bool isValid, string[] maps)
        {
            var action = () => {var rotor = twoStrings ? new Rotor(maps) : new Rotor(maps[0], maps[1]);};
            if (isValid)
            {
                action();
            }
            else
            {
                var ex = Record.Exception(action);
                Assert.IsType<ArgumentException>(ex);
            }
        }
        [Theory]
        [InlineData("abcde", "bcdea", 'c', 'd')]
        [InlineData("abcde", "bcdea", 'f', null)]
        [InlineData("大熊貓可愛", "可愛熊貓大", '貓', '熊')]
        [InlineData("大熊貓可愛", "可愛熊貓大", '人', null)]
        public void RotorCanPassCharacterFromEntryWheel(string e, string r, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, new Rotor(e, r).FromEntryWheel(input));
            if (expected is not null)
            {
                action();
            }
            else
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
        [Theory]
        [InlineData("bcdea", "abcde", 'c', 'd')]
        [InlineData("bcdea", "abcde", 'f', null)]
        [InlineData("可愛熊貓大", "大熊貓可愛", '貓', '熊')]
        [InlineData("可愛熊貓大", "大熊貓可愛", '人', null)]
        public void RotorCanPassCharacterFromReflector(string e, string r, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, new Rotor(e, r).FromReflector(input));
            if (expected is not null)
            {
                action();
            }
            else
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
    }
}