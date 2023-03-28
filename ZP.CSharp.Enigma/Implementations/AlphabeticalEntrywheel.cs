using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The alphabetical entrywheel.</summary>
    */
    public class AlphabeticalEntrywheel : IFixedDomainEntrywheel<AlphabeticalEntrywheel, AlphabeticalEntrywheelPair, char>
    {
        /**
        <summary>The ABC entrywheel.</summary>
        */
        public static AlphabeticalEntrywheel Abc
            => New(FixedDomain());
        /**
        <summary>The QWERTZ entrywheel.</summary>
        */
        public static AlphabeticalEntrywheel Qwertz
            => New("QWERTZUIOASDFGHJKPYXCVBNML");
        private AlphabeticalEntrywheelPair[] _Pairs = Array.Empty<AlphabeticalEntrywheelPair>();
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Pairs" />
        */
        public required AlphabeticalEntrywheelPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="New(IEnumerable{char})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public AlphabeticalEntrywheel()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.New(IEnumerable{TEntrywheelPair})" />
        */
        public static AlphabeticalEntrywheel New(IEnumerable<AlphabeticalEntrywheelPair> pair)
            => throw new NotSupportedException();
        #pragma warning disable CS1572
        /**
        <summary>Creates a entrywheel with entrywheel pairs created from a entrywheel-side and a reflector-side mapping.</summary>
        <param name="p">The plugboard-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        #pragma warning restore CS1572
        public static AlphabeticalEntrywheel New(IEnumerable<char> p)
        {
            ArgumentNullException.ThrowIfNull(p);
            return new AlphabeticalEntrywheel().Setup(EntrywheelPairHelpers.GetPairsFrom<AlphabeticalEntrywheelPair, char>(p, FixedDomain()));
        }
        /**
        <inheritdoc cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.Domain()" />
        */
        public static IEnumerable<char> FixedDomain() => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}