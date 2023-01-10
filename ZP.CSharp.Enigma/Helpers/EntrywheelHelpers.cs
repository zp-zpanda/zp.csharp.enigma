using System;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
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
        public static void Setup<TEntrywheel, TEntrywheelPair>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair> entrywheel,
            params TEntrywheelPair[] pairs)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
        {
            entrywheel.Pairs = pairs;
            if (!entrywheel.IsValid())
            {
                throw new ArgumentException("Entrywheel pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.IsValid()" />
        */
        public static bool IsValid<TEntrywheel, TEntrywheelPair>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair> e)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
            => e.IsValid();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.FromPlugboard(char)" />
        */
        public static char FromPlugboard<TEntrywheel, TEntrywheelPair>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair> e,
            char c)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
            => e.FromPlugboard(c);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.FromReflector(char)" />
        */
        public static char FromReflector<TEntrywheel, TEntrywheelPair>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair> e,
            char c)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
            => e.FromReflector(c);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.Domain()" />
        */
        public static string Domain<TEntrywheel, TEntrywheelPair>(
            this IEntrywheel<TEntrywheel, TEntrywheelPair> e)
            where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
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