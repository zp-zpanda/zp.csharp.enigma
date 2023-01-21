using System.Collections.Generic;
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
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static TEnigma Setup<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle> enigma,
            TEntrywheel entrywheel,
            TReflector reflector,
            params TRotor[] rotors)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TMessage : IEnumerable<TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            enigma.Entrywheel = entrywheel;
            enigma.Rotors = rotors;
            enigma.Reflector = reflector;
            return (TEnigma) enigma;
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TSingle)" />
        */
        public static TSingle RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle> e,
            TSingle c)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TMessage : IEnumerable<TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.RunOn(c);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TMessage)" />
        */
        public static TMessage RunOn<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>(
            this IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle> e,
            TMessage m)
            where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TMessage : IEnumerable<TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.RunOn(m);
    }
}