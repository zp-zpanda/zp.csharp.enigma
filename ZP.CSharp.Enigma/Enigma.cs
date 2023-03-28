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
    public class Enigma<TSingle> : IEnigma<Enigma<TSingle>, Entrywheel<TSingle>, EntrywheelPair<TSingle>, Rotor<TSingle>, RotorPair<TSingle>, Reflector<TSingle>, ReflectorPair<TSingle>, TSingle>
        where TSingle :IEqualityOperators<TSingle, TSingle, bool>
    {
        private Entrywheel<TSingle> _Entrywheel;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Entrywheel" />
        */
        public required Entrywheel<TSingle> Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        private Rotor<TSingle>[] _Rotors = Array.Empty<Rotor<TSingle>>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Rotors" />
        */
        public required Rotor<TSingle>[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector<TSingle> _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Reflector" />
        */
        public required Reflector<TSingle> Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <inheritdoc cref="New(Entrywheel{TSingle}, IEnumerable{Rotor{TSingle}}, Reflector{TSingle})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public Enigma()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.New(TEntrywheel, IEnumerable{TRotor}, TReflector)" />
        */
        public static Enigma<TSingle> New(Entrywheel<TSingle> entrywheel, IEnumerable<Rotor<TSingle>> rotors, Reflector<TSingle> reflector)
        {
            ArgumentNullException.ThrowIfNull(rotors);
            ArgumentNullException.ThrowIfNull(reflector);
            return new Enigma<TSingle>().Setup(entrywheel, rotors, reflector);
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Step()" />
        */
        public void Step() {}
    }
}