using System;
using System.Linq;
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
            return maps.Select(map => TReflectorPair.New(map.First(), map.Last())).ToArray();
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
            return map
                .Select((c, index) => (Index: Math.DivRem(index, 2, out int _), Char: c))
                .GroupBy(data => data.Index)
                .Select(group => group.Select(data => data.Char))
                .Select(map => TReflectorPair.New(map.First(), map.Last()))
                .ToArray();
        }
    }
}