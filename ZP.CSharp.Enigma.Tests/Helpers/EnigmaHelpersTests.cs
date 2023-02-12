using System;
using System.Collections.Generic;
using Xunit;
using ZP.CSharp.Enigma.Helpers.WithSideEffects;
namespace ZP.CSharp.Enigma.Helpers.Tests
{
    public class EnigmaHelpersTests
    {
        public static Enigma<IEnumerable<int>, int> TestEnigma => Enigma<IEnumerable<int>, int>.New(
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
        [Fact]
        public void DefaultChainShouldNotHaveSideEffects()
        {
            var enigma = TestEnigma;
            var newEnigma = enigma.With(
                Entrywheel<int>.New(
                    EntrywheelPair<int>.New(0, 2),
                    EntrywheelPair<int>.New(1, 1),
                    EntrywheelPair<int>.New(2, 0),
                    EntrywheelPair<int>.New(3, 3)
                ),
                Reflector<int>.New(
                    ReflectorPair<int>.New(0, 3),
                    ReflectorPair<int>.New(2, 1)
                ),
                Rotor<int>.New(
                    0,
                    new[]{0},
                    RotorPair<int>.New(0, 0),
                    RotorPair<int>.New(1, 3),
                    RotorPair<int>.New(2, 1),
                    RotorPair<int>.New(3, 2)
                )
            );
            Assert.False(ReferenceEquals(enigma, newEnigma));
        }
        [Fact]
        public void SideEffectChainShouldHaveSideEffects()
        {
            var enigma = TestEnigma;
            var newEnigma = enigma.Is().With(
                Entrywheel<int>.New(
                    EntrywheelPair<int>.New(0, 2),
                    EntrywheelPair<int>.New(1, 1),
                    EntrywheelPair<int>.New(2, 0),
                    EntrywheelPair<int>.New(3, 3)
                ),
                Reflector<int>.New(
                    ReflectorPair<int>.New(0, 3),
                    ReflectorPair<int>.New(2, 1)
                ),
                Rotor<int>.New(
                    0,
                    new[]{0},
                    RotorPair<int>.New(0, 0),
                    RotorPair<int>.New(1, 3),
                    RotorPair<int>.New(2, 1),
                    RotorPair<int>.New(3, 2)
                )
            ).Enigma;
            Assert.True(ReferenceEquals(enigma, newEnigma));
        }
        [Fact]
        public void EncapsulatingTypeCannotBeExplicitlyCreated()
        {
            var action = () => {
                var enigma = SideEffectRecordingEnigmaWrapper<Enigma<IEnumerable<int>, int>, Entrywheel<int>, EntrywheelPair<int>, Rotor<int>, RotorPair<int>, Reflector<int>, ReflectorPair<int>, IEnumerable<int>, int>
                    .New(TestEnigma.Entrywheel, TestEnigma.Reflector, TestEnigma.Rotors);
            };
            Assert.Throws<NotSupportedException>(action);
        }
    }
}