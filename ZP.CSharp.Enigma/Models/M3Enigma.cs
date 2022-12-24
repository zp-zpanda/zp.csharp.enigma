using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
using ZP.CSharp.Enigma.Models;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>M3 enigma implementation, used by the Kriegsmarine.</summary>
    */
    public class M3Enigma : IEnigma<M3Enigma, AlphabeticalRotor, RotorPair, Reflector, ReflectorPair>
    {
        private static string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private AlphabeticalRotor[] _Rotors = new AlphabeticalRotor[0];
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Rotors" />
        */
        public AlphabeticalRotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Reflector" />
        */
        public Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <summary> M3 rotor I.</summary>
        */
        public static AlphabeticalRotor I {get => AlphabeticalRotor.New(0, new[]{16}, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");}
        /**
        <summary> M3 rotor II.</summary>
        */
        public static AlphabeticalRotor II {get => AlphabeticalRotor.New(0, new[]{4}, "AJDKSIRUXBLHWTMCQGZNPYFVOE");}
        /**
        <summary> M3 rotor III.</summary>
        */
        public static AlphabeticalRotor III {get => AlphabeticalRotor.New(0, new[]{21}, "BDFHJLCPRTXVZNYEIWGAKMUSQO");}
        /**
        <summary> M3 rotor IV.</summary>
        */
        public static AlphabeticalRotor IV {get => AlphabeticalRotor.New(0, new[]{9}, "ESOVPZJAYQUIRHXLNFTGKDCMWB");}
        /**
        <summary> M3 rotor V.</summary>
        */
        public static AlphabeticalRotor V {get => AlphabeticalRotor.New(0, new[]{25}, "VZBRGITYUPSDNHLXAWMJQOFECK");}
        /**
        <summary> M3 rotor VI.</summary>
        */
        public static AlphabeticalRotor VI {get => AlphabeticalRotor.New(0, new[]{25, 12}, "JPGVOUMFYQBENHZRDKASXLICTW");}
        /**
        <summary> M3 rotor VII.</summary>
        */
        public static AlphabeticalRotor VII {get => AlphabeticalRotor.New(0, new[]{25, 12}, "NZJHGRCXMYSWBOUFAIVLPEKQDT");}
        /**
        <summary> M3 rotor VIII.</summary>
        */
        public static AlphabeticalRotor VIII {get => AlphabeticalRotor.New(0, new[]{25, 12}, "FKQHTLXOCBJSPDZRAMEWNIUYGV");}
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
        {
            this.Setup(GetReflector(reflector), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
            this.Rotors[0].Position = pos.I;
            this.Rotors[1].Position = pos.II;
            this.Rotors[2].Position = pos.III;
        }
        public static M3Enigma New(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos)
            => new M3Enigma(reflector, rotors, pos);
        private static AlphabeticalRotor GetRotor(string rotor)
        {
            return new Dictionary<string, AlphabeticalRotor>(){
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
        public void Step() => this.Rotors.StepWithDoubleSteppingMechanism();
    }
}