using System;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the entrywheel pair.</summary>
    */
    public static class EntrywheelPairHelpers
    {
        /**
        <summary>Gets pairs from multiple string maps.</summary>
        <param name="maps">The maps.</param>
        */
        public static TEntrywheelPair[] GetPairsFrom<TEntrywheelPair, TSingle>(
            params TSingle[][] maps)
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            return maps.Select(map => TEntrywheelPair.New(map.First(), map.Last())).ToArray();
        }
        /**
        <summary>Gets pairs from two mappings.</summary>
        <param name="p">The plugboard-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static TEntrywheelPair[] GetPairsFrom<TEntrywheelPair, TSingle>(
            TSingle[] p,
            TSingle[] r)
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (p.Length != r.Length)
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            return p
                .Zip(r, (p, r) => (P: p, R: r))
                .Select(data => TEntrywheelPair.New(data.P, data.R))
                .ToArray();
        }
    }
}