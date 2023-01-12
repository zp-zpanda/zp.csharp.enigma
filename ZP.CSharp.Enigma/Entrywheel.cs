using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The entrywheel.</summary>
    */
    public class Entrywheel : IEntrywheel<Entrywheel, EntrywheelPair>
    {
        private EntrywheelPair[] _Pairs = Array.Empty<EntrywheelPair>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.Pairs" />
        */
        public required EntrywheelPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="Entrywheel.New(EntrywheelPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Entrywheel(params EntrywheelPair[] pairs)
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
        public static Entrywheel New(params EntrywheelPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="Entrywheel.New(string[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Entrywheel(params string[] maps) 
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<EntrywheelPair>(maps));
        }
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from two-character-long mappings.</summary>
        <param name="maps">The entrywheel pair mappings.</param>
        */
        public static Entrywheel New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="Entrywheel.New(string, string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Entrywheel(string p, string r)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(p);
            ArgumentException.ThrowIfNullOrEmpty(r);
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<EntrywheelPair>(p, r));
        }
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from a entrywheel-side and a reflector-side mapping.</summary>
        <param name="p">The plugboard-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static Entrywheel New(string p, string r) => new(p, r);
    }
}