using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers.WithSideEffects
{
    /**
    <summary>Side-effect-recording wrapper class for the reflector.</summary>
    */
    public class SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle>
        : IReflector<SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle>, TReflectorPair, TSingle>
        where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
        where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private TReflector _Reflector;
        /**
        <summary>The wrapped reflector.</summary>
        */
        public required TReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.Pairs" />
        */
        public required TReflectorPair[] Pairs {get => this.Reflector.Pairs; set => this.Reflector.Pairs = value;}
        /**
        <inheritdoc cref="New(TReflectorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public SideEffectRecordingReflectorWrapper()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(TReflectorPair[])" />
        */
        public static SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle> New(params TReflectorPair[] pairs)
            => throw new NotSupportedException("This reflector is for encapsulation purposes only.");
        /**
        <summary>Wraps the reflector for side-effect-recording.</summary>
        */
        public static SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle> New(TReflector reflector)
            => new(){
                Reflector = reflector
            };
        /**
        <summary>Modifies the reflector to be with the provided reflector pairs.</summary>
        */
        public SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle> WithPairs(params TReflectorPair[] pairs)
        {
            this.Reflector.Pairs = pairs;
            return this;
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.Reflect(TSingle)" />
        */
        public TSingle Reflect(TSingle c) => this.Reflector.Reflect(c);
    }
    /**
    <summary>Helpers for the side-effect-recording wrapper class for the reflector.</summary>
    */
    public static class SideEffectRecordingReflectorWrapperHelpers
    {
        /**
        <inheritdoc cref="SideEffectRecordingReflectorWrapper{TReflector, TReflectorPair, TSingle}.New(TReflector)" />
        */
        public static SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle>
            Is<TReflector, TReflectorPair, TSingle>(
                this IReflector<TReflector, TReflectorPair, TSingle> reflector)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => SideEffectRecordingReflectorWrapper<TReflector, TReflectorPair, TSingle>.New((TReflector) reflector);
    }
}