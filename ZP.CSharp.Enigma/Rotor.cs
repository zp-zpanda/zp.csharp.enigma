using System;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor.</summary>
    */
    public class Rotor : IRotor<Rotor, RotorPair>
    {
        private RotorPair[] _Pairs = Array.Empty<RotorPair>();
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
        /**
        <inheritdoc cref="Rotor.New(int, int[], RotorPair[])" />
        */
        [SetsRequiredMembers]
        protected Rotor(int pos, int[] notch, params RotorPair[] pairs)
            => this.Setup(pos, notch, pairs);
        /**
        <summary>Creates a rotor with the rotor pairs provided.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="pairs">The rotor pairs.</param>
        */
        public static Rotor New(int pos, int[] notch, params RotorPair[] pairs) => new(pos, notch, pairs);
        /*
        <inheritdoc cref="Rotor.New(int, int[], string[])" />
        */
        [SetsRequiredMembers]
        protected Rotor(int pos, int[] notch, params string[] maps) 
            => this.Setup(pos, notch, this.GetPairsFrom(maps));
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public static Rotor New(int pos, int[] notch, params string[] maps) => new(pos, notch, maps);
        /**
        <inheritdoc cref="Rotor.New(int, int[], string, string)" />
        */
        [SetsRequiredMembers]
        protected Rotor(int pos, int[] notch, string e, string r)
            => this.Setup(pos, notch, this.GetPairsFrom(e, r));
        /**
        <summary>Creates a rotor with rotor pairs created from a entry wheel-side and a reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static Rotor New(int pos, int[] notch, string e, string r) => new(pos, notch, e, r);
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