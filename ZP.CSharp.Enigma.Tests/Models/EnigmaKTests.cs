using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Models;
using ZP.CSharp.Enigma.Models.Tests;
namespace ZP.CSharp.Enigma.Models.Tests
{
    public class EnigmaKTests
    {
        public static TheoryData<(string, string, string), (int, int, int), char> EnigmaWillNotReturnInputAsOutputData
            => new(){
                {("I", "II", "III"), (0, 0, 0), 'G'},
                {("III", "II", "I"), (0, 0, 0), 'A'},
                {("II", "III", "I"), (0, 0, 0), 'E'},
                {("II", "I", "III"), (0, 0, 0), 'N'}
            };
        public static TheoryData<(string, string, string), (int, int, int), string, string> EnigmaWillReturnCipheredOutputData
            => new(){
                {("III", "II", "I"), (0, 0, 0), "ENIGMAISTHEBEST", "VGNTJTVANJNSDJX"},
                {("III", "II", "I"), (0, 0, 0), "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "HPUOFEBYDHBVIAHDXXZZVEMZUA"},
                {("III", "II", "I"), (0, 0, 24), "ABC", "GCT"}
            };
        [Theory]
        [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
        public void EnigmaWillNotReturnInputAsOutput((string III, string II, string I) rotors, (int III, int II, int I) pos, char c)
        {
            var enigma = EnigmaK.New(rotors, pos);
            var result = enigma.RunOn(c);
            Assert.NotEqual(c, result);
        }
        [Theory]
        [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
        public void EnigmaWillReturnCipheredOutput((string III, string II, string I) rotors, (int III, int II, int I) pos, string plain, string cipher)
        {
            var enigma = EnigmaK.New(rotors, pos);
            var result = enigma.RunOn(plain);
            Assert.Equal(cipher, result);
        }
    }
}