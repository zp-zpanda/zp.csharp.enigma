using System;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor pair.</summary>
    */
    public class RotorPair : IEquatable<RotorPair>
    {
        /**
        <summary>The character on the entry wheel side.</summary>
        */
        public char EntryWheelSide;
        /**
        <summary>The character on the reflector side.</summary>
        */
        public char ReflectorSide;
        /**
        <summary>Creates a rotor pair with two characters.</summary>
        <param name="eSide">The character on the entry wheel side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public RotorPair(char eSide, char rSide)
        {
            this.EntryWheelSide = eSide;
            this.ReflectorSide = rSide;
        }
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        public RotorPair(string map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            this.EntryWheelSide = map[0];
            this.ReflectorSide = map[1];
        }
        /**
        <summary>Produces the hash code for the rotor pair.</summary>
        */
        public override int GetHashCode() => (this.EntryWheelSide, this.ReflectorSide).GetHashCode();
        /**
        <summary>Checks rotor pair equality.</summary>
        <param name="pair">The rotor pair to compare to.</param>
        <returns>The result.</returns>
        <seealso cref="Equals(object?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public bool Equals(RotorPair? pair)
        {
            if (pair is null)
            {
                return false;
            }
            return pair.EntryWheelSide == this.EntryWheelSide && pair.ReflectorSide == this.ReflectorSide;
        }
        /**
        <inheritdoc cref="Equals(RotorPair?)" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="Equals(RotorPair?)" />
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj) => this.Equals(obj as RotorPair);
        /**
        <inheritdoc cref="Equals(RotorPair?)" />
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(RotorPair?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(RotorPair pair1, RotorPair pair2) => pair1.Equals(pair2);
        /**
        <inheritdoc cref="Equals(RotorPair?)" />
        <summary>Checks rotor pair inequality.</summary>
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <seealso cref="Equals(object?)" />
        <seealso cref="Equals(RotorPair?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(RotorPair pair1, RotorPair pair2) => !pair1.Equals(pair2);
    }
}