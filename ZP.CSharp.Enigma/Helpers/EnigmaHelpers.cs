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
        public static TEnigma Setup<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> enigma,
            TEntrywheel entrywheel,
            TReflector reflector,
            params TRotor[] rotors)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
        {
            enigma.Entrywheel = entrywheel;
            enigma.Rotors = rotors;
            enigma.Reflector = reflector;
            return (TEnigma) enigma;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.RunOn(char)" />
        */
        public static char RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            char c)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => e.RunOn(c);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.RunOn(string)" />
        */
        public static string RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            string s)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => e.RunOn(s);
    }
}