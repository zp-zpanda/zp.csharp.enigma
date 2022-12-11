using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor.</summary>
    */
    public class Rotor : IRotor<Rotor, RotorPair>
    {
        private RotorPair[] _Pairs = new RotorPair[0];
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Pairs" />
        */
        public required RotorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        private string _Domain = "";
        /**
        <inheritdoc cref="IRotor.Domain" />
        */
        public required string Domain {get => this._Domain; set => this._Domain = value;}
        private int _Position = 0;
        /**
        <inheritdoc cref="IRotor.Position" />
        */
        public required int Position {get => this._Position; set => this._Position = value;}
        private int[] _Notch = new int[]{0};
        /**
        <inheritdoc cref="IRotor.Notch" />
        */
        public required int[] Notch {get => this._Notch; set => this._Notch = value;}
        /**
        <inheritdoc cref="Rotor.WithPositionNotchAndRotorPairs(int, int[], RotorPair[])" />
        */
        [SetsRequiredMembers]
        protected Rotor(int pos, int[] notch, params RotorPair[] pairs)
        {
            this.Pairs = pairs;
            if (!this.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            this.Domain = this.ComputeDomain();
            this.Position = pos % this.Pairs.Length;
            this.Notch = notch.Select(n => n % this.Pairs.Length).ToArray();
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.WithPositionNotchAndRotorPairs(int, int[], TRotorPair[])" />
        */
        public static Rotor WithPositionNotchAndRotorPairs(int pos, int[] notch, params RotorPair[] pairs) => new Rotor(pos, notch, pairs);
        /**
        <inheritdoc cref="Rotor.WithPositionNotchAndMaps(int, int[], string[])" />
        */
        [SetsRequiredMembers]
        protected Rotor(int pos, int[] notch, params string[] maps)
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            maps.ToList().ForEach(map => pairs.Add(RotorPair.WithMap(map)));
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            this.Domain = this.ComputeDomain();
            this.Position = pos % this.Pairs.Length;
            this.Notch = notch.Select(n => n % this.Pairs.Length).ToArray();
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.WithPositionNotchAndMaps(int, int[], string[])" />
        */
        public static Rotor WithPositionNotchAndMaps(int pos, int[] notch, params string[] maps) => new Rotor(pos, notch, maps);
        /**
        <inheritdoc cref="Rotor.WithPositionNotchAndTwoMaps(int, int[], string, string)" />
        */
        [SetsRequiredMembers]
        protected Rotor(int pos, int[] notch, string e, string r)
        {
            if (e.Length != r.Length)
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            for (int i = 0; i < e.Length; i++)
            {
                pairs.Add(RotorPair.WithTwoCharacters(e[i], r[i]));
            }
            this.Pairs = pairs.ToArray();
            if (!this.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            this.Domain = this.ComputeDomain();
            this.Position = pos % this.Pairs.Length;
            this.Notch = notch.Select(n => n % this.Pairs.Length).ToArray();
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.WithPositionNotchAndTwoMaps(int, int[], string, string)" />
        */
        public static Rotor WithPositionNotchAndTwoMaps(int pos, int[] notch, string e, string r) => new Rotor(pos, notch, e, r);
        /**
        <inheritdoc cref="IRotor.IsValid()" />
        */
        public virtual bool IsValid()
        {
            var eArr = this.Pairs.Select(pair => pair.Map.EntryWheelSide).OrderBy(e => e);
            var rArr = this.Pairs.Select(pair => pair.Map.ReflectorSide).OrderBy(r => r);
            var e = !eArr.GroupBy(e => e).Select(group => group.Count()).Any(count => count > 1);
            var r = !rArr.GroupBy(r => r).Select(group => group.Count()).Any(count => count > 1);
            var same = eArr.SequenceEqual(rArr);
            return (e && r && same);
        }
        /**
        <inheritdoc cref="IRotor.FromEntryWheel(char)" />
        */
        public char FromEntryWheel(char c)
        {
            try
            {
                return this.TransposeOut(this.Pairs.Where(pair => this.TransposeIn(c) == pair.Map.EntryWheelSide).Single().Map.ReflectorSide);
            }
            catch
            {
                throw new CharacterNotFoundException();
            }
        }
        /**
        <inheritdoc cref="IRotor.FromReflector(char)" />
        */
        public char FromReflector(char c)
        {
            try
            {
                return this.TransposeOut(this.Pairs.Where(pair => this.TransposeIn(c) == pair.Map.ReflectorSide).Single().Map.EntryWheelSide);
            }
            catch
            {
                throw new CharacterNotFoundException();
            }
        }
        /**
        <inheritdoc cref="IRotor.ComputeDomain()" />
        */
        public virtual string ComputeDomain() => new string(this.Pairs.Select(pair => pair.Map.EntryWheelSide).ToArray());
        /**
        <inheritdoc cref="IRotor.TransposeIn(char)" />
        */
        public char TransposeIn(char c)
        {
            var index = this.Domain.IndexOf(c);
            var length = this.Domain.Length;
            return this.Domain[(index + this.Position) % length];
        }
        /**
        <inheritdoc cref="IRotor.TransposeOut(char)" />
        */
        public char TransposeOut(char c)
        {
            var index = this.Domain.IndexOf(c);
            var length = this.Domain.Length;
            return this.Domain[(index - this.Position + length) % length];
        }
        /**
        <inheritdoc cref="IRotor.AllowNextToStep()" />
        */
        public bool AllowNextToStep() => this.Notch.Contains(this.Position);
        /**
        <inheritdoc cref="IRotor.Step()" />
        */
        public void Step() => this.Position = ((this.Position + 1) % this.Pairs.Length);
    }
}