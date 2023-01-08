using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the rotor.</summary>
    */
    public interface IRotor<TRotor, TRotorPair>
        where TRotor : IRotor<TRotor, TRotorPair>
        where TRotorPair : IRotorPair<TRotorPair>
    {
        /**
        <summary>The position of this rotor.</summary>
        */
        public int Position {get; set;}
        /**
        <summary>The turning notches of this rotor.</summary>
        */
        public int[] Notch {get; set;}
        /**
        <summary>The rotor pairs this rotor has.</summary>
        */
        public TRotorPair[] Pairs {get; set;}
        /**
        <summary>Checks if the rotor is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c><see langword="true" /></c> if valid, else <c><see langword="false" /></c>.</returns>
        */
        public bool IsValid()
        {
            var eArr = this.Pairs.Select(pair => pair.Map.EntryWheelSide).OrderBy(e => e);
            var rArr = this.Pairs.Select(pair => pair.Map.ReflectorSide).OrderBy(r => r);
            var e = eArr.GroupBy(e => e).Select(group => group.Count()).All(count => count == 1);
            var r = rArr.GroupBy(r => r).Select(group => group.Count()).All(count => count == 1);
            var same = eArr.SequenceEqual(rArr);
            return e && r && same;
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
        <summary>Get the domain of this rotor.</summary>
        <returns>The domain.</returns>
        */
        public virtual string Domain() => new(this.Pairs.Select(pair => pair.Map.EntryWheelSide).ToArray());
        /**
        <summary>Transposes a character coming to the rotor.</summary>
        <param name="c">The character to transpose.</param>
        <returns>The transposed character.</returns>
        */
        public char TransposeIn(char c)
        {
            var index = this.Domain().IndexOf(c);
            var length = this.Domain().Length;
            return this.Domain()[(index + this.Position) % length];
        }
        /**
        <summary>Transposes a character going away from the rotor.</summary>
        <param name="c">The character to transpose.</param>
        <returns>The transposed character.</returns>
        */
        public char TransposeOut(char c)
        {
            var index = this.Domain().IndexOf(c);
            var length = this.Domain().Length;
            return this.Domain()[(index - this.Position + length) % length];
        }
        /**
        <summary>Returns whether this rotor allows the next to step or not.</summary>
        */
        public bool AllowNextToStep();
        /**
        <summary>Steps the rotor.</summary>
        */
        public void Step();
    }
}