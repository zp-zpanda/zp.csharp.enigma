using System;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the entrywheel.</summary>
    */
    public interface IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>The entrywheel pairs this entrywheel has.</summary>
        */
        public TEntrywheelPair[] Pairs {get; set;}
        /**
        <summary>Creates a entrywheel with the entrywheel pairs provided.</summary>
        <param name="pairs">The entrywheel pairs.</param>
        */
        public static abstract TEntrywheel New(params TEntrywheelPair[] pairs);
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
        public TSingle FromPlugboard(TSingle c)
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
        public TSingle FromReflector(TSingle c)
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
        public TSingle[] Domain() => this.Pairs.Select(pair => pair.Map.PlugboardSide).ToArray();
    }
}