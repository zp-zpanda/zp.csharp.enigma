using System;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor pair.</summary>
    */
    public class RotorPair
    {
        /**
        <summary>The character on the Entrywheel side.</summary>
        */
        public char EntryWheelSide;
        /**
        <summary>The character on the reflector side.</summary>
        */
        public char ReflectorSide;
        /**
        <summary>Creates a rotor pair with two characters.</summary>
        <param name="eSide">The character on the Entrywheel side.</param>
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
        <inheritdoc cref="operator ==" />
        <param name="obj">The object to compare to.</param>
        <seealso cref="operator ==" />
        <seealso cref="operator !=" />
        */
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (obj is RotorPair pair)
            {
                return pair == this;
            }
            return false;
        }
        /**
        <summary>Produces the hash code for the rotor pair.</summary>
        */
        public override int GetHashCode()
        {
            return (new char[]{this.EntryWheelSide, this.ReflectorSide}).GetHashCode();
        }
        /**
        <summary>Checks rotor pair equality.</summary>
        <param name="pair1">Rotor pair 1.</param>
        <param name="pair2">Rotor pair 2.</param>
        <returns>The result.</returns>
        <seealso cref="Equals(System.Object?)" />
        <seealso cref="operator !=" />
        */
        public static bool operator ==(RotorPair pair1, RotorPair pair2)
        {
            return (pair1.EntryWheelSide == pair2.EntryWheelSide) && (pair1.ReflectorSide == pair2.ReflectorSide);
        }
        /**
        <inheritdoc cref="operator ==" />
        <summary>Checks rotor pair inequality.</summary>
        <seealso cref="Equals(System.Object?)" />
        <seealso cref="operator ==" />
        */
        public static bool operator !=(RotorPair pair1, RotorPair pair2)
        {
            return !(pair1 == pair2);
        }
    }
}