using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the enigma.</summary>
    */
    public interface IEnigma
    {
        /**
        <summary>Runs the enigma on a character.</summary>
        <param name="c">The character to run on.</param>
        <returns>The encoded/decoded character.</returns>
        */
        public char RunOn(char c);
        /**
        <summary>Runs the enigma on a string.</summary>
        <param name="s">The string to run on.</param>
        <returns>The encoded/decoded string.</returns>
        */
        public string RunOn(string s);
        /**
        <summary>Steps the enigma.</summary>
        */
        public void Step();
    }
    /**
    <summary>The generic interface for the enigma.</summary>
    */
    public interface IEnigma<TEnigma, TRotor, TReflector> : IEnigma
        where TEnigma : IEnigma<TEnigma, TRotor, TReflector>, IEnigma
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
    }
}