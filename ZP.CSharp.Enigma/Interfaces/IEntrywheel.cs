using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the entrywheel.</summary>
    */
    public interface IEntrywheel<TEntrywheel, TEntrywheelPair>
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
    {
        /**
        <summary>The entrywheel pairs this entrywheel has.</summary>
        */
        public TEntrywheelPair[] Pairs {get; set;}
        /**
        <summary>Checks if the entrywheel is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c><see langword="true" /></c> if valid, else <c><see langword="false" /></c>.</returns>
        */
        public bool IsValid()
        {
            var pArr = this.Pairs.Select(pair => pair.Map.PlugboardSide).OrderBy(p => p);
            var rArr = this.Pairs.Select(pair => pair.Map.ReflectorSide).OrderBy(r => r);
            var p = pArr.GroupBy(p => p).Select(group => group.Count()).All(count => count == 1);
            var r = rArr.GroupBy(r => r).Select(group => group.Count()).All(count => count == 1);
            var same = pArr.SequenceEqual(rArr);
            return p && r && same;
        }
        /**
        <summary>Matches a character from the plugboard.</summary>
        <param name="c">The character to map.</param>
        <returns>The mapped character.</returns>
        <exception cref="CharacterNotFoundException"><paramref name="c" /> cannot be mapped.</exception>
        */
        public char FromPlugboard(char c)
        {
            try
            {
                return this.Pairs.Where(pair => c == pair.Map.PlugboardSide).Single().Map.ReflectorSide;
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
                return this.Pairs.Where(pair => c == pair.Map.ReflectorSide).Single().Map.PlugboardSide;
            }
            catch
            {
                throw new CharacterNotFoundException();
            }
        }
        /**
        <summary>Get the domain of this entrywheel.</summary>
        <returns>The domain.</returns>
        */
        public virtual string Domain() => new(this.Pairs.Select(pair => pair.Map.PlugboardSide).ToArray());
    }
}