using Xunit;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class StringCharEnigmaTests
    {
        public StringCharEnigma TestEnigma = StringCharEnigma.New(
            StringCharEntrywheel.New(
                StringCharEntrywheelPair.New("aa"),
                StringCharEntrywheelPair.New("bb"),
                StringCharEntrywheelPair.New("cc"),
                StringCharEntrywheelPair.New("dd")
            ),
            StringCharReflector.New(
                StringCharReflectorPair.New("ab"),
                StringCharReflectorPair.New("cd")
            ),
            StringCharRotor.New(
                0,
                new[]{0},
                StringCharRotorPair.New("ac"),
                StringCharRotorPair.New("ba"),
                StringCharRotorPair.New("cd"),
                StringCharRotorPair.New("db")
            )
        );
        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('c')]
        [InlineData('d')]
        public void EnigmaWillNotReturnInputAsOutput(char c)
        {
            var enigma = this.TestEnigma;
            var result = enigma.RunOn(c);
            Assert.NotEqual(c, result);
        }
        [Theory]
        [InlineData("abcd", "cdab")]
        public void EnigmaWillReturnCipheredOutput(string plain, string cipher)
        {
            var enigma = this.TestEnigma;
            var result = enigma.RunOn(plain);
            Assert.Equal(cipher, result);
        }
    }
}