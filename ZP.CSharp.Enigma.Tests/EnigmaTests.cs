using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class EnigmaTests
    {
        public Enigma TestEnigma = Enigma.FromRotorAndReflector(
            Reflector.WithReflectorPairs(
                ReflectorPair.WithMap("ab"),
                ReflectorPair.WithMap("cd")
            ),
            Rotor.WithPositionNotchAndRotorPairs(
                0,
                new[]{0},
                RotorPair.WithMap("ac"),
                RotorPair.WithMap("ba"),
                RotorPair.WithMap("cd"),
                RotorPair.WithMap("db")
            )
        );
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