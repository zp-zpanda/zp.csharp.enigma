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
            => this.Setup(pairs);
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(TReflectorPair[])" />
        */
        public static Reflector New(params ReflectorPair[] pairs) => new Reflector(pairs);
        /**
        <inheritdoc cref="Reflector.New(string[])" />
        */
        [SetsRequiredMembers]
        protected Reflector(params string[] maps)
            => this.Setup(this.GetPairsFrom(maps));
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
            => this.Setup(this.GetPairsFrom(map));
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static Reflector New(string map) => new Reflector(map);
    }
}