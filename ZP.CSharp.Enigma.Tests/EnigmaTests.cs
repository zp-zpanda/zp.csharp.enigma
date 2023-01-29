using System.Collections.Generic;
using Xunit;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Tests
{
    public class EnigmaTests
    {
        public Enigma<IEnumerable<int>, int> TestEnigma = Enigma<IEnumerable<int>, int>.New(
            Entrywheel<int>.New(
                EntrywheelPair<int>.New(0, 0),
                EntrywheelPair<int>.New(1, 1),
                EntrywheelPair<int>.New(2, 2),
                EntrywheelPair<int>.New(3, 3)
            ),
            Reflector<int>.New(
                ReflectorPair<int>.New(0, 1),
                ReflectorPair<int>.New(2, 3)
            ),
            Rotor<int>.New(
                0,
                new[]{0},
                RotorPair<int>.New(0, 2),
                RotorPair<int>.New(1, 0),
                RotorPair<int>.New(2, 3),
                RotorPair<int>.New(3, 1)
            )
        );
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void EnigmaWillNotReturnInputAsOutput(char c)
        {
            var enigma = this.TestEnigma;
            var result = enigma.RunOn(c);
            Assert.NotEqual(c, result);
        }
        [Theory]
        [InlineData(new[]{0, 1, 2, 3}, new[]{2, 3, 0, 1})]
        public void EnigmaWillReturnCipheredOutput(int[] plain, int[] cipher)
        {
            var enigma = this.TestEnigma;
            var result = enigma.RunOn(plain);
            Assert.Equal(cipher, result);
        }
    }
}