using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Models;
using ZP.CSharp.Enigma.Models.Tests;
namespace ZP.CSharp.Enigma.Models.Tests
{
    public class M3EnigmaTests
    {
        public static TheoryData<(string, string, string), (int, int, int), char> EnigmaWillNotReturnInputAsOutputData
        {
            get => new TheoryData<(string, string, string), (int, int, int), char>()
            {
                {("III", "II", "I"), (0, 0, 0), 'a'},
                {("III", "II", "I"), (0, 0, 0), 'b'},
                {("III", "II", "I"), (0, 0, 0), 'x'},
                {("III", "II", "I"), (0, 0, 0), 'y'},
                {("V", "III", "I"), (0, 0, 0), 'e'},
                {("IV", "V", "III"), (0, 0, 0), 'n'}
            };
        }
        public static TheoryData<(string, string, string), (int, int, int), string, string> EnigmaWillReturnCipheredOutputData
        {
            get => new TheoryData<(string, string, string), (int, int, int), string, string>()
            {
                {("III", "II", "I"), (0, 0, 0), "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "FUVEPUMWARVQKEFGHGDIJFMFXI"},
                {("III", "II", "I"), (0, 3, 15), "ABC", "DNZ"},
                {("V", "III", "I"), (0, 13, 25), "ENIGMAISTHEBEST", "RRLQVZUINJBJTFY"},
                {("IV", "V", "III"), (0, 0, 0), "ENIGMAISTHEBEST", "JAMSKSEGAKPDWRI"}
            };
        }
        [Theory]
        [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
        public void EnigmaWillNotReturnInputAsOutput((string III, string II, string I) rotors, (int III, int II, int I) pos, char c)
        {
            Assert.NotEqual(c, new M3Enigma(rotors, pos).RunOn(c));
        }
        [Theory]
        [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
        public void EnigmaWillReturnCipheredOutput((string III, string II, string I) rotors, (int III, int II, int I) pos, string plain, string cipher)
        {
            var result = new M3Enigma(rotors, pos).RunOn(cipher);
            Assert.Equal(plain, result);
        }
    }
}