using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The reflector pair.</summary>
    */
    public class ReflectorPair<TSingle> : IReflectorPair<ReflectorPair<TSingle>, TSingle>, IEquatable<ReflectorPair<TSingle>>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private (TSingle One, TSingle Two) _Map;
        /**
        <summary>The mapping.</summary>
        */
        public required (TSingle One, TSingle Two) Map {get => this._Map; set => this._Map = value;}
        /**
        <inheritdoc cref="New(TSingle, TSingle)" />
        */
        [SetsRequiredMembers]
        protected ReflectorPair(TSingle one, TSingle two)
        {
            if (one == two)
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            var map = Enumerable.Empty<TSingle>().Append(one).Append(two).OrderBy(c => c);
            this.Map = (map.First(), map.Last());
        }
        /**
        <inheritdoc cref="IReflectorPair{TReflectorPair, TSingle}.New(TSingle, TSingle)" />
        */
        public static ReflectorPair<TSingle> New(TSingle one, TSingle two) => new(one, two);
        /**
        <inheritdoc cref="New(TSingle[])" />
        */
        [SetsRequiredMembers]
        protected ReflectorPair(TSingle[] map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{One}{Two}\"");
            }
            if (map.First() == map.Last())
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            var mapArr = map.OrderBy(c => c);
            this.Map = (mapArr.First(), mapArr.Last());
        }
        /**
        <inheritdoc cref="ReflectorPairHelpers.GetPairFrom{TReflectorPair, TSingle}(TSingle[])" />
        */
        public static ReflectorPair<TSingle> New(TSingle[] map) => ReflectorPairHelpers.GetPairFrom<ReflectorPair<TSingle>, TSingle>(map);
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
        public bool Equals(ReflectorPair<TSingle>? pair) => pair is not null && pair.Map == this.Map;
        /**
        <inheritdoc cref="Equals(ReflectorPair{TSingle}?)" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="Equals(ReflectorPair{TSingle}?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj) => this.Equals(obj as ReflectorPair<TSingle>);
        /**
        <inheritdoc cref="Equals(ReflectorPair{TSingle}?)" />
        <param name="pair1">Reflector pair 1.</param>
        <param name="pair2">Reflector pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(ReflectorPair{TSingle}?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(ReflectorPair<TSingle> pair1, ReflectorPair<TSingle> pair2) => pair1.Equals(pair2);
        /**
        <inheritdoc cref="Equals(ReflectorPair{TSingle}?)" />
        <summary>Checks rotor pair inequality.</summary>
        <param name="pair1">Reflector pair 1.</param>
        <param name="pair2">Reflector pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(ReflectorPair{TSingle}?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(ReflectorPair<TSingle> pair1, ReflectorPair<TSingle> pair2) => !pair1.Equals(pair2);
    }
}