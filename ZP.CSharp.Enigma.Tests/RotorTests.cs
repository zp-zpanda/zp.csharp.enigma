using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class RotorTests
    {
        [Fact]
        public void RotorPairsCanBeAddedToRotor()
        {
            var pair1 = RotorPair<int>.New(0, 1);
            var pair2 = RotorPair<int>.New(1, 0);
            var rotor = Rotor<int>.New(0, new[]{0}, new[]{pair1, pair2});
            Assert.Contains(pair1, rotor.Pairs);
            Assert.Contains(pair2, rotor.Pairs);
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1}, new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1})]
        public void RotorPairsCanBeMassConstructedFromTwoMappings(int[] e, int[] r, int[] eChars, int[] rChars)
        {
            var rotor = Rotor<int>.New(0, new[]{0}, e, r);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, RotorPair<int>.New(eChars[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1}, new[]{0, 2}, new[]{1, 3}, new[]{2, 0}, new[]{3, 1})]
        public void RotorPairsCanBeMassConstructedFromTwoCharLongMappings(int[] eChars, int[] rChars, params int[][] maps)
        {
            var rotor = Rotor<int>.New(0, new[]{0}, maps);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, RotorPair<int>.New(eChars[i], rChars[i]));
                i++;
            });
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
        public void RotorCanBeValidated(bool twoStrings, bool isValid, params int[][] maps)
        {
            var action = () => {var rotor = twoStrings ? Rotor<int>.New(0, new[]{0}, maps) : Rotor<int>.New(0, new[]{0}, maps[0], maps[1]);};
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
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{1, 2, 3, 4, 0}, 2, 3)]
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{1, 2, 3, 4, 0}, 5, null)]
        public void RotorCanPassCharacterFromEntryWheel(int[] e, int[] r, int input, int? expected)
        {
            var action = () => Assert.Equal(expected, Rotor<int>.New(0, new[]{0}, e, r).FromEntryWheel(input));
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
        [InlineData(new[]{1, 2, 3, 4, 0}, new[]{0, 1, 2, 3, 4}, 2, 3)]
        [InlineData(new[]{1, 2, 3, 4, 0}, new[]{0, 1, 2, 3, 4}, 5, null)]
        public void RotorCanPassCharacterFromReflector(int[] e, int[] r, int input, int? expected)
        {
            var action = () => Assert.Equal(expected, Rotor<int>.New(0, new[]{0}, e, r).FromReflector(input));
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
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{4, 3, 2, 1, 0}, 0, new[]{4, 2, 0, 3, 1})]
        public void RotorCanRotate(int[] e, int[] r, int eChar, int[] rArr)
        {
            var rotor = Rotor<int>.New(0, new[]{0}, e, r);
            Assert.All(rArr, rChar => {
                var result = rotor.FromEntryWheel(eChar);
                Assert.Equal(rChar, result);
                rotor.Step();
            });
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{4, 3, 2, 1, 0}, 0, 0, 4)]
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{4, 3, 2, 1, 0}, 2, 0, 0)]
        [InlineData(new[]{0, 1, 2, 3, 4}, new[]{4, 3, 2, 1, 0}, 4, 0, 1)]
        public void RotorCanRotateCharacterBasingOnPosition(int[] e, int[] r, int pos, int eChar, int rChar)
        {
            var rotor = Rotor<int>.New(pos, new[]{0}, e, r);
            Assert.Equal(rChar, rotor.FromEntryWheel(eChar));
            Assert.Equal(eChar, rotor.FromReflector(rChar));
        }
        [Theory]
        [InlineData(5, 2)]
        [InlineData(14, 7)]
        [InlineData(345, 56)]
        public void RotorCanAllowNextToStep(int total, int notch)
        {
            var map = Enumerable.Range(0, total);
            var rotor = Rotor<int>.New(0, new[]{notch}, map, map);
            var canStepArr = Enumerable.Range(0, total).Select(pos => pos == notch);
            Assert.All(canStepArr, canStep => {
                Assert.Equal(canStep, rotor.AllowNextToStep());
                rotor.Step();
            });
        }
    }
}