using System;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor.</summary>
    */
    public class Rotor
    {
        private RotorPair[] _Pairs = new RotorPair[0];
        /**
        <summary>The rotor pairs this rotor has.</summary>
        */
        public RotorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        private string _Domain = "";
        /**
        <summary>The domain of this rotor.</summary>
        */
        public string Domain {get => this._Domain; set => this._Domain = value;}
        private int _Position = 0;
        /**
        <summary>The position of this rotor.</summary>
        */
        public int Position {get => this._Position; set => this._Position = value;}
        private int[] _Notch = new int[]{0};
        /**
        <summary>The turning notches of this rotor.</summary>
        */
        public int[] Notch {get => this._Notch; set => this._Notch = value;}
        /**
        <summary>Creates a rotor with zero rotor pairs.</summary>
        */
        public Rotor()
        {}
        /**
        <summary>Creates a rotor with the rotor pairs provided.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="pairs">The rotor pairs.</param>
        */
        public Rotor(int pos, int[] notch, params RotorPair[] pairs)
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
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="maps">The rotor pair mappings.</param>
        */
        public Rotor(int pos, int[] notch, params string[] maps)
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            maps.ToList().ForEach(map => pairs.Add(new RotorPair(map)));
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
        <summary>Creates a rotor with rotor pairs created from a entry wheel-side and a reflector-side mapping.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="e">The entry wheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public Rotor(int pos, int[] notch, string e, string r)
        {
            if (e.Length != r.Length)
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            for (int i = 0; i < e.Length; i++)
            {
                pairs.Add(new RotorPair(e[i], r[i]));
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
        <summary>Checks if the rotor is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c><see langword="true" /></c> if valid, else <c><see langword="false" /></c>.</returns>
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
        <summary>Matches a character from the entry wheel.</summary>
        <param name="c">The character to map.</param>
        <returns>The mapped character.</returns>
        <exception cref="CharacterNotFoundException"><paramref name="c" /> cannot be mapped.</exception>
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
        <summary>Matches a character from the reflector.</summary>
        <param name="c">The character to map.</param>
        <returns>The mapped character.</returns>
        <exception cref="CharacterNotFoundException"><paramref name="c" /> cannot be mapped.</exception>
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
        <summary>Computes the domain of this rotor.</summary>
        <returns>The domain.</returns>
        */
        public virtual string ComputeDomain() => new string(this.Pairs.Select(pair => pair.Map.EntryWheelSide).ToArray());
        /**
        <summary>Transposes a character coming to the rotor.</summary>
        <param name="c">The character to transpose.</param>
        <returns>The transposed character.</returns>
        */
        public char TransposeIn(char c)
        {
            var index = this.Domain.IndexOf(c);
            var length = this.Domain.Length;
            return this.Domain[(index + this.Position) % length];
        }
        /**
        <summary>Transposes a character going away from the rotor.</summary>
        <param name="c">The character to transpose.</param>
        <returns>The transposed character.</returns>
        */
        public char TransposeOut(char c)
        {
            var index = this.Domain.IndexOf(c);
            var length = this.Domain.Length;
            return this.Domain[(index - this.Position + length) % length];
        }
        /**
        <summary>Returns whether this rotor allows the next to step or not.</summary>
        */
        public bool AllowNextToStep() => this.Notch.Contains(this.Position);
        /**
        <summary>Steps the rotor.</summary>
        */
        public void Step() => this.Position = ((this.Position + 1) % this.Pairs.Length);
    }
}