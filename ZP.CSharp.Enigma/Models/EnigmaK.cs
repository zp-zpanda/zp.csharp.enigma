using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>Enigma K implementation.</summary>
    */
    public class EnigmaK : IEnigma<EnigmaK, AlphabeticalEntrywheel, AlphabeticalEntrywheelPair, AlphabeticalRotor, AlphabeticalRotorPair, AlphabeticalReflector, AlphabeticalReflectorPair, char>
    {
        private AlphabeticalEntrywheel _Entrywheel;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Entrywheel" />
        */
        public required AlphabeticalEntrywheel Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        private AlphabeticalRotor[] _Rotors = Array.Empty<AlphabeticalRotor>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Rotors" />
        */
        public AlphabeticalRotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private AlphabeticalReflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Reflector" />
        */
        public AlphabeticalReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <summary>K rotor I.</summary>
        */
        public static AlphabeticalRotor I => AlphabeticalRotor.New(0, new[]{24}, "LPGSZMHAEOQKVXRFYBUTNICJDW");
        /**
        <summary>K rotor II.</summary>
        */
        public static AlphabeticalRotor II => AlphabeticalRotor.New(0, new[]{4}, "SLVGBTFXJQOHEWIRZYAMKPCNDU");
        /**
        <summary>K rotor III.</summary>
        */
        public static AlphabeticalRotor III => AlphabeticalRotor.New(0, new[]{13}, "CJGDPSHKTURAWZXFMYNQOBVLIE");
        /**
        <inheritdoc cref="New(ValueTuple{string, string, string}, ValueTuple{int, int, int})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public EnigmaK()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.New(TEntrywheel, IEnumerable{TRotor}, TReflector)" />
        */
        public static EnigmaK New(AlphabeticalEntrywheel entrywheel, IEnumerable<AlphabeticalRotor> rotors, AlphabeticalReflector reflector)
            => throw new NotSupportedException();
        /**
        <inheritdoc cref="New(AlphabeticalEntrywheel, IEnumerable{AlphabeticalRotor}, AlphabeticalReflector)" />
        <param name="rotors">The rotors.</param>
        <param name="pos">The rotors' initial positions.</param>
        */
        public static EnigmaK New((string III, string II, string I) rotors, (int III, int II, int I) pos)
        {
            rotors.GetType()
                .GetFields()
                .Select(field => field.GetValue(rotors))
                .Cast<string>()
                .ToList()
                .ForEach(rotor => ArgumentException.ThrowIfNullOrEmpty(rotor));
            var enigma = new EnigmaK().Setup(AlphabeticalEntrywheel.Qwertz, new[]{GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III)}, AlphabeticalReflector.New("AIBMCEDTFGHRJYKSLQNZOXPWUV"));
            enigma.Rotors[0].Position = pos.I;
            enigma.Rotors[1].Position = pos.II;
            enigma.Rotors[2].Position = pos.III;
            return enigma;
        }
        private static AlphabeticalRotor GetRotor(string rotor)
            => new Dictionary<string, AlphabeticalRotor>(){
                {"I", I},
                {"II", II},
                {"III", III}
            }[rotor];
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Step()" />
        */
        public void Step() => this.Rotors.StepWithDoubleSteppingMechanism();
    }
}