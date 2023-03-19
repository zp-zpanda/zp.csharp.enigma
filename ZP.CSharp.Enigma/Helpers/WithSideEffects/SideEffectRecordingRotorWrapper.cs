using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers.WithSideEffects
{
    /**
    <summary>Side-effect-recording wrapper class for the rotor.</summary>
    */
    public class SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle>
        : IRotor<SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle>, TRotorPair, TSingle>
        where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private TRotor _Rotor;
        /**
        <summary>The wrapped rotor.</summary>
        */
        public required TRotor Rotor {get => this._Rotor; set => this._Rotor = value;}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Position" />
        */
        public required int Position {get => this.Rotor.Position; set => this.Rotor.Position = value;}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Notch" />
        */
        public required int[] Notch {get => this.Rotor.Notch; set => this.Rotor.Notch = value;}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Pairs" />
        */
        public required TRotorPair[] Pairs {get => this.Rotor.Pairs; set => this.Rotor.Pairs = value;}
        /**
        <inheritdoc cref="New(TRotorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public SideEffectRecordingRotorWrapper()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.New(int, int[], IEnumerable{TRotorPair})" />
        */
        public static SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle> New(params TRotorPair[] pairs)
            => throw new NotSupportedException("This rotor is for encapsulation purposes only.");
        /**
        <summary>Wraps the rotor for side-effect-recording.</summary>
        */
        public static SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle> New(TRotor rotor)
            => new(){
                Rotor = rotor
            };
        /**
        <summary>Modifies the rotor to be with the provided position, notches, and rotor pairs.</summary>
        */
        public SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle> With(int pos, int[] notch, params TRotorPair[] pairs)
            => this.WithPosition(pos).WithNotch(notch).WithPairs(pairs);
        /**
        <summary>Modifies the rotor to be with the provided position.</summary>
        */
        public SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle> WithPosition(int pos)
        {
            this.Rotor.Position = pos;
            return this;
        }
        /**
        <summary>Modifies the rotor to be with the provided notches.</summary>
        */
        public SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle> WithNotch(int[] notch)
        {
            this.Rotor.Notch = notch;
            return this;
        }
        /**
        <summary>Modifies the rotor to be with the provided  rotor pairs.</summary>
        */
        public SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle> WithPairs(params TRotorPair[] pairs)
        {
            this.Rotor.Pairs = pairs;
            return this;
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.AllowNextToStep()" />
        */
        public bool AllowNextToStep() => this.Rotor.AllowNextToStep();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Step()" />
        */
        public void Step() => this.Rotor.AllowNextToStep();
    }
    /**
    <summary>Helpers for the side-effect-recording wrapper class for the rotor.</summary>
    */
    public static class SideEffectRecordingRotorWrapperHelpers
    {
        /**
        <inheritdoc cref="SideEffectRecordingRotorWrapper{TRotor, TRotorPair, TSingle}.New(TRotor)" />
        */
        public static SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle>
            Is<TRotor, TRotorPair, TSingle>(
                this IRotor<TRotor, TRotorPair, TSingle> rotor)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => SideEffectRecordingRotorWrapper<TRotor, TRotorPair, TSingle>.New((TRotor) rotor);
    }
}