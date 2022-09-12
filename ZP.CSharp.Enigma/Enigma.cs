using System;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The enigma.</summary>
    */
    public class Enigma
    {
        private Rotor[] _Rotors;
        /**
        <summary>The rotors this enigma has.</summary>
        */
        public Rotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector _Reflector;
        /**
        <summary>The reflector this enigma has.</summary>
        */
        public Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        public Enigma(Reflector reflector, params Rotor[] rotors)
        {
            this.Rotors = rotors;
            this.Reflector = reflector;
        }
        /**
        <summary>Runs the enigma on a character.</summary>
        <param name="c">The character to run on.</param>
        <returns>The encoded/decoded character.</returns>
        */
        public char RunOn(char c)
        {
            var input = c;
            this.Rotors.ToList().ForEach(rotor => input = rotor.FromEntryWheel(input));
            input = this.Reflector.Reflect(input);
            this.Rotors.Reverse().ToList().ForEach(rotor => input = rotor.FromReflector(input));
            return input;
        }
        /**
        <summary>Runs the enigma on a string.</summary>
        <param name="s">The string to run on.</param>
        <returns>The encoded/decoded string.</returns>
        */
        public string RunOn(string s)
        {
            var result = "";
            for (int i = 0; i < s.Length; i++)
            {
                result += this.RunOn(s[i]);
            }
            return result;
        }
    }
}