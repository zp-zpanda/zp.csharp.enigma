using System;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the enigma.</summary>
    */
    public static class EnigmaHelpers
    {
        /**
        <summary>Sets up the enigma.</summary>
        <param name="enigma">The enigma to set up.</param>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static TEnigma Setup<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair> enigma,
            TReflector reflector,
            params TRotor[] rotors)
            where TEnigma : IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
        {
            enigma.Rotors = rotors;
            enigma.Reflector = reflector;
            return (TEnigma) enigma;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.RunOn(char)" />
        */
        public static char RunOn<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            char c)
            where TEnigma : IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => e.RunOn(c);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.RunOn(string)" />
        */
        public static string RunOn<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            string s)
            where TEnigma : IEnigma<TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => e.RunOn(s);
    }
}