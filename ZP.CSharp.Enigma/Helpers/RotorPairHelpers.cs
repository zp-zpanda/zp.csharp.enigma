using System;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
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
        public static TRotorPair[] GetPairsFrom<TRotorPair>(
            params string[] maps)
            where TRotorPair : IRotorPair<TRotorPair>
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            return maps.Select(map => TRotorPair.New(map.First(), map.Last())).ToArray();
        }
        /**
        <summary>Gets pairs from two mappings.</summary>
        <param name="e">The entrywheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static TRotorPair[] GetPairsFrom<TRotorPair>(
            string e,
            string r)
            where TRotorPair : IRotorPair<TRotorPair>
        {
            var length = 0;
            try
            {
                length = new string[]{e, r}.Select(s => s.Length).Distinct().Single();
            }
            catch
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            return Enumerable.Range(0, length).Select(i => TRotorPair.New(e[i], r[i])).ToArray();
        }
    }
}