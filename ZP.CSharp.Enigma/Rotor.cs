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
        public Rotor()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.New(int, int[], TRotorPair[])" />
        */
        public static Rotor<TSingle> New(int pos, int[] notch, params RotorPair<TSingle>[] pairs)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            return new Rotor<TSingle>().Setup(pos, notch, pairs);
        }
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public static Rotor<TSingle> New(int pos, int[] notch, params TSingle[][] maps)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentNullException.ThrowIfNull(map));
            return New(pos, notch, RotorPairHelpers.GetPairsFrom<RotorPair<TSingle>, TSingle>(maps));
        }
        /**
        <summary>Creates a rotor with rotor pairs created from a entry wheel-side and a reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public static Rotor<TSingle> New(int pos, int[] notch, TSingle[] e, TSingle[] r)
        {
            ArgumentNullException.ThrowIfNull(notch);
            ArgumentNullException.ThrowIfNull(e);
            ArgumentNullException.ThrowIfNull(r);
            return New(pos, notch, RotorPairHelpers.GetPairsFrom<RotorPair<TSingle>, TSingle>(e, r));
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