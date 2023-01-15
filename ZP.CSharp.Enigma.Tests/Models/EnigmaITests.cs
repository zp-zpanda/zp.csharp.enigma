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
            => new(){
                {"A", ("IV", "V", "III"), (0, 0, 0), 'G'},
                {"B", ("III", "II", "I"), (0, 0, 0), 'A'},
                {"B", ("V", "III", "I"), (0, 0, 0), 'E'},
                {"C", ("IV", "V", "III"), (0, 0, 0), 'N'}
            };
        public static TheoryData<string, (string, string, string), (int, int, int), string, string> EnigmaWillReturnCipheredOutputData
            => new(){
                {"A", ("III", "II", "I"), (0, 0, 0), "ENIGMAISTHEBEST", "QGHORKYIVKJMYNY"},
                {"B", ("III", "II", "I"), (0, 0, 0), "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "FUVEPUMWARVQKEFGHGDIJFMFXI"},
                {"B", ("III", "II", "I"), (0, 3, 15), "ABC", "DNZ"},
                {"B", ("V", "III", "I"), (0, 13, 25), "ENIGMAISTHEBEST", "RRLQVZUINJBJTFY"},
                {"B", ("IV", "V", "III"), (0, 0, 0), "ENIGMAISTHEBEST", "JAMSKSEGAKPDWRI"},
                {"C", ("V", "I", "II"), (0, 0, 0), "ENIGMAISTHEBEST", "XBVCSUHOYIWOBAF"}
            };
        [Theory]
        [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
        public void EnigmaWillNotReturnInputAsOutput(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos, char c)
        {
            var enigma = EnigmaI.New(reflector, rotors, pos);
            var result = enigma.RunOn(c);
            Assert.NotEqual(c, result);
        }
        [Theory]
        [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
        public void EnigmaWillReturnCipheredOutput(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos, string plain, string cipher)
        {
            var enigma = EnigmaI.New(reflector, rotors, pos);
            var result = enigma.RunOn(plain);
            Assert.Equal(cipher, result);
        }
    }
}