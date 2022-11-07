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
    public class EnigmaI : Enigma
    {
        private static string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /**
        <summary> I rotor I.</summary>
        */
        public static Rotor I {get => new Rotor(0, new[]{16}, Letters, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");}
        /**
        <summary> I rotor II.</summary>
        */
        public static Rotor II {get => new Rotor(0, new[]{4}, Letters, "AJDKSIRUXBLHWTMCQGZNPYFVOE");}
        /**
        <summary> I rotor III.</summary>
        */
        public static Rotor III {get => new Rotor(0, new[]{21}, Letters, "BDFHJLCPRTXVZNYEIWGAKMUSQO");}
        /**
        <summary> I rotor IV.</summary>
        */
        public static Rotor IV {get => new Rotor(0, new[]{9}, Letters, "ESOVPZJAYQUIRHXLNFTGKDCMWB");}
        /**
        <summary> I rotor V.</summary>
        */
        public static Rotor V {get => new Rotor(0, new[]{25}, Letters, "VZBRGITYUPSDNHLXAWMJQOFECK");}
        /**
        <summary> I reflector A.</summary>
        */
        public static Reflector A {get => new Reflector("AEBJCMDZFLGYHXIVKWNROQPUST");}
        /**
        <summary> I reflector B.</summary>
        */
        public static Reflector B {get => new Reflector("YARBUCHDQESFLGPIXJNKOMZTWV");}
        /**
        <summary> I reflector C.</summary>
        */
        public static Reflector C {get => new Reflector("FAVBPCJDIEOGYHRKZLXMWNTQUS");}
        /**
        <inheritdoc cref="Enigma.Enigma(Reflector, Rotor[])" />
        */
        public EnigmaI(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos)
            : base(GetReflector(reflector), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III))
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
                {"V", V}
            }[rotor];
        }
        private static Reflector GetReflector(string reflector)
        {
            return new Dictionary<string, Reflector>(){
                {"A", A},
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