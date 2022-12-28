using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
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
        <inheritdoc cref="Reflector.New(ReflectorPair[])" />
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
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(TReflectorPair[])" />
        */
        public static Reflector New(params ReflectorPair[] pairs) => new Reflector(pairs);
        /**
        <inheritdoc cref="Reflector.New(string[])" />
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
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static Reflector New(params string[] maps) => new Reflector(maps);
        /**
        <inheritdoc cref="Reflector.New(string)" />
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
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static Reflector New(string map) => new Reflector(map);
    }
}