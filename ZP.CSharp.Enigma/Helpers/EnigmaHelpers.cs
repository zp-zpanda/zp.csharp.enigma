using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        <param name="entrywheel">The entrywheel.</param>
        <param name="rotors">The rotors.</param>
        <param name="reflector">The reflector.</param>
        */
        public static TEnigma Setup<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle> enigma,
            TEntrywheel entrywheel,
            IEnumerable<TRotor> rotors,
            TReflector reflector)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>, new()
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            enigma.Entrywheel = entrywheel;
            enigma.Rotors = rotors.ToArray();
            enigma.Reflector = reflector;
            return (TEnigma) enigma;
        }
        /**
        <summary>Modifies the enigma to be with the provided entrywheel, rotors, and reflector.</summary>
        <param name="enigma">The enigma to modify.</param>
        <param name="entrywheel">The entrywheel.</param>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static TEnigma With<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle> enigma,
            TEntrywheel entrywheel,
            TReflector reflector,
            params TRotor[] rotors)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>, new()
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => TEnigma.New(entrywheel, rotors, reflector);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.RunOn(TSingle)" />
        */
        public static TSingle RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle> e,
            TSingle c)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>, new()
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.RunOn(c);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.RunOn(IEnumerable{TSingle})" />
        */
        public static IEnumerable<TSingle> RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle> e,
            IEnumerable<TSingle> m)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>, new()
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.RunOn(m);
    }
}