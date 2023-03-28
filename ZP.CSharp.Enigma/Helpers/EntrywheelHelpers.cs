using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the entrywheel.</summary>
    */
    public static class EntrywheelHelpers
    {
        /**
        <summary>Sets up the entrywheel.</summary>
        <param name="entrywheel">The entrywheel to set up.</param>
        <param name="pairs">The entrywheel pairs.</param>
        */
        public static TEntrywheel Setup<TEntrywheel, TEntrywheelPair, TSingle>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> entrywheel,
            IEnumerable<TEntrywheelPair> pairs)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            entrywheel.Pairs = pairs.ToArray();
            if (!entrywheel.IsValid())
            {
                throw new ArgumentException("Entrywheel pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            return (TEntrywheel) entrywheel;
        }
        /**
        <summary>Modifies the entrywheel to be with the provided entrywheel pairs.</summary>
        <param name="entrywheel">The entrywheel to modify.</param>
        <param name="pairs">The entrywheel pairs.</param>
        */
        public static TEntrywheel WithPairs<TEntrywheel, TEntrywheelPair, TSingle>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> entrywheel,
            IEnumerable<TEntrywheelPair> pairs)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var newEntrywheel = TEntrywheel.New(pairs);
            if (!newEntrywheel.IsValid())
            {
                throw new ArgumentException("Entrywheel pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            return newEntrywheel;
        }
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.IsValid()" />
        */
        public static bool IsValid<TEntrywheel, TEntrywheelPair, TSingle>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> e)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.IsValid();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.FromPlugboard(TSingle)" />
        */
        public static TSingle FromPlugboard<TEntrywheel, TEntrywheelPair, TSingle>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> e,
            TSingle c)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.FromPlugboard(c);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.FromReflector(TSingle)" />
        */
        public static TSingle FromReflector<TEntrywheel, TEntrywheelPair, TSingle>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> e,
            TSingle c)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.FromReflector(c);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Domain()" />
        */
        public static IEnumerable<TSingle> Domain<TEntrywheel, TEntrywheelPair, TSingle>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> e)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => e.Domain();
        /*
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Domain()" />
        */
        /*public static string Domain<TRotor, TRotorPair>(
            this IFixedDomainRotor<TRotor, TRotorPair> r)
            where TRotor : IFixedDomainRotor<TRotor, TRotorPair>, IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => TRotor.FixedDomain();*/
    }
}