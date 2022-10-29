using System;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Implementations;
using ZP.CSharp.Enigma.Models;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>M3 enigma implementation, used by the Kriegsmarine.</summary>
    */
    public class M3Enigma : Enigma
    {
        private static string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /**
        <summary> M3 rotor I.</summary>
        */
        public static Rotor I {get => new Rotor(0, 16, Letters, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");}
        /**
        <summary> M3 rotor II.</summary>
        */
        public static Rotor II {get => new Rotor(0, 4, Letters, "AJDKSIRUXBLHWTMCQGZNPYFVOE");}
        /**
        <summary> M3 rotor III.</summary>
        */
        public static Rotor III {get => new Rotor(0, 21, Letters, "BDFHJLCPRTXVZNYEIWGAKMUSQO");}
        /**
        <summary> M3 rotor III.</summary>
        */
        public static Rotor IV {get => new Rotor(0, 21, Letters, "ESOVPZJAYQUIRHXLNFTGKDCMWB");}
        /**
        <summary> M3 rotor V.</summary>
        */
        public static Rotor V {get => new Rotor(0, 21, Letters, "VZBRGITYUPSDNHLXAWMJQOFECK");}
        /**
        <summary> M3 reflector B.</summary>
        */
        public static Reflector B {get => new Reflector("YARBUCHDQESFLGPIXJNKOMZTWV");}
        /**
        <inheritdoc cref="Enigma.Enigma(Reflector, Rotor[])" />
        */
        public M3Enigma((string III, string II, string I) rotors, (int III, int II, int I) pos)
            : base(B, GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III))
        {
            this.Rotors[0].Position = pos.I;
            this.Rotors[1].Position = pos.II;
            this.Rotors[2].Position = pos.III;
        }
        private static Rotor GetRotor(string rotor)
        {
            return new Dictionary<string, Rotor>(){
                {"I", I},
                {"II", II},
                {"III", III},
                {"IV", IV},
                {"V", V},
            }[rotor];
        }
        private static Reflector GetReflector(string reflector)
        {
            return new Dictionary<string, Reflector>(){
                {"B", B},
                {"C", C},
            }[reflector];
        }
        /**
        <inheritdoc cref="Enigma.Step()" />
        */
        public override void Step() => new DoubleSteppingRotorStepper().Step(this.Rotors);
    }
}