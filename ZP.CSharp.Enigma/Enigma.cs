using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The enigma.</summary>
    */
    public class Enigma<TMessage, TSingle> : IEnigma<Enigma<TMessage, TSingle>, Entrywheel<TSingle>, EntrywheelPair<TSingle>, Rotor<TSingle>, RotorPair<TSingle>, Reflector<TSingle>, ReflectorPair<TSingle>, TMessage, TSingle>
        where TMessage : IEnumerable<TSingle>
        where TSingle :IEqualityOperators<TSingle, TSingle, bool>
    {
        private Entrywheel<TSingle> _Entrywheel;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Entrywheel" />
        */
        public required Entrywheel<TSingle> Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        private Rotor<TSingle>[] _Rotors = Array.Empty<Rotor<TSingle>>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Rotors" />
        */
        public required Rotor<TSingle>[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector<TSingle> _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Reflector" />
        */
        public required Reflector<TSingle> Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <inheritdoc cref="New(Entrywheel{TSingle}, Reflector{TSingle}, Rotor{TSingle}[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public Enigma()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.New(TEntrywheel, TReflector, TRotor[])" />
        */
        public static Enigma<TMessage, TSingle> New(Entrywheel<TSingle> entrywheel, Reflector<TSingle> reflector, params Rotor<TSingle>[] rotors)
        {
            ArgumentNullException.ThrowIfNull(reflector);
            ArgumentNullException.ThrowIfNull(rotors);
            return new Enigma<TMessage, TSingle>().Setup(entrywheel, reflector, rotors);
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Step()" />
        */
        public void Step() {}
    }
}