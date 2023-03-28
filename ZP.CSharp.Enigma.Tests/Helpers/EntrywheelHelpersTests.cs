using System;
using Xunit;
using ZP.CSharp.Enigma.Helpers.WithSideEffects;
namespace ZP.CSharp.Enigma.Helpers.Tests
{
    public class EntrywheelHelpersTests
    {
        public static Entrywheel<int> TestEntrywheel => Entrywheel<int>.New(
            new[]{
                EntrywheelPair<int>.New(0, 0),
                EntrywheelPair<int>.New(1, 1),
                EntrywheelPair<int>.New(2, 2),
                EntrywheelPair<int>.New(3, 3)}
        );
        [Fact]
        public void DefaultChainShouldNotHaveSideEffects()
        {
            var entrywheel = TestEntrywheel;
            var newEntrywheel = entrywheel.WithPairs(
                    new[]{
                        EntrywheelPair<int>.New(0, 2),
                        EntrywheelPair<int>.New(1, 1),
                        EntrywheelPair<int>.New(2, 0),
                        EntrywheelPair<int>.New(3, 3)}
                );
            Assert.False(ReferenceEquals(entrywheel, newEntrywheel));
        }
        [Fact]
        public void SideEffectChainShouldHaveSideEffects()
        {
            var entrywheel = TestEntrywheel;
            var newEntrywheel = entrywheel.Is().WithPairs(
                    EntrywheelPair<int>.New(0, 2),
                    EntrywheelPair<int>.New(1, 1),
                    EntrywheelPair<int>.New(2, 0),
                    EntrywheelPair<int>.New(3, 3)
                ).Entrywheel;
            Assert.True(ReferenceEquals(entrywheel, newEntrywheel));
        }
        [Fact]
        public void EncapsulatingTypeCannotBeExplicitlyCreated()
        {
            var action = () => {
                var enigma = SideEffectRecordingEntrywheelWrapper<Entrywheel<int>, EntrywheelPair<int>, int>
                    .New(TestEntrywheel.Pairs);
            };
            Assert.Throws<NotSupportedException>(action);
        }
    }
}