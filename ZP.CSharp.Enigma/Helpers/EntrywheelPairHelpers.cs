using System;
using System.Collections.Generic;
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
        public static IEnumerable<TEntrywheelPair> GetPairsFrom<TEntrywheelPair, TSingle>(
            IEnumerable<IEnumerable<TSingle>> maps)
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            return maps.Select(map => TEntrywheelPair.New(map.First(), map.Last()));
        }
        /**
        <summary>Gets pairs from two mappings.</summary>
        <param name="p">The plugboard-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static IEnumerable<TEntrywheelPair> GetPairsFrom<TEntrywheelPair, TSingle>(
            IEnumerable<TSingle> p,
            IEnumerable<TSingle> r)
            where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (p.Count() != r.Count())
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            return p
                .Zip(r, (p, r) => (P: p, R: r))
                .Select(data => TEntrywheelPair.New(data.P, data.R));
        }
    }
}