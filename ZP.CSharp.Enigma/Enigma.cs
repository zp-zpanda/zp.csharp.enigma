using System;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The enigma.</summary>
    */
    public class Enigma : IEnigma<Enigma, Entrywheel, EntrywheelPair, Rotor, RotorPair, Reflector, ReflectorPair>
    {
        private Entrywheel _Entrywheel;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Entrywheel" />
        */
        public required Entrywheel Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        private Rotor[] _Rotors = Array.Empty<Rotor>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Rotors" />
        */
        public required Rotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Reflector" />
        */
        public required Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <inheritdoc cref="Enigma.New(Reflector, Rotor[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Enigma(Entrywheel entrywheel, Reflector reflector, params Rotor[] rotors)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(reflector);
            ArgumentNullException.ThrowIfNull(rotors);
            this.Setup(entrywheel, reflector, rotors);
        }
        /**
        <summary>Creates a rotor with the rotors and the reflector provided.</summary>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static Enigma New(Entrywheel entrywheel, Reflector reflector, params Rotor[] rotors) => new(entrywheel, reflector, rotors);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Step()" />
        */
        public void Step() {}
    }
}