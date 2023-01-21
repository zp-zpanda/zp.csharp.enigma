using System;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The alphabetical entrywheel.</summary>
    */
    public class AlphabeticalEntrywheel : IFixedDomainEntrywheel<AlphabeticalEntrywheel, StringCharEntrywheelPair, char>
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
        private StringCharEntrywheelPair[] _Pairs = Array.Empty<StringCharEntrywheelPair>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Pairs" />
        */
        public required StringCharEntrywheelPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="StringCharEntrywheel.New(string, string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public AlphabeticalEntrywheel(string p)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(p);
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<StringCharEntrywheelPair, char>(p.ToCharArray(), FixedDomain()));
        }
        /**
        <inheritdoc cref="StringCharEntrywheel.New(string, string)" />
        */
        public static AlphabeticalEntrywheel New(string p) => new(p);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Domain()" />
        */
        public static char[] FixedDomain() => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    }
}