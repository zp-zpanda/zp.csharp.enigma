using System;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the reflector pair.</summary>
    */
    public static class ReflectorPairHelpers
    {
        /**
        <summary>Gets pairs from multiple two-character-long maps.</summary>
        <param name="maps">The maps.</param>
        */
        public static TReflectorPair[] GetPairsFrom<TReflectorPair, TSingle>(
            params TSingle[][] maps)
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (!maps.All(map => map.Length == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{One}{Two}\"");
            }
            return maps.Select(map => TReflectorPair.New(map.First(), map.Last())).ToArray();
        }
        /**
        <summary>Gets a pair from a two-character-long mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static TReflectorPair GetPairFrom<TReflectorPair, TSingle>(
            TSingle[] map)
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{One}{Two}\"");
            }
            if (map.First() == map.Last())
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            return GetPairsFrom<TReflectorPair, TSingle>(map.OrderBy(c => c).ToArray()).Single();
        }
        /**
        <summary>Gets pairs from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static TReflectorPair[] GetPairsFrom<TReflectorPair, TSingle>(
            TSingle[] map)
            where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
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