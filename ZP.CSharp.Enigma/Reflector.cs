using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The reflector.</summary>
    */
    public class Reflector : IReflector<Reflector, ReflectorPair, char>
    {
        private ReflectorPair[] _Pairs = Array.Empty<ReflectorPair>();
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required ReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(ReflectorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(params ReflectorPair[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(TReflectorPair[])" />
        */
        public static Reflector New(params ReflectorPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="New(string[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(params string[] maps)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(ReflectorPairHelpers.GetPairsFrom<ReflectorPair, char>(maps.Select(s => s.ToCharArray()).ToArray()));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static Reflector New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="New(string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(string map)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(map);
            this.Setup(ReflectorPairHelpers.GetPairsFrom<ReflectorPair, char>(map.ToCharArray()));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static Reflector New(string map) => new(map);
    }
}