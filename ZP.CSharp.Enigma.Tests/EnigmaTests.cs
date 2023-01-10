using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class EnigmaTests
    {
        public Enigma TestEnigma = Enigma.New(
            Entrywheel.New(
                EntrywheelPair.New("aa"),
                EntrywheelPair.New("bb"),
                EntrywheelPair.New("cc"),
                EntrywheelPair.New("dd")
            ),
            Reflector.New(
                ReflectorPair.New("ab"),
                ReflectorPair.New("cd")
            ),
            Rotor.New(
                0,
                new[]{0},
                RotorPair.New("ac"),
                RotorPair.New("ba"),
                RotorPair.New("cd"),
                RotorPair.New("db")
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