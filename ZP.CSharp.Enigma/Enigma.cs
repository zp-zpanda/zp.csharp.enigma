using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The enigma.</summary>
    */
    public class Enigma : IEnigma<Enigma, Rotor, Reflector>
    {
        private Rotor[] _Rotors = new Rotor[0];
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TReflector}.Rotors" />
        */
        public required Rotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TReflector}.Reflector" />
        */
        public required Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        [SetsRequiredMembers]
        protected Enigma(Reflector reflector, params Rotor[] rotors)
        {
            this.Rotors = rotors;
            this.Reflector = reflector;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TReflector}.FromRotorAndReflector(TReflector, TRotor[])" />
        */
        public static Enigma FromRotorAndReflector(Reflector reflector, params Rotor[] rotors) => new Enigma(reflector, rotors);
        /**
        <inheritdoc cref="IEnigma.RunOn(char)" />
        */
        public virtual char RunOn(char c)
        {
            this.Step();
            var input = c;
            this.Rotors.ToList().ForEach(rotor => input = rotor.FromEntryWheel(input));
            input = this.Reflector.Reflect(input);
            this.Rotors.Reverse().ToList().ForEach(rotor => input = rotor.FromReflector(input));
            return input;
        }
        /**
        <inheritdoc cref="IEnigma.RunOn(string)" />
        */
        public string RunOn(string s) => new(s.Select(c => this.RunOn(c)).ToArray());
        /**
        <inheritdoc cref="IEnigma.Step()" />
        */
        public virtual void Step() {}
    }
}