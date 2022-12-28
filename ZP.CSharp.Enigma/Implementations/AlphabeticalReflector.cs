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
    public class AlphabeticalReflector : IReflector<AlphabeticalReflector, ReflectorPair>
    {
        private ReflectorPair[] _Pairs = new ReflectorPair[0];
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required ReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="AlphabeticalReflector.New(ReflectorPair[])" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalReflector(params ReflectorPair[] pairs)
            => this.Setup(pairs);
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(TReflectorPair[])" />
        */
        public static AlphabeticalReflector New(params ReflectorPair[] pairs) => new AlphabeticalReflector(pairs);
        /**
        <inheritdoc cref="Reflector.New(string[])" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalReflector(params string[] maps)
            => this.Setup(this.GetPairsFrom(maps));
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(string[])" />
        */
        public static AlphabeticalReflector New(params string[] maps) => new AlphabeticalReflector(maps);
        /**
        <inheritdoc cref="AlphabeticalReflector.New(string)" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalReflector(string map)
            => this.Setup(this.GetPairsFrom(map));
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(string)" />
        */
        public static AlphabeticalReflector New(string map) => new AlphabeticalReflector(map);
    }
}