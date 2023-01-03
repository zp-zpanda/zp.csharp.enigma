using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations.Tests;
namespace ZP.CSharp.Enigma.Implementations.Tests
{
    public class AlphabeticalRotorTests
    {
        [Theory]
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV",
            new char[]{
                'Z', 'Q', 'I', 'P', 'A',
                'B', 'T' ,'G', 'M', 'X',
                'L', 'K', 'C', 'R', 'U',
                'E', 'F', 'W', 'N', 'S',
                'Y', 'D', 'J', 'H', 'O',
                'V'})]
        public void RotorPairsCanBeMassConstructedFromMapping(string r, char[] rChars)
        {
            var rotor = AlphabeticalRotor.New(0, new[]{0}, r);
            var i = 0;
            Assert.All(rotor.Pairs, pair => {
                Assert.Equal(pair, AlphabeticalRotorPair.New(AlphabeticalRotor.Letters[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(true, "ZQIPABTGMXLKCRUEFWNSYDJHOV")]
        [InlineData(true, "PABTGMXLKZIQCRUEFWNSYDJHOV")]
        [InlineData(false, "abcdefghijklmnopqrstuvwxyz")]
        [InlineData(false, "ZQIPABTGMXLKCRUEFWNSYDJHO")]
        public void RotorCanBeValidated(bool isValid, string r)
        {
            var action = () => {var rotor = AlphabeticalRotor.New(0, new[]{0}, r);};
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
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", 'A', 'Z')]
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", '我', null)]
        public void RotorCanPassCharacterFromEntryWheel(string r, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, AlphabeticalRotor.New(0, new[]{0}, r).FromEntryWheel(input));
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
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", 'A', 'E')]
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", '我', null)]
        public void RotorCanPassCharacterFromReflector(string r, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, AlphabeticalRotor.New(0, new[]{0}, r).FromReflector(input));
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
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", 5, 'A', new[]{'Z', 'P', 'G', 'M', 'W'})]
        public void RotorCanRotate(string r, int total, char eChar, char[] rArr)
        {
            var rotor = AlphabeticalRotor.New(0, new[]{0}, r);
            for (int i = 0; i < total; i++)
            {
                Assert.Equal(rArr[i], rotor.FromEntryWheel(eChar));
                rotor.Step();
            }
        }
        [Theory]
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", 0, 'A', 'Z')]
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", 12, 'A', 'Q')]
        [InlineData("ZQIPABTGMXLKCRUEFWNSYDJHOV", 25, 'A', 'W')]
        public void RotorCanRotateCharacterBasingOnPosition(string r, int pos, char eChar, char rChar)
        {
            var rotor = AlphabeticalRotor.New(pos, new[]{0}, r);
            Assert.Equal(rChar, rotor.FromEntryWheel(eChar));
            Assert.Equal(eChar, rotor.FromReflector(rChar));
        }
        [Theory]
        [InlineData(5)]
        [InlineData(14)]
        [InlineData(3)]
        public void RotorCanAllowNextToStep(int notch)
        {
            var map = new string(Enumerable.Range('A', AlphabeticalRotor.Letters.Length).Select(i => (char) i).ToArray());
            var rotor = AlphabeticalRotor.New(0, new[]{notch}, map);
            for (int i = 0; i < AlphabeticalRotor.Letters.Length; i++)
            {
                Assert.Equal(i == notch, rotor.AllowNextToStep());
                rotor.Step();
            }
        }
    }
}