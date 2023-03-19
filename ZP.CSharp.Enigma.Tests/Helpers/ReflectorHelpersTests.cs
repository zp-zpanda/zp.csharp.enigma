using System;
using Xunit;
using ZP.CSharp.Enigma.Helpers.WithSideEffects;
namespace ZP.CSharp.Enigma.Helpers.Tests
{
    public class ReflectorHelpersTests
    {
        public static Reflector<int> TestReflector => Reflector<int>.New(
            new[]{
                ReflectorPair<int>.New(0, 1),
                ReflectorPair<int>.New(2, 3)}
        );
        [Fact]
        public void DefaultChainShouldNotHaveSideEffects()
        {
            var reflector = TestReflector;
            var newReflector = reflector.WithPairs(
                    ReflectorPair<int>.New(0, 3),
                    ReflectorPair<int>.New(2, 1)
                );
            Assert.False(ReferenceEquals(reflector, newReflector));
        }
        [Fact]
        public void SideEffectChainShouldHaveSideEffects()
        {
            var reflector = TestReflector;
            var newReflector = reflector.Is().WithPairs(
                    ReflectorPair<int>.New(0, 3),
                    ReflectorPair<int>.New(2, 1)
                ).Reflector;
            Assert.True(ReferenceEquals(reflector, newReflector));
        }
        [Fact]
        public void EncapsulatingTypeCannotBeExplicitlyCreated()
        {
            var action = () => {
                var enigma = SideEffectRecordingReflectorWrapper<Reflector<int>, ReflectorPair<int>, int>
                    .New(TestReflector.Pairs);
            };
            Assert.Throws<NotSupportedException>(action);
        }
    }
}