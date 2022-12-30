using System;
using System.Linq;
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
        <summary>Gets pairs from multiple string maps.</summary>
        <param name="reflector">The reflector to get pairs for.</param>
        <param name="maps">The maps.</param>
        */
        public static TReflectorPair[] GetPairsFrom<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> reflector,
            params string[] maps)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
        {
            if (!maps.All(map => map.Length == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{One}{Two}\"");
            }
            return maps.Select(map => TReflectorPair.WithMap(map)).ToArray();
        }
        /**
        <summary>Gets pairs from a mapping.</summary>
        <param name="reflector">The reflector to get pairs for.</param>
        <param name="map">The mapping.</param>
        */
        public static TReflectorPair[] GetPairsFrom<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> reflector,
            string map)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
        {
            if (map.Length % 2 != 0)
            {
                throw new ArgumentException("Mapping has unpaired characters. Expected mapping: \"{Pair1.One}{Pair1.Two}{Pair2.One}{Pair2.Two}...\"");
            }
            return Enumerable.Range(0, map.Length / 2)
                .Select(i => new string(map.Take((i * 2)..((i + 1) * 2)).ToArray()))
                .Select(map => TReflectorPair.WithTwoCharacters(map.First(), map.Last()))
                .ToArray();
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