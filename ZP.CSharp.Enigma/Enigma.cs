using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The enigma.</summary>
    */
    public class Enigma : IEnigma<Enigma, Rotor, RotorPair, Reflector, ReflectorPair>
    {
        private Rotor[] _Rotors = new Rotor[0];
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
        protected Enigma(Reflector reflector, params Rotor[] rotors) => this.Setup(reflector, rotors);
        /**
        <summary>Creates a rotor with the rotors and the reflector provided.</summary>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static Enigma New(Reflector reflector, params Rotor[] rotors) => new Enigma(reflector, rotors);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Step()" />
        */
        public void Step() {}
    }
}