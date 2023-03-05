using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>Enigma I implementation.</summary>
    */
    public class EnigmaI : IEnigma<EnigmaI, AlphabeticalEntrywheel, AlphabeticalEntrywheelPair, AlphabeticalRotor, AlphabeticalRotorPair, AlphabeticalReflector, AlphabeticalReflectorPair, char>
    {
        private AlphabeticalEntrywheel _Entrywheel;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Entrywheel" />
        */
        public required AlphabeticalEntrywheel Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        private AlphabeticalRotor[] _Rotors = Array.Empty<AlphabeticalRotor>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Rotors" />
        */
        public AlphabeticalRotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private AlphabeticalReflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Reflector" />
        */
        public AlphabeticalReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <summary>I rotor I.</summary>
        */
        public static AlphabeticalRotor I => AlphabeticalRotor.New(0, new[]{16}, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");
        /**
        <summary>I rotor II.</summary>
        */
        public static AlphabeticalRotor II => AlphabeticalRotor.New(0, new[]{4}, "AJDKSIRUXBLHWTMCQGZNPYFVOE");
        /**
        <summary>I rotor III.</summary>
        */
        public static AlphabeticalRotor III => AlphabeticalRotor.New(0, new[]{21}, "BDFHJLCPRTXVZNYEIWGAKMUSQO");
        /**
        <summary>I rotor IV.</summary>
        */
        public static AlphabeticalRotor IV => AlphabeticalRotor.New(0, new[]{9}, "ESOVPZJAYQUIRHXLNFTGKDCMWB");
        /**
        <summary>I rotor V.</summary>
        */
        public static AlphabeticalRotor V => AlphabeticalRotor.New(0, new[]{25}, "VZBRGITYUPSDNHLXAWMJQOFECK");
        /**
        <summary>I reflector A.</summary>
        */
        public static AlphabeticalReflector A => AlphabeticalReflector.New("AEBJCMDZFLGYHXIVKWNROQPUST");
        /**
        <summary>I reflector B.</summary>
        */
        public static AlphabeticalReflector B => AlphabeticalReflector.New("YARBUCHDQESFLGPIXJNKOMZTWV");
        /**
        <summary>I reflector C.</summary>
        */
        public static AlphabeticalReflector C => AlphabeticalReflector.New("FAVBPCJDIEOGYHRKZLXMWNTQUS");
        /**
        <inheritdoc cref="New(string, ValueTuple{string, string, string}, ValueTuple{int, int, int})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public EnigmaI()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.New(TEntrywheel, TReflector, TRotor[])" />
        */
        public static EnigmaI New(AlphabeticalEntrywheel entrywheel, AlphabeticalReflector reflector, params AlphabeticalRotor[] rotor)
            => throw new NotSupportedException();
        /**
        <inheritdoc cref="New(AlphabeticalEntrywheel, AlphabeticalReflector, AlphabeticalRotor[])" />
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        <param name="pos">The rotors' initial positions.</param>
        */
        public static EnigmaI New(string reflector, (string III, string II, string I) rotors, (int III, int II, int I) pos)
        {
            ArgumentException.ThrowIfNullOrEmpty(reflector);
            rotors.GetType()
                .GetFields()
                .Select(field => field.GetValue(rotors))
                .Cast<string>()
                .ToList()
                .ForEach(rotor => ArgumentException.ThrowIfNullOrEmpty(rotor));
            var enigma = new EnigmaI().Setup(AlphabeticalEntrywheel.Abc, GetReflector(reflector), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
            enigma.Rotors[0].Position = pos.I;
            enigma.Rotors[1].Position = pos.II;
            enigma.Rotors[2].Position = pos.III;
            return enigma;
        }
        private static AlphabeticalRotor GetRotor(string rotor)
            => new Dictionary<string, AlphabeticalRotor>(){
                {"I", I},
                {"II", II},
                {"III", III},
                {"IV", IV},
                {"V", V}
            }[rotor];
        private static AlphabeticalReflector GetReflector(string reflector)
            => new Dictionary<string, AlphabeticalReflector>(){
                {"A", A},
                {"B", B},
                {"C", C}
            }[reflector];
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Step()" />
        */
        public void Step() => this.Rotors.StepWithDoubleSteppingMechanism();
    }
}