using System;
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
        <inheritdoc cref="New(ReflectorPair{TSingle}[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public Reflector()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="New(ReflectorPair{TSingle}[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(params ReflectorPair<TSingle>[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(TReflectorPair[])" />
        */
        public static Reflector<TSingle> New(params ReflectorPair<TSingle>[] pairs) => new(pairs);
        /**
        <inheritdoc cref="New(TSingle[][])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(params TSingle[][] maps)
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
        public static Reflector<TSingle> New(params TSingle[][] maps) => new(maps);
        /**
        <inheritdoc cref="New(TSingle[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Reflector(TSingle[] map)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(map);
            this.Setup(ReflectorPairHelpers.GetPairsFrom<ReflectorPair<TSingle>, TSingle>(map));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static Reflector<TSingle> New(TSingle[] map) => new(map);
    }
}