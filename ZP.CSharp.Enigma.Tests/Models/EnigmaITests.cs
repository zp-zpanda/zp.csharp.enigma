using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Models;
using ZP.CSharp.Enigma.Models.Tests;
namespace ZP.CSharp.Enigma.Models.Tests
{
    public class EnigmaITests
    {
        public static TheoryData<string, (string, string, string), (int, int, int), char> EnigmaWillNotReturnInputAsOutputData
        {
            get => new TheoryData<string, (string, string, string), (int, int, int), char>()
            {
                {"A", ("IV", "V", "III"), (0, 0, 0), 'g'},
                {"B", ("III", "II", "I"), (0, 0, 0), 'a'},
                {"B", ("V", "III", "I"), (0, 0, 0), 'e'},
                {"C", ("IV", "V", "III"), (0, 0, 0), 'n'}
            };
        }
        public static TheoryData<string, (string, string, string), (int, int, int), string, string> EnigmaWillReturnCipheredOutputData
        {
            get => new TheoryData<string, (string, string, string), (int, int, int), string, string>()
            {
                {"A", ("III", "II", "I"), (0, 0, 0), "ENIGMAISTHEBEST", "QGHORKYIVKJMYNY"},
                {"B", ("III", "II", "I"), (0, 0, 0), "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "FUVEPUMWARVQKEFGHGDIJFMFXI"},
                {"B", ("III", "II", "I"), (0, 3, 15), "ABC", "DNZ"},
                {"B", ("V", "III", "I"), (0, 13, 25), "ENIGMAISTHEBEST", "RRLQVZUINJBJTFY"},
                {"B", ("IV", "V", "III"), (0, 0, 0), "ENIGMAISTHEBEST", "JAMSKSEGAKPDWRI"},
                {"C", ("V", "I", "II"), (0, 0, 0), "ENIGMAISTHEBEST", "XBVCSUHOYIWOBAF"}
            };
        }
        [Theory]
        [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
        public void EnigmaWillNotReturnInputAsOutput(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos, char c)
        {
            Assert.NotEqual(c, new EnigmaI(reflector, rotors, pos).RunOn(c));
        }
        [Theory]
        [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
        public void EnigmaWillReturnCipheredOutput(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos, string plain, string cipher)
        {
            var result = new EnigmaI(reflector, rotors, pos).RunOn(cipher);
            Assert.Equal(plain, result);
        }
    }
}