using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the rotor pair.</summary>
    */
    public static class RotorPairHelpers
    {
        /**
        <summary>Gets pairs from multiple string maps.</summary>
        <param name="maps">The maps.</param>
        */
        public static IEnumerable<TRotorPair> GetPairsFrom<TRotorPair, TSingle>(
            IEnumerable<IEnumerable<TSingle>> maps)
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            return maps.Select(map => TRotorPair.New(map.First(), map.Last()));
        }
        /**
        <summary>Gets pairs from two mappings.</summary>
        <param name="e">The entrywheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static IEnumerable<TRotorPair> GetPairsFrom<TRotorPair, TSingle>(
            IEnumerable<TSingle> e,
            IEnumerable<TSingle> r)
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            if (e.Count() != r.Count())
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            return e
                .Zip(r, (e, r) => (E: e, R: r))
                .Select(data => TRotorPair.New(data.E, data.R));
        }
    }
}