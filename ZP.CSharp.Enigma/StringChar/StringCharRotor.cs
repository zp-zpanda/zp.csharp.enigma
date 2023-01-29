using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The string-char rotor.</summary>
    */
    public class StringCharRotor : IRotor<StringCharRotor, StringCharRotorPair, char>
    {
        private StringCharRotorPair[] _Pairs = Array.Empty<StringCharRotorPair>();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Pairs" />
        */
        public required StringCharRotorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}

        private int _Position = 0;
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Position" />
        */
        public required virtual int Position {get => this._Position; set => this._Position = value;}
        private int[] _Notch = new int[]{0};
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Notch" />
        */
        public required int[] Notch {get => this._Notch; set => this._Notch = value;}
        /**
        <inheritdoc cref="New(int, int[], StringCharRotorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public StringCharRotor()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.New(int, int[], TRotorPair[])" />
        */
        public static StringCharRotor New(int pos, int[] notch, params StringCharRotorPair[] pairs)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            return new StringCharRotor().Setup(pos, notch, pairs);
        }
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public static StringCharRotor New(int pos, int[] notch, params string[] maps)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            return New(pos, notch, RotorPairHelpers.GetPairsFrom<StringCharRotorPair, char>(maps.Select(s => s.ToCharArray()).ToArray()));
        }
        /**
        <summary>Creates a rotor with rotor pairs created from a entry wheel-side and a reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static StringCharRotor New(int pos, int[] notch, string e, string r)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentException.ThrowIfNullOrEmpty(e);
            ArgumentException.ThrowIfNullOrEmpty(r);
            return New(pos, notch, RotorPairHelpers.GetPairsFrom<StringCharRotorPair, char>(e.ToCharArray(), r.ToCharArray()));
        }
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