using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        <inheritdoc cref="New(int, int[], RotorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Rotor(int pos, int[] notch, params RotorPair[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pos, notch, pairs);
        }
        /**
        <summary>Creates a rotor with the rotor pairs provided.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="pairs">The rotor pairs.</param>
        */
        public static Rotor New(int pos, int[] notch, params RotorPair[] pairs) => new(pos, notch, pairs);
        /**
        <inheritdoc cref="New(int, int[], string[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Rotor(int pos, int[] notch, params string[] maps) 
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(pos, notch, RotorPairHelpers.GetPairsFrom<RotorPair>(maps));
        }
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public static Rotor New(int pos, int[] notch, params string[] maps) => new(pos, notch, maps);
        /**
        <inheritdoc cref="New(int, int[], string, string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Rotor(int pos, int[] notch, string e, string r)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentException.ThrowIfNullOrEmpty(e);
            ArgumentException.ThrowIfNullOrEmpty(r);
            this.Setup(pos, notch, RotorPairHelpers.GetPairsFrom<RotorPair>(e, r));
        }
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