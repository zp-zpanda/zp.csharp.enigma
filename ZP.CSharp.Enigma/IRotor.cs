using System;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the rotor.</summary>
    */
    public interface IRotor
    {
        /**
        <summary>The domain of this rotor.</summary>
        */
        public string Domain {get; set;}
        /**
        <summary>The position of this rotor.</summary>
        */
        public int Position {get; set;}
        /**
        <summary>The turning notches of this rotor.</summary>
        */
        public int[] Notch {get; set;}
        /**
        <summary>Checks if the rotor is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c><see langword="true" /></c> if valid, else <c><see langword="false" /></c>.</returns>
        */
        public bool IsValid();
        /**
        <summary>Matches a character from the entry wheel.</summary>
        <param name="c">The character to map.</param>
        <returns>The mapped character.</returns>
        <exception cref="CharacterNotFoundException"><paramref name="c" /> cannot be mapped.</exception>
        */
        public char FromEntryWheel(char c);
        /**
        <summary>Matches a character from the reflector.</summary>
        <param name="c">The character to map.</param>
        <returns>The mapped character.</returns>
        <exception cref="CharacterNotFoundException"><paramref name="c" /> cannot be mapped.</exception>
        */
        public char FromReflector(char c);
        /**
        <summary>Computes the domain of this rotor.</summary>
        <returns>The domain.</returns>
        */
        public string ComputeDomain();
        /**
        <summary>Transposes a character coming to the rotor.</summary>
        <param name="c">The character to transpose.</param>
        <returns>The transposed character.</returns>
        */
        public char TransposeIn(char c);
        /**
        <summary>Transposes a character going away from the rotor.</summary>
        <param name="c">The character to transpose.</param>
        <returns>The transposed character.</returns>
        */
        public char TransposeOut(char c);
        /**
        <summary>Returns whether this rotor allows the next to step or not.</summary>
        */
        public bool AllowNextToStep();
        /**
        <summary>Steps the rotor.</summary>
        */
        public void Step();
    }
    /**
    <summary>The generic interface for the rotor.</summary>
    */
    public interface IRotor<TRotor, TRotorPair> : IRotor
        where TRotor : IRotor<TRotor, TRotorPair>, IRotor
        where TRotorPair : IRotorPair<TRotorPair>
    {
        /**
        <summary>The rotor pairs this rotor has.</summary>
        */
        public TRotorPair[] Pairs {get; set;}
        /**
        <summary>Creates a rotor with the rotor pairs provided.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="pairs">The rotor pairs.</param>
        */
        public static abstract TRotor WithPositionNotchAndRotorPairs(int pos, int[] notch, params TRotorPair[] pairs);
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public static abstract TRotor WithPositionNotchAndMaps(int pos, int[] notch, params string[] maps);
        /**
        <summary>Creates a rotor with rotor pairs created from a entry wheel-side and a reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static abstract TRotor WithPositionNotchAndTwoMaps(int pos, int[] notch, string e, string r);

    }
}