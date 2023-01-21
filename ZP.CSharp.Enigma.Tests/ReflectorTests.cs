using System;
using Xunit;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class ReflectorTests
    {
        [Fact]
        public void ReflectorPairsCanBeAddedToReflector()
        {
            var pair1 = ReflectorPair<int>.New(0, 1);
            var pair2 = ReflectorPair<int>.New(2, 3);
            var reflector = Reflector<int>.New(pair1, pair2);
            Assert.Contains(pair1, reflector.Pairs);
            Assert.Contains(pair2, reflector.Pairs);
        }
        [Theory]
        [InlineData(new[]{0, 2}, new[]{1, 3}, new[]{0, 1}, new[]{2, 3})]
        public void ReflectorPairsCanBeMassConstructedFromTwoCharLongMappings(int[] oneChars, int[] twoChars, params int[][] maps)
        {
            var reflector = Reflector<int>.New(maps);
            Assert.All(reflector.Pairs, (pair, index) => Assert.Equal(pair, ReflectorPair<int>.New(oneChars[index], twoChars[index])));
        }
        [Theory]
        [InlineData(true, new[]{0, 1}, new[]{2, 3})]
        [InlineData(false, new[]{0, 2}, new[]{2, 0})]
        [InlineData(false, new[]{0, 2}, new[]{1, 1})]
        [InlineData(false, new[]{0, 1}, new[]{1, 2})]
        public void ReflectorCanBeValidated(bool isValid, params int[][] maps)
        {
            var action = () => {var reflector = Reflector<int>.New(maps);};
            if (!isValid)
            {
                var ex = Record.Exception(action);
                Assert.IsType<ArgumentException>(ex);
            }
        }
        [Theory]
        [InlineData(2, 3, new[]{0, 1}, new[]{2, 3}, new[]{4, 5})]
        [InlineData(6, null, new[]{0, 1}, new[]{2, 3}, new[]{4, 5})]
        public void ReflectorCanReflectCharacter(int input, int? expected, params int[][] maps)
        {
            var action = () => Assert.Equal(expected, Reflector<int>.New(maps).Reflect(input));
            if (expected is null)
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
    }
}