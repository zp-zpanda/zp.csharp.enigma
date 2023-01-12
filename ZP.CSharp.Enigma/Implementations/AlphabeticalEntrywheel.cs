using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The alphabetical entrywheel.</summary>
    */
    public class AlphabeticalEntrywheel : IFixedDomainEntrywheel<AlphabeticalEntrywheel, EntrywheelPair>
    {
        /**
        <summary>The ABC entrywheel.</summary>
        */
        public static AlphabeticalEntrywheel Abc
        {
            get => New(FixedDomain());
        }
        /**
        <summary>The QWERTZ entrywheel.</summary>
        */
        public static AlphabeticalEntrywheel Qwertz
        {
            get => New("QWERTZUIOASDFGHJKPYXCVBNML");
        }
        private EntrywheelPair[] _Pairs = Array.Empty<EntrywheelPair>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.Pairs" />
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
            this.Setup(EntrywheelPairHelpers.GetPairsFrom<EntrywheelPair>(p, FixedDomain()));
        }
        /**
        <inheritdoc cref="Entrywheel.New(string, string)" />
        */
        public static AlphabeticalEntrywheel New(string p) => new(p);
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.Domain()" />
        */
        public static string FixedDomain() => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}