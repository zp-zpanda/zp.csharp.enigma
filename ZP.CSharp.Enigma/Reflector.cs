using System;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The reflector.</summary>
    */
    public class Reflector
    {
        private ReflectorPair[] _Pairs = new ReflectorPair[0];
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public ReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <summary>Creates a reflector with zero reflector pairs.</summary>
        */
        public Reflector()
        {}
        /**
        <summary>Creates a reflector with the reflector pairs provided.</summary>
        <param name="pairs">The reflector pairs.</param>
        */
        public Reflector(params ReflectorPair[] pairs)
        {
            this.Pairs = pairs;
            if (!this.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public Reflector(params string[] maps)
        {
            if (!maps.All(map => map.Length == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{One}{Two}\"");
            }
            var pairs = new List<ReflectorPair>();
            maps.ToList().ForEach(map => pairs.Add(new ReflectorPair(map)));
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public Reflector(string map)
        {
            if (map.Length % 2 != 0)
            {
                throw new ArgumentException("Mapping has unpaired characters. Expected mapping: \"{Pair1.One}{Pair1.Two}{Pair2.One}{Pair2.Two}...\"");
            }
            var pairs = new List<ReflectorPair>();
            for (int i = 0; i < (map.Length / 2); i++)
            {
                pairs.Add(new ReflectorPair(map[i * 2], map[i * 2 + 1]));
            }
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <summary>Checks if the reflector is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c>true</c> if valid, else <c>false</c>.</returns>
        */
        public bool IsValid()
        {
            var chars = new HashSet<char>();
            var isValid = true;
            this.Pairs.ToList().ForEach(pair => {
                if (!(chars.Add(pair.Map.One) && chars.Add(pair.Map.Two)))
                {
                    isValid = false;
                }});
            return isValid;
        }
        public virtual char Reflect(char c)
        {
            try
            {
                var found = this.Pairs.Where(pair => new[]{pair.Map.One, pair.Map.Two}.Contains(c)).Single();
                return new[]{found.Map.One, found.Map.Two}.Except(new[]{c}).Single();
            }
            catch
            {
                throw new CharacterNotFoundException();
            }
        }
    }
}