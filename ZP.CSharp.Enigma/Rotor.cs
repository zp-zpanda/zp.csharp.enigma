using System;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor.</summary>
    */
    public class Rotor
    {
        /**
        <summary>The rotor pairs this rotor has.</summary>
        */
        public RotorPair[] Pairs;
        /**
        <summary>Creates a rotor with zero rotor pairs.</summary>
        */
        public Rotor()
        {
            this.Pairs = new RotorPair[0];
        }
        /**
        <summary>Creates a rotor with the rotor pairs provided.</summary>
        <param name="pairs">The rotor pairs.</param>
        */
        public Rotor(params RotorPair[] pairs)
        {
            this.Pairs = pairs;
            if (!this.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="maps">The rotor pair mappings.</param>
        */
        public Rotor(params string[] maps)
        {
            if (!maps.All(map => map.Length == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            maps.ToList().ForEach(map => pairs.Add(new RotorPair(map)));
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Creates a rotor with rotor pairs created from a Entrywheel-side and a reflector-side mapping.</summary>
        <param name="e">The Entrywheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public Rotor(string e, string r)
        {
            if (e.Length != r.Length)
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            for (int i = 0; i < e.Length; i++)
            {
                pairs.Add(new RotorPair(e[i], r[i]));
            }
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Checks if the rotor is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c><see langword="true" /></c> if valid, else <c><see langword="false" /></c>.</returns>
        */
        public virtual bool IsValid()
        {
            var e = !this.Pairs.Select(pair => pair.EntryWheelSide).GroupBy(e => e).Select(group => group.Count()).Any(count => count > 1);
            var r = !this.Pairs.Select(pair => pair.ReflectorSide).GroupBy(r => r).Select(group => group.Count()).Any(count => count > 1);
            return (e && r);
        }
    }
}