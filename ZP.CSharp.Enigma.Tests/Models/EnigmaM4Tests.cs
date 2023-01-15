using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Models;
using ZP.CSharp.Enigma.Models.Tests;
namespace ZP.CSharp.Enigma.Models.Tests
{
    public class EnigmaM4Tests
    {
        public static TheoryData<string, (string, string, string, string), (int, int, int, int), char> EnigmaWillNotReturnInputAsOutputData
            => new(){
                {"B", ("Beta", "III", "II", "I"), (0, 0, 0, 0), 'A'},
                {"B", ("Beta", "V", "III", "I"), (13, 0, 0, 0), 'E'},
                {"C", ("Gamma", "IV", "V", "III"), (0, 0, 0, 0), 'N'},
                {"C", ("Gamma", "VI", "VII", "VIII"), (13, 0, 0, 0), 'B'}
            };
        public static TheoryData<string, (string, string, string, string), (int, int, int, int), string, string> EnigmaWillReturnCipheredOutputData
            => new(){
                {"B", ("Beta", "III", "II", "I"), (0, 0, 0, 0), "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "FUVEPUMWARVQKEFGHGDIJFMFXI"},
                {"B", ("Beta", "III", "II", "I"), (0, 0, 3, 15), "ABC", "DNZ"},
                {"B", ("Gamma", "V", "III", "I"), (13, 0, 13, 25), "ENIGMAISTHEBEST", "AVDECWWUWOIZVPJ"},
                {"C", ("Beta", "IV", "V", "III"), (0, 0, 0, 0), "ENIGMAISTHEBEST", "XIQXQQFVBJJJSGF"},
                {"C", ("Gamma", "V", "I", "II"), (13, 0, 0, 0), "ENIGMAISTHEBEST", "NEFQVEYIBQKLQAW"},
                {"C", ("Gamma", "VI", "VII", "VIII"), (0, 0, 0, 0), "ENIGMAISTHEBEST", "RHFTKSUPQUNFVNW"}
            };
        [Theory]
        [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
        public void EnigmaWillNotReturnInputAsOutput(string reflector, (string IV, string III, string II, string I) rotors, (int IV, int III, int II, int I) pos, char c)
        {
            var enigma = EnigmaM4.New(reflector, rotors, pos);
            var result = enigma.RunOn(c);
            Assert.NotEqual(c, result);
        }
        [Theory]
        [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
        public void EnigmaWillReturnCipheredOutput(string reflector, (string IV, string III, string II, string I) rotors, (int IV, int III, int II, int I) pos, string plain, string cipher)
        {
            var enigma = EnigmaM4.New(reflector, rotors, pos);
            var result = enigma.RunOn(plain);
            Assert.Equal(cipher, result);
        }
    }
}