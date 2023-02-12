using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The reflector.</summary>
    */
    public class AlphabeticalReflector : IReflector<AlphabeticalReflector, AlphabeticalReflectorPair, char>
    {
        private AlphabeticalReflectorPair[] _Pairs = Array.Empty<AlphabeticalReflectorPair>();
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required AlphabeticalReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(AlphabeticalReflectorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public AlphabeticalReflector()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="New(AlphabeticalReflectorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected AlphabeticalReflector(params AlphabeticalReflectorPair[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(TReflectorPair[])" />
        */
        public static AlphabeticalReflector New(params AlphabeticalReflectorPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="Reflector{TSingle}.New(TSingle[][])"/>
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected AlphabeticalReflector(params string[] maps)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(ReflectorPairHelpers.GetPairsFrom<AlphabeticalReflectorPair, char>(maps.Select(s => s.ToCharArray()).ToArray()));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static AlphabeticalReflector New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="New(string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected AlphabeticalReflector(string map)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(map);
            this.Setup(ReflectorPairHelpers.GetPairsFrom<AlphabeticalReflectorPair, char>(map.ToCharArray()));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static AlphabeticalReflector New(string map) => new(map);
    }
}