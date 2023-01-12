using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
using ZP.CSharp.Enigma.Models;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>Enigma K implementation.</summary>
    */
    public class EnigmaK : IEnigma<EnigmaK, AlphabeticalEntrywheel, EntrywheelPair, AlphabeticalRotor, AlphabeticalRotorPair, AlphabeticalReflector, AlphabeticalReflectorPair>
    {
        private AlphabeticalEntrywheel _Entrywheel;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Entrywheel" />
        */
        public required AlphabeticalEntrywheel Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
        private AlphabeticalRotor[] _Rotors = Array.Empty<AlphabeticalRotor>();
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Rotors" />
        */
        public AlphabeticalRotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private AlphabeticalReflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Reflector" />
        */
        public AlphabeticalReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <summary>K rotor I.</summary>
        */
        public static AlphabeticalRotor I {get => AlphabeticalRotor.New(0, new[]{24}, "LPGSZMHAEOQKVXRFYBUTNICJDW");}
        /**
        <summary>K rotor II.</summary>
        */
        public static AlphabeticalRotor II {get => AlphabeticalRotor.New(0, new[]{4}, "SLVGBTFXJQOHEWIRZYAMKPCNDU");}
        /**
        <summary>K rotor III.</summary>
        */
        public static AlphabeticalRotor III {get => AlphabeticalRotor.New(0, new[]{13}, "CJGDPSHKTURAWZXFMYNQOBVLIE");}
        /**
        <inheritdoc cref="Enigma.Enigma(Entrywheel, Reflector, Rotor[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public EnigmaK((string III, string II, string I) rotors, (int III, int II, int I) pos)
        #pragma warning restore CS8618
        {
            rotors.GetType()
                .GetFields()
                .Select(field => field.GetValue(rotors))
                .Cast<string>()
                .ToList()
                .ForEach(rotor => ArgumentException.ThrowIfNullOrEmpty(rotor));
            this.Setup(AlphabeticalEntrywheel.Qwertz, AlphabeticalReflector.New("AIBMCEDTFGHRJYKSLQNZOXPWUV"), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
            this.Rotors[0].Position = pos.I;
            this.Rotors[1].Position = pos.II;
            this.Rotors[2].Position = pos.III;
        }
        /**
        <inheritdoc cref="Enigma.New(Entrywheel, Reflector, Rotor[])" />
        <param name="rotors">The rotors.</param>
        <param name="pos">The rotors' initial positions.</param>
        */
        public static EnigmaK New((string III, string II, string I) rotors, (int III, int II, int I) pos)
            => new(rotors, pos);
        private static AlphabeticalRotor GetRotor(string rotor)
        {
            return new Dictionary<string, AlphabeticalRotor>(){
                {"I", I},
                {"II", II},
                {"III", III}
            }[rotor];
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Step()" />
        */
        public void Step() => this.Rotors.StepWithDoubleSteppingMechanism();
    }
}