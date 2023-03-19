using System;
using Xunit;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class EntrywheelTests
    {
        [Fact]
        public void EntrywheelPairsCanBeAddedToEntrywheel()
        {
            var pair1 = EntrywheelPair<int>.New(0, 1);
            var pair2 = EntrywheelPair<int>.New(1, 0);
            var entrywheel = Entrywheel<int>.New(new[]{pair1, pair2});
            Assert.Contains(pair1, entrywheel.Pairs);
            Assert.Contains(pair2, entrywheel.Pairs);
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1}, new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1})]
        public void EntrywheelPairsCanBeMassConstructedFromTwoMappings(int[] p, int[] r, int[] pChars, int[] rChars)
        {
            var entrywheel = Entrywheel<int>.New(p, r);
            Assert.All(entrywheel.Pairs, (pair, index) => Assert.Equal(pair, EntrywheelPair<int>.New(pChars[index], rChars[index])));
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1}, new[]{0, 2}, new[]{1, 3}, new[]{2, 0}, new[]{3, 1})]
        public void EntrywheelPairsCanBeMassConstructedFromTwoCharLongMappings(int[] pChars, int[] rChars, params int[][] maps)
        {
            var entrywheel = Entrywheel<int>.New(maps);
            Assert.All(entrywheel.Pairs, (pair, index) => Assert.Equal(pair, EntrywheelPair<int>.New(pChars[index], rChars[index])));
        }
        [Theory]
        [InlineData(true, true, new[]{0, 0}, new[]{1, 1}, new[]{2, 2})]
        [InlineData(false, true, new[]{0, 1, 2}, new[]{0, 1, 2})]
        [InlineData(true, true, new[]{0, 2}, new[]{1, 1}, new[]{2, 0})]
        [InlineData(false, true, new[]{0, 1, 2}, new[]{2, 1, 0})]
        [InlineData(true, true, new[]{0, 1}, new[]{1, 2}, new[]{2, 0})]
        [InlineData(false, true, new[]{0, 1, 2}, new[]{1, 2, 0})]
        [InlineData(true, false, new[]{0, 0}, new[]{1, 0}, new[]{2, 2})]
        [InlineData(false, false, new[]{0, 1, 2}, new[]{0, 0, 2})]
        [InlineData(true, false, new[]{0, 0}, new[]{0, 1}, new[]{2, 2})]
        [InlineData(false, false, new[]{0, 0, 2}, new[]{0, 1, 2})]
        [InlineData(true, false, new[]{0, 0}, new[]{0, 1}, new[]{2, 2}, new[]{3, 2})]
        [InlineData(false, false, new[]{0, 0, 2, 3}, new[]{0, 1, 2, 2})]
        public void EntrywheelCanBeValidated(bool twoStrings, bool isValid, params int[][] maps)
        {
            var action = () => {var entrywheel = twoStrings ? Entrywheel<int>.New(maps) : Entrywheel<int>.New(maps[0], maps[1]);};
            if (!isValid)
            {
                var ex = Record.Exception(action);
                Assert.IsType<ArgumentException>(ex);
            }
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{1, 2, 3, 4, 0}, 2, 3)]
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{1, 2, 3, 4, 0}, 5, null)]
        public void EntrywheelCanPassCharacterFromPlugboard(int[] p, int[] r, int input, int? expected)
        {
            var action = () => Assert.Equal(expected, Entrywheel<int>.New(p, r).FromPlugboard(input));
            if (expected is null)
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
        [Theory]
        [InlineData(new[]{1, 2, 3, 4, 0}, new[]{0, 1, 2, 3, 4}, 2, 3)]
        [InlineData(new[]{1, 2, 3, 4, 0}, new[]{0, 1, 2, 3, 4}, 5, null)]
        public void EntrywheelCanPassCharacterFromReflector(int[] p, int[] r, int input, int? expected)
        {
            var action = () => Assert.Equal(expected, Entrywheel<int>.New(p, r).FromReflector(input));
            if (expected is null)
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
    }
}