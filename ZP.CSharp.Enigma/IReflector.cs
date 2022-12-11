using System;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the reflector.</summary>
    */
    public interface IReflector
    {
        /**
        <summary>Checks if the reflector is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c>true</c> if valid, else <c>false</c>.</returns>
        */
        public bool IsValid();
        /**
        <summary>Reflects a character.</summary>
        <param name="c">The character to reflect.</param>
        <returns>The reflected character.</returns>
        */
        public char Reflect(char c);
    }
    /**
    <summary>The generic interface for the reflector.</summary>
    */
    public interface IReflector<TReflector, TReflectorPair> : IReflector
        where TReflector : IReflector<TReflector, TReflectorPair>, IReflector
        where TReflectorPair : IReflectorPair<TReflectorPair>
    {
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public TReflectorPair[] Pairs {get; set;}
        /**
        <summary>Creates a reflector with the reflector pairs provided.</summary>
        <param name="pairs">The reflector pairs.</param>
        */
        public static abstract TReflector WithReflectorPairs(params TReflectorPair[] pairs);
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static abstract TReflector WithMaps(params string[] maps);
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static abstract TReflector WithMap(string map);
    }
}