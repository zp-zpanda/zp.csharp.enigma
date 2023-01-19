using Xunit;
using ZP.CSharp.Enigma.Helpers;
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