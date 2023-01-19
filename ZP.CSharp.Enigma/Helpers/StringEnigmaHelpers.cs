using System.Collections.Generic;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the string enigma.</summary>
    */
    public static class StringEnigmaHelpers
    {
        /**
        <summary>Sets up the enigma.</summary>
        <param name="enigma">The enigma to set up.</param>
        <param name="entrywheel">The entrywheel.</param>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static TEnigma Setup<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> enigma,
            TEntrywheel entrywheel,
            TReflector reflector,
            params TRotor[] rotors)
            where TEnigma : IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
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
        public static char RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            char c)
            where TEnigma : IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
            => (e as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>).RunOn(c);
        public static string RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            string s)
            where TEnigma : IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
            => e.RunOn(s);
            public static IEnumerable<char> RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>(
            this IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> e,
            IEnumerable<char> m)
            where TEnigma : IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
            where TRotor : IRotor<TRotor, TRotorPair, char>
            where TRotorPair : IRotorPair<TRotorPair, char>
            where TReflector : IReflector<TReflector, TReflectorPair, char>
            where TReflectorPair : IReflectorPair<TReflectorPair, char>
            => e.RunOn(m);
    }
}