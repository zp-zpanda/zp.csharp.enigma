using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The entrywheel pair.</summary>
    */
    public class AlphabeticalEntrywheelPair : IEntrywheelPair<AlphabeticalEntrywheelPair, char>, IEquatable<AlphabeticalEntrywheelPair>
    {
        private (char PlugboardSide, char ReflectorSide) _Map;
        /**
        <inheritdoc cref="IEntrywheelPair{TEntrywheelPair, TSingle}.Map" />
        */
        public required (char PlugboardSide, char ReflectorSide) Map {get => this._Map; set => this._Map = value;}
        /**
        <inheritdoc cref="New(char, char)" />
        */
        [SetsRequiredMembers]
        protected AlphabeticalEntrywheelPair(char pSide, char rSide) => this.Map = (pSide, rSide);
        /**
        <summary>Creates a entrywheel pair with two characters.</summary>
        <param name="pSide">The character on the plugboard side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static AlphabeticalEntrywheelPair New(char pSide, char rSide) => new(pSide, rSide);
        /**
        <summary>Creates a entrywheel pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        [SetsRequiredMembers]
        protected AlphabeticalEntrywheelPair(string map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            this.Map = (map.First(), map.Last());
        }
        /**
        <summary>Creates a entrywheel pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        public static AlphabeticalEntrywheelPair New(string map) => new(map);
        /**
        <summary>Produces the hash code for the entrywheel pair.</summary>
        */
        public override int GetHashCode() => this.Map.GetHashCode();
        /**
        <summary>Checks entrywheel pair equality.</summary>
        <param name="pair">The entrywheel pair to compare to.</param>
        <returns>The result.</returns>
        <seealso cref="Equals(object?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public bool Equals(AlphabeticalEntrywheelPair? pair) => pair is not null && pair.Map == this.Map;
        /**
        <inheritdoc cref="Equals(AlphabeticalEntrywheelPair?)" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="Equals(AlphabeticalEntrywheelPair?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj) => this.Equals(obj as AlphabeticalEntrywheelPair);
        /**
        <inheritdoc cref="Equals(AlphabeticalEntrywheelPair?)" />
        <param name="pair1">Entrywheel pair 1.</param>
        <param name="pair2">Entrywheel pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(AlphabeticalEntrywheelPair?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(AlphabeticalEntrywheelPair pair1, AlphabeticalEntrywheelPair pair2) => pair1.Equals(pair2);
        /**
        <inheritdoc cref="Equals(AlphabeticalEntrywheelPair?)" />
        <summary>Checks entrywheel pair inequality.</summary>
        <param name="pair1">Entrywheel pair 1.</param>
        <param name="pair2">Entrywheel pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(AlphabeticalEntrywheelPair?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(AlphabeticalEntrywheelPair pair1, AlphabeticalEntrywheelPair pair2) => !pair1.Equals(pair2);
    }
}