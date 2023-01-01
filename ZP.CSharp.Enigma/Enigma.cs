using System;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The enigma.</summary>
    */
    public class Enigma : IEnigma<Enigma, Rotor, RotorPair, Reflector, ReflectorPair>
    {
        private Rotor[] _Rotors = Array.Empty<Rotor>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Rotors" />
        */
        public required Rotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Reflector" />
        */
        public required Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <inheritdoc cref="Enigma.New(Reflector, Rotor[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Enigma(Reflector reflector, params Rotor[] rotors)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(reflector);
            ArgumentNullException.ThrowIfNull(rotors);
            this.Setup(reflector, rotors);
        }
        /**
        <summary>Creates a rotor with the rotors and the reflector provided.</summary>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static Enigma New(Reflector reflector, params Rotor[] rotors) => new(reflector, rotors);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Step()" />
        */
        public void Step() {}
    }
}