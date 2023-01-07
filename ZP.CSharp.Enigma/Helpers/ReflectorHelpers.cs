using System;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
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
        public static void Setup<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> reflector,
            TReflectorPair[] pairs)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
        {
            reflector.Pairs = pairs;
            if (!reflector.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.IsValid()" />
        */
        public static bool IsValid<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> r)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => r.IsValid();
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.Reflect(char)" />
        */
        public static char Reflect<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> r,
            char c)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => r.Reflect(c);
    }
}