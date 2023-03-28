using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The reflector.</summary>
    */
    public class Reflector<TSingle> : IReflector<Reflector<TSingle>, ReflectorPair<TSingle>, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private ReflectorPair<TSingle>[] _Pairs = Array.Empty<ReflectorPair<TSingle>>();
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required ReflectorPair<TSingle>[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(IEnumerable{ReflectorPair{TSingle}})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public Reflector()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="New(IEnumerable{ReflectorPair{TSingle}})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(IEnumerable<ReflectorPair<TSingle>> pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(IEnumerable{TReflectorPair})" />
        */
        public static Reflector<TSingle> New(IEnumerable<ReflectorPair<TSingle>> pairs) => new(pairs);
        /**
        <inheritdoc cref="New(IEnumerable{IEnumerable{TSingle}})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(IEnumerable<IEnumerable<TSingle>> maps)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentNullException.ThrowIfNull(map));
            this.Setup(ReflectorPairHelpers.GetPairsFrom<ReflectorPair<TSingle>, TSingle>(maps));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static Reflector<TSingle> New(IEnumerable<IEnumerable<TSingle>> maps) => new(maps);
        /**
        <inheritdoc cref="New(IEnumerable{TSingle})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(IEnumerable<TSingle> map)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(map);
            this.Setup(ReflectorPairHelpers.GetPairsFrom<ReflectorPair<TSingle>, TSingle>(map));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static Reflector<TSingle> New(IEnumerable<TSingle> map) => new(map);
    }
}