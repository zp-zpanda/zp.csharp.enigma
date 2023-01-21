using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor pair.</summary>
    */
    public class RotorPair<TSingle> : IRotorPair<RotorPair<TSingle>, TSingle>, IEquatable<RotorPair<TSingle>>
        where TSingle :IEqualityOperators<TSingle, TSingle, bool>
    {
        private (TSingle EntryWheelSide, TSingle ReflectorSide) _Map;
        /**
        <inheritdoc cref="IRotorPair{TRotorPair, TSingle}.Map" />
        */
        public required (TSingle EntryWheelSide, TSingle ReflectorSide) Map {get => this._Map; set => this._Map = value;}
        /**
        <inheritdoc cref="New(TSingle, TSingle)" />
        */
        [SetsRequiredMembers]
        protected RotorPair(TSingle eSide, TSingle rSide) => this.Map = (eSide, rSide);
        /**
        <summary>Creates a rotor pair with two characters.</summary>
        <param name="eSide">The character on the entry wheel side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static RotorPair<TSingle> New(TSingle eSide, TSingle rSide) => new(eSide, rSide);
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        [SetsRequiredMembers]
        protected RotorPair(TSingle[] map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            this.Map = (map.First(), map.Last());
        }
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        public static RotorPair<TSingle> New(TSingle[] map) => new(map);
        /**
        <summary>Produces the hash code for the rotor pair.</summary>
        */
        public override int GetHashCode() => this.Map.GetHashCode();
        /**
        <summary>Checks rotor pair equality.</summary>
        <param name="pair">The rotor pair to compare to.</param>
        <returns>The result.</returns>
        <seealso cref="Equals(object?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public bool Equals(RotorPair<TSingle>? pair) => pair is not null && pair.Map == this.Map;
        /**
        <inheritdoc cref="Equals(RotorPair{TSingle}?)" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="Equals(RotorPair{TSingle}?)" />

        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj) => this.Equals(obj as RotorPair<TSingle>);
        /**
        <inheritdoc cref="Equals(RotorPair{TSingle}?)" />
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(RotorPair{TSingle}?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(RotorPair<TSingle> pair1, RotorPair<TSingle> pair2) => pair1.Equals(pair2);
        /**
        <inheritdoc cref="Equals(RotorPair{TSingle}?)" />
        <summary>Checks rotor pair inequality.</summary>
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(RotorPair{TSingle}?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(RotorPair<TSingle> pair1, RotorPair<TSingle> pair2) => !pair1.Equals(pair2);
    }
}