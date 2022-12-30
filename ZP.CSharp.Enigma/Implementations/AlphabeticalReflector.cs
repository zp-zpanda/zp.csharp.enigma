using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma.Implementations;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The reflector.</summary>
    */
    public class AlphabeticalReflector : IReflector<AlphabeticalReflector, AlphabeticalReflectorPair>
    {
        private AlphabeticalReflectorPair[] _Pairs = Array.Empty<AlphabeticalReflectorPair>();
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required AlphabeticalReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="AlphabeticalReflector.New(AlphabeticalReflectorPair[])" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalReflector(params AlphabeticalReflectorPair[] pairs)
            => this.Setup(pairs);
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(TReflectorPair[])" />
        */
        public static AlphabeticalReflector New(params AlphabeticalReflectorPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="Reflector.New(string[])" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalReflector(params string[] maps)
            => this.Setup(this.GetPairsFrom(maps));
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static AlphabeticalReflector New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="AlphabeticalReflector.New(string)" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalReflector(string map)
            => this.Setup(this.GetPairsFrom(map));
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static AlphabeticalReflector New(string map) => new(map);
    }
}