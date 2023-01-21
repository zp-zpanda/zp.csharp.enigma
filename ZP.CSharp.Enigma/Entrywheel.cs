using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The entrywheel.</summary>
    */
    public class Entrywheel<TSingle> : IEntrywheel<Entrywheel<TSingle>, EntrywheelPair<TSingle>, TSingle>
        where TSingle :IEqualityOperators<TSingle, TSingle, bool>
    {
        private EntrywheelPair<TSingle>[] _Pairs = Array.Empty<EntrywheelPair<TSingle>>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Pairs" />
        */
        public required EntrywheelPair<TSingle>[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(EntrywheelPair{TSingle}[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Entrywheel(params EntrywheelPair<TSingle>[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <summary>Creates a entrywheel with the entrywheel pairs provided.</summary>
        <param name="pairs">The entrywheel pairs.</param>
        */
        public static Entrywheel<TSingle> New(params EntrywheelPair<TSingle>[] pairs) => new(pairs);
        /**
        <inheritdoc cref="New(TSingle[][])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Entrywheel(params TSingle[][] maps) 
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentNullException.ThrowIfNull(map));
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<EntrywheelPair<TSingle>, TSingle>(maps));
        }
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from two-character-long mappings.</summary>
        <param name="maps">The entrywheel pair mappings.</param>
        */
        public static Entrywheel<TSingle> New(params TSingle[][] maps) => new(maps);
        /**
        <inheritdoc cref="New(TSingle[], TSingle[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Entrywheel(TSingle[] p, TSingle[] r)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(p);
            ArgumentNullException.ThrowIfNull(r);
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<EntrywheelPair<TSingle>, TSingle>(p, r));
        }
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from a entrywheel-side and a reflector-side mapping.</summary>
        <param name="p">The plugboard-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static Entrywheel<TSingle> New(TSingle[] p, TSingle[] r) => new(p, r);
    }
}