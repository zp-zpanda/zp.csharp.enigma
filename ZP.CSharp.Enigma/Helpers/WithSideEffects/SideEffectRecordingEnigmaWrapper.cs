using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers.WithSideEffects
{
    /**
    <summary>Side-effect-recording wrapper class for the enigma.</summary>
    */
    public class SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
        : IEnigma<SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
        where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>, new()
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
        where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
        where TMessage : IEnumerable<TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private TEnigma _Enigma;
        /**
        <summary>The wrapped enigma.</summary>
        */
        public required TEnigma Enigma {get => this._Enigma; set => this._Enigma = value;}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Entrywheel" />
        */
        public required TEntrywheel Entrywheel {get => this.Enigma.Entrywheel; set => this.Enigma.Entrywheel = value;}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Rotors" />
        */
        public required TRotor[] Rotors {get => this.Enigma.Rotors; set => this.Enigma.Rotors = value;}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Reflector" />
        */
        public required TReflector Reflector {get => this.Enigma.Reflector; set => this.Enigma.Reflector = value;}
        /**
        <inheritdoc cref="New(TEntrywheel, TReflector, TRotor[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public SideEffectRecordingEnigmaWrapper()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.New(TEntrywheel, TReflector, TRotor[])" />
        */
        public static SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle> New(TEntrywheel entrywheel, TReflector reflector, params TRotor[] rotors)
            => throw new NotSupportedException("This enigma is for encapsulation purposes only.");
        /**
        <summary>Wraps the enigma for side-effect-recording.</summary>
        */
        public static SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle> New(TEnigma enigma)
            => new(){
                Enigma = enigma
            };
        /**
        <summary>Modifies the enigma to be with the provided entrywheel, rotors, and reflector.</summary>
        */
        public SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            With(TEntrywheel entrywheel, TReflector reflector, params TRotor[] rotors)
            => this.WithEntrywheel(entrywheel).WithRotors(rotors).WithReflector(reflector);
        /**
        <summary>Modifies the enigma to be with the provided entrywheel.</summary>
        */
        public SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            WithEntrywheel(TEntrywheel entrywheel)
        {
            this.Enigma.Entrywheel = entrywheel;
            return this;
        }
        /**
        <summary>Modifies the enigma to be with the provided rotors.</summary>
        */
        public SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            WithRotors(params TRotor[] rotors)
        {
            this.Enigma.Rotors = rotors;
            return this;
        }
        /**
        <summary>Modifies the enigma to be with the provided reflector.</summary>
        */
        public SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            WithReflector(TReflector reflector)
        {
            this.Enigma.Reflector = reflector;
            return this;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Step()" />
        */
        public void Step() => this.Enigma.Step();
    }
    /**
    <summary>Helpers for the side-effect-recording wrapper class for the enigma.</summary>
    */
    public static class SideEffectRecordingEnigmaWrapperHelpers
    {
        /**
        <inheritdoc cref="SideEffectRecordingEnigmaWrapper{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.New(TEnigma)" />
        */
        public static SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            Is<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>(
                this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle> enigma)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>, new()
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TMessage : IEnumerable<TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => SideEffectRecordingEnigmaWrapper<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>.New((TEnigma) enigma);

    }
}