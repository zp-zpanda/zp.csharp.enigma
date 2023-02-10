using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The alphabetical rotor.</summary>
    */
    public class AlphabeticalRotor : IFixedDomainRotor<AlphabeticalRotor, AlphabeticalRotorPair, char>
    {
        
        private AlphabeticalRotorPair[] _Pairs = Array.Empty<AlphabeticalRotorPair>();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Pairs" />
        */
        public required AlphabeticalRotorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        private int _Position = 0;
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Position" />
        */
        public required int Position {get => this._Position; set => this._Position = value;}
        private int[] _Notch = new int[]{0};
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Notch" />
        */
        public required int[] Notch {get => this._Notch; set => this._Notch = value;}
        /**
        <inheritdoc cref="New(int, int[], string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public AlphabeticalRotor()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.New(int, int[], TRotorPair[])"/>
        */
        public static AlphabeticalRotor New(int pos, int[] notch, params AlphabeticalRotorPair[] pairs)
            => throw new NotSupportedException();
        /**
        <summary>Creates a rotor with rotor pairs created from the reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static AlphabeticalRotor New(int pos, int[] notch, string r)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentException.ThrowIfNullOrEmpty(r);
            return new AlphabeticalRotor().Setup(pos, notch, RotorPairHelpers.GetPairsFrom<AlphabeticalRotorPair, char>(FixedDomain(), r.ToCharArray()));
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Domain()" />
        */
        public static char[] FixedDomain() => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.AllowNextToStep()" />
        */
        public bool AllowNextToStep() => this.Notch.Contains(this.Position);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Step()" />
        */
        public void Step() => this.Position = ((this.Position + 1) % this.Pairs.Length);
    }
}