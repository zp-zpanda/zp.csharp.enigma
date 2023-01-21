using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The string-char reflector.</summary>
    */
    public class StringCharReflector : IReflector<StringCharReflector, StringCharReflectorPair, char>
    {
        private StringCharReflectorPair[] _Pairs = Array.Empty<StringCharReflectorPair>();
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required StringCharReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(StringCharReflectorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected StringCharReflector(params StringCharReflectorPair[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(TReflectorPair[])" />
        */
        public static StringCharReflector New(params StringCharReflectorPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="New(string[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected StringCharReflector(params string[] maps)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(ReflectorPairHelpers.GetPairsFrom<StringCharReflectorPair, char>(maps.Select(s => s.ToCharArray()).ToArray()));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static StringCharReflector New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="New(string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected StringCharReflector(string map)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(map);
            this.Setup(ReflectorPairHelpers.GetPairsFrom<StringCharReflectorPair, char>(map.ToCharArray()));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static StringCharReflector New(string map) => new(map);
    }
}