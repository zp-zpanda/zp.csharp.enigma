using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers.WithSideEffects
{
    /**
    <summary>Side-effect-recording wrapper class for the entrywheel.</summary>
    */
    public class SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle>
        : IEntrywheel<SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle>, TEntrywheelPair, TSingle>
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private TEntrywheel _Entrywheel;
        /**
        <summary>The wrapped entrywheel.</summary>
        */
        public required TEntrywheel Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Pairs" />
        */
        public required TEntrywheelPair[] Pairs {get => this.Entrywheel.Pairs; set => this.Entrywheel.Pairs = value;}
        /**
        <inheritdoc cref="New(TEntrywheelPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public SideEffectRecordingEntrywheelWrapper()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.New(TEntrywheelPair[])" />
        */
        public static SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle> New(params TEntrywheelPair[] pairs)
            => throw new NotSupportedException("This entrywheel is for encapsulation purposes only.");
        /**
        <summary>Wraps the entrywheel for side-effect-recording.</summary>
        */
        public static SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle> New(TEntrywheel entrywheel)
            => new(){
                Entrywheel = entrywheel
            };
        /**
        <summary>Modifies the entrywheel to be with the provided entrywheel pairs.</summary>
        */
        public SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle> WithPairs(params TEntrywheelPair[] pairs)
        {
            this.Entrywheel.Pairs = pairs;
            return this;
        }
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.IsValid()" />
        */
        public bool IsValid() => this.Entrywheel.IsValid();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.FromReflector(TSingle)" />
        */
        public TSingle FromPlugboard(TSingle c) => this.Entrywheel.FromPlugboard(c);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.FromReflector(TSingle)" />
        */
        public TSingle FromReflector(TSingle c) => this.Entrywheel.FromReflector(c);
    }
    /**
    <summary>Helpers for the side-effect-recording wrapper class for the entrywheel.</summary>
    */
    public static class SideEffectRecordingEntrywheelWrapperHelpers
    {
        /**
        <inheritdoc cref="SideEffectRecordingEntrywheelWrapper{TEntrywheel, TEntrywheelPair, TSingle}.New(TEntrywheel)" />
        */
        public static SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle>
            Is<TEntrywheel, TEntrywheelPair, TSingle>(
                this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> entrywheel)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => SideEffectRecordingEntrywheelWrapper<TEntrywheel, TEntrywheelPair, TSingle>.New((TEntrywheel) entrywheel);
    }
}