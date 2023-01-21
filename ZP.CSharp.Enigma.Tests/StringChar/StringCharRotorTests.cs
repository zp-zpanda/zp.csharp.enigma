using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class StringCharRotorTests
    {
        [Fact]
        public void RotorPairsCanBeAddedToRotor()
        {
            var pair1 = StringCharRotorPair.New('a', 'z');
            var pair2 = StringCharRotorPair.New('z', 'a');
            var rotor = StringCharRotor.New(0, new[]{0}, pair1, pair2);
            Assert.Contains(pair1, rotor.Pairs);
            Assert.Contains(pair2, rotor.Pairs);
        }
        [Theory]
        [InlineData("abcd", "cdab", new char[]{'a', 'b', 'c', 'd'}, new char[]{'c', 'd', 'a', 'b'})]
        [InlineData("你我他大熊貓", "大熊貓你我他", new char[]{'你', '我', '他', '大', '熊', '貓'}, new char[]{'大', '熊', '貓', '你', '我', '他'})]
        public void RotorPairsCanBeMassConstructedFromTwoMappings(string e, string r, char[] eChars, char[] rChars)
        {
            var rotor = StringCharRotor.New(0, new[]{0}, e, r);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, StringCharRotorPair.New(eChars[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(new char[]{'a', 'b', 'c', 'd'}, new char[]{'c', 'd', 'a', 'b'}, "ac", "bd", "ca", "db")]
        [InlineData(new char[]{'你', '我', '他', '大', '熊', '貓'}, new char[]{'大', '熊', '貓', '你', '我', '他'}, "你大", "我熊", "他貓", "大你", "熊我", "貓他")]
        public void RotorPairsCanBeMassConstructedFromTwoCharLongMappings(char[] eChars, char[] rChars, params string[] maps)
        {
            var rotor = StringCharRotor.New(0, new[]{0}, maps);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, StringCharRotorPair.New(eChars[i], rChars[i]));
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
            var action = () => {var rotor = twoStrings ? StringCharRotor.New(0, new[]{0}, maps) : StringCharRotor.New(0, new[]{0}, maps[0], maps[1]);};
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
            var action = () => Assert.Equal(expected, StringCharRotor.New(0, new[]{0}, e, r).FromEntryWheel(input));
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
            var action = () => Assert.Equal(expected, StringCharRotor.New(0, new[]{0}, e, r).FromReflector(input));
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
        [InlineData("abcde", "edcba", 'a', new[]{'e', 'c', 'a', 'd', 'b'})]
        public void RotorCanRotate(string e, string r, char eChar, char[] rArr)
        {
            var rotor = StringCharRotor.New(0, new[]{0}, e, r);
            Assert.All(rArr, rChar => {
                var result = rotor.FromEntryWheel(eChar);
                Assert.Equal(rChar, result);
                rotor.Step();
            });
        }
        [Theory]
        [InlineData("abcde", "edcba", 0, 'a', 'e')]
        [InlineData("abcde", "edcba", 2, 'a', 'a')]
        [InlineData("abcde", "edcba", 4, 'a', 'b')]
        public void RotorCanRotateStringCharacterBasingOnPosition(string e, string r, int pos, char eChar, char rChar)
        {
            var rotor = StringCharRotor.New(pos, new[]{0}, e, r);
            Assert.Equal(rChar, rotor.FromEntryWheel(eChar));
            Assert.Equal(eChar, rotor.FromReflector(rChar));
        }
        [Theory]
        [InlineData(5, 2)]
        [InlineData(14, 7)]
        [InlineData(345, 56)]
        public void RotorCanAllowNextToStep(int total, int notch)
        {
            var map = new string(Enumerable.Range(0, total).Select(i => (char) i).ToArray());
            var rotor = StringCharRotor.New(0, new[]{notch}, map, map);
            var canStepArr = Enumerable.Range(0, total).Select(pos => pos == notch);
            Assert.All(canStepArr, canStep => {
                Assert.Equal(canStep, rotor.AllowNextToStep());
                rotor.Step();
            });
        }
    }
}