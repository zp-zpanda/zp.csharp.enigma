using System;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the reflector pair.</summary>
    */
    public static class ReflectorPairHelpers
    {
        /**
        <summary>Gets pairs from multiple string maps.</summary>
        <param name="maps">The maps.</param>
        */
        public static TReflectorPair[] GetPairsFrom<TReflectorPair>(
            params string[] maps)
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
        <param name="map">The mapping.</param>
        */
        public static TReflectorPair[] GetPairsFrom<TReflectorPair>(
            string map)
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
    }
}