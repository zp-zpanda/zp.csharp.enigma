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
    <summary>Enigma I implementation.</summary>
    */
    public class EnigmaI : IEnigma<EnigmaI, AlphabeticalRotor, RotorPair, Reflector, ReflectorPair>
    {
        private static string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Rotor[] _Rotors = new Rotor[0];
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Rotors" />
        */
        public Rotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private Reflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Reflector" />
        */
        public Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <summary> I rotor I.</summary>
        */
        public static Rotor I {get => new AlphabeticalRotor(0, new[]{16}, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");}
        /**
        <summary> I rotor II.</summary>
        */
        public static Rotor II {get => new AlphabeticalRotor(0, new[]{4}, "AJDKSIRUXBLHWTMCQGZNPYFVOE");}
        /**
        <summary> I rotor III.</summary>
        */
        public static Rotor III {get => new AlphabeticalRotor(0, new[]{21}, "BDFHJLCPRTXVZNYEIWGAKMUSQO");}
        /**
        <summary> I rotor IV.</summary>
        */
        public static Rotor IV {get => new AlphabeticalRotor(0, new[]{9}, "ESOVPZJAYQUIRHXLNFTGKDCMWB");}
        /**
        <summary> I rotor V.</summary>
        */
        public static Rotor V {get => new AlphabeticalRotor(0, new[]{25}, "VZBRGITYUPSDNHLXAWMJQOFECK");}
        /**
        <summary> I reflector A.</summary>
        */
        public static Reflector A {get => Reflector.WithMap("AEBJCMDZFLGYHXIVKWNROQPUST");}
        /**
        <summary> I reflector B.</summary>
        */
        public static Reflector B {get => Reflector.WithMap("YARBUCHDQESFLGPIXJNKOMZTWV");}
        /**
        <summary> I reflector C.</summary>
        */
        public static Reflector C {get => Reflector.WithMap("FAVBPCJDIEOGYHRKZLXMWNTQUS");}
        /**
        <inheritdoc cref="Enigma.Enigma(Reflector, Rotor[])" />
        */
        [SetsRequiredMembers]
        public EnigmaI(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos)
        {
            this.Setup(GetReflector(reflector), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
            this.Rotors[0].Position = pos.I;
            this.Rotors[1].Position = pos.II;
            this.Rotors[2].Position = pos.III;
        }
        public static EnigmaI New(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos)
            => new EnigmaI(reflector, rotors, pos);
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
        <inheritdoc cref="IEnigma{TEnigma, TRotor, TRotorPair, TReflector, TReflectorPair}.Step()" />
        */
        public override void Step() => new DoubleSteppingRotorStepper().Step(this.Rotors);
    }
}