using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<TReflectorPair> pairs)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            reflector.Pairs = pairs.ToArray();
            if (!reflector.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Modifies the reflector to be with the provided reflector pairs.</summary>
        <param name="reflector">The reflector to modify.</param>
        <param name="pairs">The reflector pairs.</param>
        */
        public static TReflector WithPairs<TReflector, TReflectorPair, TSingle>(
            this IReflector<TReflector, TReflectorPair, TSingle> reflector,
            params TReflectorPair[] pairs)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var newReflector = TReflector.New(pairs);
            if (!newReflector.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            return newReflector;
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.IsValid()" />
        */
        public static bool IsValid<TReflector, TReflectorPair, TSingle>(
            this IReflector<TReflector, TReflectorPair, TSingle> r)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.IsValid();
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.Reflect(TSingle)" />
        */
        public static TSingle Reflect<TReflector, TReflectorPair, TSingle>(
            this IReflector<TReflector, TReflectorPair, TSingle> r,
            TSingle c)
            where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.Reflect(c);
    }
}