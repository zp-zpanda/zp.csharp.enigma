using System;
using Xunit;
using ZP.CSharp.Enigma.Helpers.WithSideEffects;
namespace ZP.CSharp.Enigma.Helpers.Tests
{
    public class RotorHelpersTests
    {
        public static Rotor<int> TestRotor => Rotor<int>.New(
                0,
                new[]{0},
                RotorPair<int>.New(0, 2),
                RotorPair<int>.New(1, 0),
                RotorPair<int>.New(2, 3),
                RotorPair<int>.New(3, 1)
            );
        [Fact]
        public void DefaultChainShouldNotHaveSideEffects()
        {
            var rotor = TestRotor;
            var newRotor = rotor.With(
                    0,
                    new[]{0},
                    RotorPair<int>.New(0, 0),
                    RotorPair<int>.New(1, 3),
                    RotorPair<int>.New(2, 1),
                    RotorPair<int>.New(3, 2)
                );
            Assert.False(ReferenceEquals(rotor, newRotor));
        }
        [Fact]
        public void SideEffectChainShouldHaveSideEffects()
        {
            var rotor = TestRotor;
            var newRotor = rotor.Is().With(
                    0,
                    new[]{0},
                    RotorPair<int>.New(0, 0),
                    RotorPair<int>.New(1, 3),
                    RotorPair<int>.New(2, 1),
                    RotorPair<int>.New(3, 2)
            ).Rotor;
            Assert.True(ReferenceEquals(rotor, newRotor));
        }
        [Fact]
        public void EncapsulatingTypeCannotBeExplicitlyCreated()
        {
            var action = () => {
                var enigma = SideEffectRecordingRotorWrapper<Rotor<int>, RotorPair<int>, int>
                    .New(TestRotor.Pairs);
            };
            Assert.Throws<NotSupportedException>(action);
        }
    }
}