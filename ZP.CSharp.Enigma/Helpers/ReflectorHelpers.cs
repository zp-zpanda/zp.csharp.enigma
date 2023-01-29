using System;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the reflector.</summary>
    */
    public static class ReflectorHelpers
    {
        /**
        <summary>Sets up the reflector.</summary>
        <param name="reflector">The reflector to set up.</param>
        <param name="pairs">The reflector pairs.</param>
        */
        public static void Setup<TReflector, TReflectorPair, TSingle>(
            this IReflector<TReflector, TReflectorPair, TSingle> reflector,
            TReflectorPair[] pairs)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            reflector.Pairs = pairs;
            if (!reflector.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.IsValid()" />
        */
        public static bool IsValid<TReflector, TReflectorPair, TSingle>(
            this IReflector<TReflector, TReflectorPair, TSingle> r)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.IsValid();
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.Reflect(TSingle)" />
        */
        public static TSingle Reflect<TReflector, TReflectorPair, TSingle>(
            this IReflector<TReflector, TReflectorPair, TSingle> r,
            TSingle c)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.Reflect(c);
    }
}