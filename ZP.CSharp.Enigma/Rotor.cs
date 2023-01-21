using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor.</summary>
    */
    public class Rotor<TSingle> : IRotor<Rotor<TSingle>, RotorPair<TSingle>, TSingle>
        where TSingle :IEqualityOperators<TSingle, TSingle, bool>
    {
        private RotorPair<TSingle>[] _Pairs = Array.Empty<RotorPair<TSingle>>();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Pairs" />
        */
        public required RotorPair<TSingle>[] Pairs {get => this._Pairs; set => this._Pairs = value;}
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
        <inheritdoc cref="New(int, int[], RotorPair{TSingle}[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Rotor(int pos, int[] notch, params RotorPair<TSingle>[] pairs)
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
        public static Rotor<TSingle> New(int pos, int[] notch, params RotorPair<TSingle>[] pairs) => new(pos, notch, pairs);
        /**
        <inheritdoc cref="New(int, int[], TSingle[][])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Rotor(int pos, int[] notch, params TSingle[][] maps) 
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentNullException.ThrowIfNull(map));
            this.Setup(pos, notch, RotorPairHelpers.GetPairsFrom<RotorPair<TSingle>, TSingle>(maps));
        }
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public static Rotor<TSingle> New(int pos, int[] notch, params TSingle[][] maps) => new(pos, notch, maps);
        /**
        <inheritdoc cref="New(int, int[], TSingle[], TSingle[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected Rotor(int pos, int[] notch, TSingle[] e, TSingle[] r)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(e);
            ArgumentNullException.ThrowIfNull(r);
            this.Setup(pos, notch, RotorPairHelpers.GetPairsFrom<RotorPair<TSingle>, TSingle>(e, r));
        }
        /**
        <summary>Creates a rotor with rotor pairs created from a entry wheel-side and a reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static Rotor<TSingle> New(int pos, int[] notch, TSingle[] e, TSingle[] r) => new(pos, notch, e, r);
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