using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class EnigmaTests
    {
        public Enigma TestEnigma = new Enigma(new Reflector(new ReflectorPair("ab"), new ReflectorPair("cd")), new Rotor(0, 0, new RotorPair("ac"), new RotorPair("ba"), new RotorPair("cd"), new RotorPair("db")));
        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('c')]
        [InlineData('d')]
        public void EnigmaWillNotReturnInputAsOutput(char c)
        {
            Assert.NotEqual(c, this.TestEnigma.RunOn(c));
        }
        [Theory]
        [InlineData("abcd", "cdab")]
        public void EnigmaWillReturnCipheredOutput(string plain, string cipher)
        {
            Assert.Equal(cipher, this.TestEnigma.RunOn(plain));
            Assert.Equal(plain, this.TestEnigma.RunOn(cipher));
        }
    }
}