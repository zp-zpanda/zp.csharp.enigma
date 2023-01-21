using System.Collections.Generic;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the string-char enigma.</summary>
    */
    public static class StringCharEnigmaHelpers
    {
        /**
        <summary>Sets up the enigma.</summary>
        <param name="enigma">The enigma to set up.</param>
        <param name="entrywheel">The entrywheel.</param>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static TEnigma Setup<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> enigma,
            TEntrywheel entrywheel,
            TReflector reflector,
            params TRotor[] rotors)
            where TEnigma : IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
        {
            (enigma as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>).Entrywheel = entrywheel;
            (enigma as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>).Rotors = rotors;
            (enigma as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>).Reflector = reflector;
            return (TEnigma) enigma;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TSingle)" />
        */
        public static char RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            char c)
            where TEnigma : IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
            => (e as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>).RunOn(c);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TMessage)" />
        */
        public static string RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            string s)
            where TEnigma : IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
            => e.RunOn(s);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TMessage)" />
        */
        public static IEnumerable<char> RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            IEnumerable<char> m)
            where TEnigma : IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
            => e.RunOn(m);
    }
}