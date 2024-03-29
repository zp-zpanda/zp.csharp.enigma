using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The string-char reflector pair.</summary>
    */
    public class StringCharReflectorPair : IReflectorPair<StringCharReflectorPair, char>, IEquatable<StringCharReflectorPair>
    {
        private (char One, char Two) _Map;
        /**
        <summary>The mapping.</summary>
        */
        public required (char One, char Two) Map {get => this._Map; set => this._Map = value;}
        /**
        <inheritdoc cref="New(char, char)" />
        */
        [SetsRequiredMembers]
        protected StringCharReflectorPair(char one, char two)
        {
            if (one == two)
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            var map = Enumerable.Empty<char>().Append(one).Append(two).OrderBy(c => c);
            this.Map = (map.First(), map.Last());
        }
        /**
        <inheritdoc cref="IReflectorPair{TReflectorPair, TSingle}.New(TSingle, TSingle)" />
        */
        public static StringCharReflectorPair New(char one, char two) => new(one, two);
        /**
        <inheritdoc cref="New(string)" />
        */
        [SetsRequiredMembers]
        protected StringCharReflectorPair(string map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{One}{Two}\"");
            }
            if (map.First() == map.Last())
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            var mapArr = map.ToCharArray().OrderBy(c => c);
            this.Map = (mapArr.First(), mapArr.Last());
        }
        /**
        <inheritdoc cref="IReflectorPair{TReflectorPair, TSingle}.New(string)" />
        */
        public static StringCharReflectorPair New(string map) => new(map);
        /**
        <summary>Produces the hash code for the reflector pair.</summary>
        */
        public override int GetHashCode() => this.Map.GetHashCode();
        /**
        <summary>Checks reflector pair equality.</summary>
        <param name="pair">The reflector pair to compare to.</param>
        <returns>The result.</returns>
        <seealso cref="Equals(object?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public bool Equals(StringCharReflectorPair? pair) => pair is not null && pair.Map == this.Map;
        /**
        <inheritdoc cref="Equals(StringCharReflectorPair?)" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="Equals(StringCharReflectorPair?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj) => this.Equals(obj as StringCharReflectorPair);
        /**
        <inheritdoc cref="Equals(StringCharReflectorPair?)" />
        <param name="pair1">Reflector pair 1.</param>
        <param name="pair2">Reflector pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(StringCharReflectorPair?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(StringCharReflectorPair pair1, StringCharReflectorPair pair2) => pair1.Equals(pair2);
        /**
        <inheritdoc cref="Equals(StringCharReflectorPair?)" />
        <summary>Checks rotor pair inequality.</summary>
        <param name="pair1">Reflector pair 1.</param>
        <param name="pair2">Reflector pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(StringCharReflectorPair?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(StringCharReflectorPair pair1, StringCharReflectorPair pair2) => !pair1.Equals(pair2);
    }
}