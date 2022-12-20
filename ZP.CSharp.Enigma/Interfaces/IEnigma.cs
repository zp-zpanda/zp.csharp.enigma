using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the enigma.</summary>
    */
    public interface IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>
        where TEnigma : IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>
        where TRotor : IRotor<TRotor, TRotorPair>
        where TRotorPair : IRotorPair<TRotorPair>
        where TReflector : IReflector<TReflector, TReflectorPair>
        where TReflectorPair : IReflectorPair<TReflectorPair>
    {
        /**
        <summary>The rotors this enigma has.</summary>
        */
        public TRotor[] Rotors {get; set;}
        /**
        <summary>The reflector this enigma has.</summary>
        */
        public TReflector Reflector {get; set;}
        /**
        <summary>Creates a rotor with the rotors and the reflector provided.</summary>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static abstract TEnigma FromRotorAndReflector(TReflector reflector, params TRotor[] rotors);
        /**
        <summary>Runs the enigma on a character.</summary>
        <param name="c">The character to run on.</param>
        <returns>The encoded/decoded character.</returns>
        */
        public char RunOn(char c)
        {
            this.Step();
            var input = c;
            this.Rotors.ToList().ForEach(rotor => input = rotor.FromEntryWheel(input));
            input = this.Reflector.Reflect(input);
            this.Rotors.Reverse().ToList().ForEach(rotor => input = rotor.FromReflector(input));
            return input;
        }
        /**
        <summary>Runs the enigma on a string.</summary>
        <param name="s">The string to run on.</param>
        <returns>The encoded/decoded string.</returns>
        */
        public string RunOn(string s) => new(s.Select(c => this.RunOn(c)).ToArray());
        /**
        <summary>Steps the enigma.</summary>
        */
        public void Step();
    }
}