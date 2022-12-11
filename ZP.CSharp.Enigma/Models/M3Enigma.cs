using System;
using System.Diagnostics.CodeAnalysis;
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
        public static Rotor I {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{16}, Letters, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");}
        /**
        <summary> M3 rotor II.</summary>
        */
        public static Rotor II {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{4}, Letters, "AJDKSIRUXBLHWTMCQGZNPYFVOE");}
        /**
        <summary> M3 rotor III.</summary>
        */
        public static Rotor III {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{21}, Letters, "BDFHJLCPRTXVZNYEIWGAKMUSQO");}
        /**
        <summary> M3 rotor IV.</summary>
        */
        public static Rotor IV {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{9}, Letters, "ESOVPZJAYQUIRHXLNFTGKDCMWB");}
        /**
        <summary> M3 rotor V.</summary>
        */
        public static Rotor V {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{25}, Letters, "VZBRGITYUPSDNHLXAWMJQOFECK");}
        /**
        <summary> M3 rotor VI.</summary>
        */
        public static Rotor VI {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{25, 12}, Letters, "JPGVOUMFYQBENHZRDKASXLICTW");}
        /**
        <summary> M3 rotor VII.</summary>
        */
        public static Rotor VII {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{25, 12}, Letters, "NZJHGRCXMYSWBOUFAIVLPEKQDT");}
        /**
        <summary> M3 rotor VIII.</summary>
        */
        public static Rotor VIII {get => Rotor.WithPositionNotchAndTwoMaps(0, new[]{25, 12}, Letters, "FKQHTLXOCBJSPDZRAMEWNIUYGV");}
        /**
        <summary> M3 reflector B.</summary>
        */
        public static Reflector B {get => Reflector.WithMap("YARBUCHDQESFLGPIXJNKOMZTWV");}
        /**
        <summary> M3 reflector C.</summary>
        */
        public static Reflector C {get => Reflector.WithMap("FAVBPCJDIEOGYHRKZLXMWNTQUS");}
        /**
        <inheritdoc cref="Enigma.Enigma(Reflector, Rotor[])" />
        */
        [SetsRequiredMembers]
        public M3Enigma(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos)
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
                {"V", V},
                {"VI", VI},
                {"VII", VII},
                {"VIII", VIII}
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