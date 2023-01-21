using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The string-char entrywheel.</summary>
    */
    public class StringCharEntrywheel : IEntrywheel<StringCharEntrywheel, StringCharEntrywheelPair, char>
    {
        private StringCharEntrywheelPair[] _Pairs = Array.Empty<StringCharEntrywheelPair>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Pairs" />
        */
        public required StringCharEntrywheelPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(StringCharEntrywheelPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected StringCharEntrywheel(params StringCharEntrywheelPair[] pairs)
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
        public static StringCharEntrywheel New(params StringCharEntrywheelPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="New(string[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected StringCharEntrywheel(params string[] maps) 
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<StringCharEntrywheelPair, char>(maps.Select(s => s.ToCharArray()).ToArray()));
        }
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from two-character-long mappings.</summary>
        <param name="maps">The entrywheel pair mappings.</param>
        */
        public static StringCharEntrywheel New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="New(string, string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected StringCharEntrywheel(string p, string r)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(p);
            ArgumentException.ThrowIfNullOrEmpty(r);
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<StringCharEntrywheelPair, char>(p.ToCharArray(), r.ToCharArray()));
        }
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from a entrywheel-side and a reflector-side mapping.</summary>
        <param name="p">The plugboard-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static StringCharEntrywheel New(string p, string r) => new(p, r);
    }
}