using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma;
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
        [SetsRequiredMembers]
        protected Enigma(Reflector reflector, params Rotor[] rotors)
        {
            this.Rotors = rotors;
            this.Reflector = reflector;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.FromRotorAndReflector(TReflector, TRotor[])" />
        */
        public static Enigma FromRotorAndReflector(Reflector reflector, params Rotor[] rotors) => new Enigma(reflector, rotors);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Step()" />
        */
        public virtual void Step() {}
    }
}