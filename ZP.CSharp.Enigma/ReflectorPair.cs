using System;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The reflector pair.</summary>
    */
    public class ReflectorPair
    {
        /**
        <summary>The mapping.</summary>
        */
        public char[] Map;
        /**
        <summary>Creates a reflector pair with two characters.</summary>
        <param name="one">The first character.</param>
        <param name="two">The second character.</param>
        */
        public ReflectorPair(char one, char two)
        {
            if (one == two)
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            this.Map = new[]{one, two};
            Array.Sort(this.Map);
        }
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        public ReflectorPair(string map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{One}{Two}\"");
            }
            if (map[0] == map[1])
            {
                throw new ArgumentException("Reflector must have two different characters to map to.");
            }
            this.Map = map.ToCharArray();
            Array.Sort(this.Map);
        }
    }
}