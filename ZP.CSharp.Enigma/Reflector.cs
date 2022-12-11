using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The reflector.</summary>
    */
    public class Reflector : IReflector<Reflector, ReflectorPair>
    {
        private ReflectorPair[] _Pairs = new ReflectorPair[0];
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required ReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="Reflector.WithReflectorPairs(ReflectorPair[])" />
        */
        [SetsRequiredMembers]
        protected Reflector(params ReflectorPair[] pairs)
        {
            this.Pairs = pairs;
            if (!this.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.WithReflectorPairs(TReflectorPair[])" />
        */
        public static Reflector WithReflectorPairs(params ReflectorPair[] pairs) => new Reflector(pairs);
        /**
        <inheritdoc cref="Reflector.WithMaps(string[])" />
        */
        [SetsRequiredMembers]
        protected Reflector(params string[] maps)
        {
            if (!maps.All(map => map.Length == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{One}{Two}\"");
            }
            var pairs = new List<ReflectorPair>();
            maps.ToList().ForEach(map => pairs.Add(ReflectorPair.WithMap(map)));
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.WithMaps(string[])" />
        */
        public static Reflector WithMaps(params string[] maps) => new Reflector(maps);
        /**
        <inheritdoc cref="Reflector.WithMap(string)" />
        */
        [SetsRequiredMembers]
        protected Reflector(string map)
        {
            if (map.Length % 2 != 0)
            {
                throw new ArgumentException("Mapping has unpaired characters. Expected mapping: \"{Pair1.One}{Pair1.Two}{Pair2.One}{Pair2.Two}...\"");
            }
            var pairs = new List<ReflectorPair>();
            for (int i = 0; i < (map.Length / 2); i++)
            {
                pairs.Add(ReflectorPair.WithTwoCharacters(map[i * 2], map[i * 2 + 1]));
            }
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Reflector pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.WithMap(string)" />
        */
        public static Reflector WithMap(string map) => new Reflector(map);
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
        /**
        <summary>Reflects a character.</summary>
        <param name="c">The character to reflect.</param>
        <returns>The reflected character.</returns>
        */
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