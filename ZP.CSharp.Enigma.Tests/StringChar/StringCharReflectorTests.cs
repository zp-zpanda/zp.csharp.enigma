using System;
using Xunit;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class StringCharReflectorTests
    {
        [Fact]
        public void ReflectorPairsCanBeAddedToReflector()
        {
            var pair1 = StringCharReflectorPair.New('a', 'z');
            var pair2 = StringCharReflectorPair.New('b', 'y');
            var reflector = StringCharReflector.New(pair1, pair2);
            Assert.Contains(pair1, reflector.Pairs);
            Assert.Contains(pair2, reflector.Pairs);
        }
        [Theory]
        [InlineData(new char[]{'a', 'c'}, new char[]{'b', 'd'}, "ab", "cd")]
        [InlineData(new char[]{'你', '我', '他'}, new char[]{'大', '熊', '貓'}, "你大", "我熊", "他貓")]
        public void ReflectorPairsCanBeMassConstructedFromTwoCharLongMappings(char[] oneChars, char[] twoChars, params string[] maps)
        {
            var reflector = StringCharReflector.New(maps);
            Assert.All(reflector.Pairs, (pair, index) => Assert.Equal(pair, StringCharReflectorPair.New(oneChars[index], twoChars[index])));
        }
        [Theory]
        [InlineData(true, new[]{"ab", "cd"})]
        [InlineData(false, new[]{"ac", "ca"})]
        [InlineData(false, new[]{"ac", "bb"})]
        [InlineData(false, new[]{"ab", "bc"})]
        public void ReflectorCanBeValidated(bool isValid, string[] maps)
        {
            var action = () => {var reflector = StringCharReflector.New(maps);};
            if (!isValid)
            {
                var ex = Record.Exception(action);
                Assert.IsType<ArgumentException>(ex);
            }
        }
        [Theory]
        [InlineData(new[]{"ab", "cd", "ef"}, 'c', 'd')]
        [InlineData(new[]{"ab", "cd", "ef"}, 'g', null)]
        [InlineData(new[]{"大的", "熊貓", "可愛"}, '貓', '熊')]
        [InlineData(new[]{"大的", "熊貓", "可愛"}, '人', null)]
        public void ReflectorCanReflectCharacter(string[] maps, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, StringCharReflector.New(maps).Reflect(input));
            if (expected is null)
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
    }
}