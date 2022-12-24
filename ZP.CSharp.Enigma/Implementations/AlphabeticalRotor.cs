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
    public class AlphabeticalRotor : IRotor<AlphabeticalRotor, RotorPair>
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        private RotorPair[] _Pairs = new RotorPair[0];
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Pairs" />
        */
        public required RotorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
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
        [SetsRequiredMembers]
        public AlphabeticalRotor(int pos, int[] notch, string r) => this.Setup(pos, notch, Letters, r);
        public static AlphabeticalRotor New(int pos, int[] notch, string r)
            => new AlphabeticalRotor(pos, notch, r);
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