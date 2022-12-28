using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma.Implementations
{
    public class AlphabeticalRotorPair : IRotorPair<AlphabeticalRotorPair>, IEquatable<AlphabeticalRotorPair>
    {
        private (char EntryWheelSide, char ReflectorSide) _Map;
        /**
        <inheritdoc cref="IRotorPair.Map" />
        */
        public required (char EntryWheelSide, char ReflectorSide) Map {get => this._Map; set => this._Map = value;}
        /**
        <inheritdoc cref="AlphabeticalRotorPair.New(char, char)" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalRotorPair(char eSide, char rSide)
        {
            this.Map = (eSide, rSide);
        }
        /**
        <summary>Creates a rotor pair with two characters.</summary>
        <param name="eSide">The character on the entry wheel side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static AlphabeticalRotorPair New(char eSide, char rSide) => new AlphabeticalRotorPair(eSide, rSide);
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        [SetsRequiredMembers]
        protected AlphabeticalRotorPair(string map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            this.Map = (map[0], map[1]);
        }
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        public static AlphabeticalRotorPair New(string map) => new AlphabeticalRotorPair(map);
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
        public bool Equals(AlphabeticalRotorPair? pair)
        {
            if (pair is null)
            {
                return false;
            }
            return pair.Map == this.Map;
        }
        /**
        <inheritdoc cref="Equals(AlphabeticalRotorPair?)" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="Equals(AlphabeticalRotorPair?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj) => this.Equals(obj as AlphabeticalRotorPair);
        /**
        <inheritdoc cref="Equals(AlphabeticalRotorPair?)" />
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(AlphabeticalRotorPair?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(AlphabeticalRotorPair pair1, AlphabeticalRotorPair pair2) => pair1.Equals(pair2);
        /**
        <inheritdoc cref="Equals(AlphabeticalRotorPair?)" />
        <summary>Checks rotor pair inequality.</summary>
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(AlphabeticalRotorPair?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(AlphabeticalRotorPair pair1, AlphabeticalRotorPair pair2) => !pair1.Equals(pair2);
    }
}