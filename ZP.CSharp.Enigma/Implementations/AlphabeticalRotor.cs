using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The alphabetical rotor.</summary>
    */
    public class AlphabeticalRotor : IRotor<AlphabeticalRotor, AlphabeticalRotorPair>
    {
        /**
        <summary>The letters.</summary>
        */
        public const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        private AlphabeticalRotorPair[] _Pairs = Array.Empty<AlphabeticalRotorPair>();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Pairs" />
        */
        public required AlphabeticalRotorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        private string _Domain = "";
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Domain" />
        */
        public required string Domain {get => this._Domain; set => this._Domain = value;}
        private int _Position = 0;
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Position" />
        */
        public required int Position {get => this._Position; set => this._Position = value;}
        private int[] _Notch = new int[]{0};
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Notch" />
        */
        public required int[] Notch {get => this._Notch; set => this._Notch = value;}
        /**
        <inheritdoc cref="AlphabeticalRotor.New(int, int[], string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public AlphabeticalRotor(int pos, int[] notch, string r)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentException.ThrowIfNullOrEmpty(r);
            this.Setup(pos, notch, this.GetPairsFrom(Letters, r));
        }
        /**
        <summary>Creates a rotor with rotor pairs created from the reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static AlphabeticalRotor New(int pos, int[] notch, string r)
            => new(pos, notch, r);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.ComputeDomain()" />
        */
        public string ComputeDomain() => Letters;
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.AllowNextToStep()" />
        */
        public bool AllowNextToStep() => this.Notch.Contains(this.Position);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Step()" />
        */
        public void Step() => this.Position = ((this.Position + 1) % this.Pairs.Length);
    }
}