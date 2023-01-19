using System;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The alphabetical entrywheel.</summary>
    */
    public class AlphabeticalEntrywheel : IFixedDomainEntrywheel<AlphabeticalEntrywheel, EntrywheelPair, char>
    {
        /**
        <summary>The ABC entrywheel.</summary>
        */
        public static AlphabeticalEntrywheel Abc
            => New(new(FixedDomain()));
        /**
        <summary>The QWERTZ entrywheel.</summary>
        */
        public static AlphabeticalEntrywheel Qwertz
            => New("QWERTZUIOASDFGHJKPYXCVBNML");
        private EntrywheelPair[] _Pairs = Array.Empty<EntrywheelPair>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Pairs" />
        */
        public required EntrywheelPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="Entrywheel.New(string, string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public AlphabeticalEntrywheel(string p)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(p);
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<EntrywheelPair, char>(p.ToCharArray(), FixedDomain()));
        }
        /**
        <inheritdoc cref="Entrywheel.New(string, string)" />
        */
        public static AlphabeticalEntrywheel New(string p) => new(p);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Domain()" />
        */
        public static char[] FixedDomain() => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    }
}