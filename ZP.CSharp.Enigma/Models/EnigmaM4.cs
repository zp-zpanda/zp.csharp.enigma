using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Implementations;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>Enigma M4 implementation, used by the Kriegsmarine.</summary>
    */
    public class EnigmaM4 : IEnigma<EnigmaM4, AlphabeticalEntrywheel, EntrywheelPair, AlphabeticalRotor, AlphabeticalRotorPair, AlphabeticalReflector, AlphabeticalReflectorPair>
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
        private AlphabeticalRotor _FourthRotor;
        /**
        <summary>The fourth rotor this enigma has.</summary>
        */
        public AlphabeticalRotor FourthRotor {get => this._FourthRotor; set => this._FourthRotor = value;}
        private AlphabeticalReflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.Reflector" />
        */
        public AlphabeticalReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <summary>M4 rotor I.</summary>
        */
        public static AlphabeticalRotor I => AlphabeticalRotor.New(0, new[]{16}, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");
        /**
        <summary>M4 rotor II.</summary>
        */
        public static AlphabeticalRotor II => AlphabeticalRotor.New(0, new[]{4}, "AJDKSIRUXBLHWTMCQGZNPYFVOE");
        /**
        <summary>M4 rotor III.</summary>
        */
        public static AlphabeticalRotor III => AlphabeticalRotor.New(0, new[]{21}, "BDFHJLCPRTXVZNYEIWGAKMUSQO");
        /**
        <summary>M4 rotor IV.</summary>
        */
        public static AlphabeticalRotor IV => AlphabeticalRotor.New(0, new[]{9}, "ESOVPZJAYQUIRHXLNFTGKDCMWB");
        /**
        <summary>M4 rotor V.</summary>
        */
        public static AlphabeticalRotor V => AlphabeticalRotor.New(0, new[]{25}, "VZBRGITYUPSDNHLXAWMJQOFECK");
        /**
        <summary>M4 rotor VI.</summary>
        */
        public static AlphabeticalRotor VI => AlphabeticalRotor.New(0, new[]{25, 12}, "JPGVOUMFYQBENHZRDKASXLICTW");
        /**
        <summary>M4 rotor VII.</summary>
        */
        public static AlphabeticalRotor VII => AlphabeticalRotor.New(0, new[]{25, 12}, "NZJHGRCXMYSWBOUFAIVLPEKQDT");
        /**
        <summary>M4 rotor VIII.</summary>
        */
        public static AlphabeticalRotor VIII => AlphabeticalRotor.New(0, new[]{25, 12}, "FKQHTLXOCBJSPDZRAMEWNIUYGV");
        /**
        <summary>M4 rotor Beta.</summary>
        */
        public static AlphabeticalRotor Beta => AlphabeticalRotor.New(0, new[]{0}, "LEYJVCNIXWPBQMDRTAKZGFUHOS");
        /**
        <summary>M4 rotor Gamma.</summary>
        */
        public static AlphabeticalRotor Gamma => AlphabeticalRotor.New(0, new[]{0}, "FSOKANUERHMBTIYCWLQPZXVGJD");
        /**
        <summary>M4 reflector B.</summary>
        */
        public static AlphabeticalReflector B => AlphabeticalReflector.New("AEBNCKDQFUGYHWIJLOMPRXSZTV");
        /**
        <summary>M4 reflector C.</summary>
        */
        public static AlphabeticalReflector C => AlphabeticalReflector.New("ARBDCOEJFNGTHKIVLMPWQZSXUY");
        /**
        <inheritdoc cref="New(string, ValueTuple{string, string, string, string}, ValueTuple{int, int, int, int})" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public EnigmaM4(string reflector, (string IV, string III, string II, string I) rotors, (int IV, int III, int II, int I) pos)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(reflector);
            rotors.GetType()
                .GetFields()
                .Select(field => field.GetValue(rotors))
                .Cast<string>()
                .ToList()
                .ForEach(rotor => ArgumentException.ThrowIfNullOrEmpty(rotor));
            this.Setup(AlphabeticalEntrywheel.Abc, GetReflector(reflector), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
            this.Rotors[0].Position = pos.I;
            this.Rotors[1].Position = pos.II;
            this.Rotors[2].Position = pos.III;
            this.FourthRotor = GetFourthRotor(rotors.IV);
            this.FourthRotor.Position = pos.IV;
        }
        /**
        <inheritdoc cref="Enigma.New(Entrywheel, Reflector, Rotor[])" />
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        <param name="pos">The rotors' initial positions.</param>
        */
        public static EnigmaM4 New(string reflector, (string IV, string III, string II, string I) rotors, (int IV, int III, int II, int I) pos)
            => new(reflector, rotors, pos);
        private static AlphabeticalRotor GetRotor(string rotor)
            => new Dictionary<string, AlphabeticalRotor>(){
                {"I", I},
                {"II", II},
                {"III", III},
                {"IV", IV},
                {"V", V},
                {"VI", VI},
                {"VII", VII},
                {"VIII", VIII}
            }[rotor];
        private static AlphabeticalRotor GetFourthRotor(string rotor)
            => new Dictionary<string, AlphabeticalRotor>(){
                {"Beta", Beta},
                {"Gamma", Gamma}
            }[rotor];
        private static AlphabeticalReflector GetReflector(string reflector)
            => new Dictionary<string, AlphabeticalReflector>(){
                {"B", B},
                {"C", C}
            }[reflector];
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair}.RunOn(char)" />
        */
        public char RunOn(char c)
        {
            this.Step();
            return Enumerable.Empty<char>()
            .Append(c)
            .Select(c => this.Entrywheel.FromPlugboard(c))
            .Select(c => this.Rotors.Aggregate(c, (c, rotor) => rotor.FromEntryWheel(c)))
            .Select(c => this.FourthRotor.FromEntryWheel(c))
            .Select(c => this.Reflector.Reflect(c))
            .Select(c => this.FourthRotor.FromReflector(c))
            .Select(c => this.Rotors.Reverse().Aggregate(c, (c, rotor) => rotor.FromReflector(c)))
            .Select(c => this.Entrywheel.FromReflector(c))
            .Single();
        }
        /**
        <inheritdoc cref="Enigma.Step()" />
        */
        public void Step() => this.Rotors.StepWithDoubleSteppingMechanism();
    }
}