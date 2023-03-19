using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma.Implementations;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Models
{
    /**
    <summary>Enigma Z implementations.</summary>
    */
    public class EnigmaZ
    {
        /**
        <summary>Enigma Z implementations with string-char components.</summary>
        */
        public class WithStringChar : IEnigma<WithStringChar, Entrywheel<char>, EntrywheelPair<char>, Rotor<char>, RotorPair<char>, RotateableReflector<Reflector<char>, ReflectorPair<char>, Rotor<char>, RotorPair<char>, char>, ReflectorPair<char>, char>
        {
            private Entrywheel<char> _Entrywheel;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Entrywheel" />
            */
            public required Entrywheel<char> Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
            private Rotor<char>[] _Rotors = Array.Empty<Rotor<char>>();
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Rotors" />
            */
            public Rotor<char>[] Rotors {get => this._Rotors; set => this._Rotors = value;}
            private RotateableReflector<Reflector<char>, ReflectorPair<char>, Rotor<char>, RotorPair<char>, char> _Reflector;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Reflector" />
            */
            public RotateableReflector<Reflector<char>, ReflectorPair<char>, Rotor<char>, RotorPair<char>, char> Reflector {get => this._Reflector; set => this._Reflector = value;}
            /**
            <summary>I rotor I.</summary>
            */
            public static Rotor<char> I => Rotor<char>.New(0, new[]{9}, "1234567890", "6418270359");
            /**
            <summary>I rotor II.</summary>
            */
            public static Rotor<char> II => Rotor<char>.New(0, new[]{9}, "1234567890", "5841097632");
            /**
            <summary>I rotor III.</summary>
            */
            public static Rotor<char> III => Rotor<char>.New(0, new[]{9}, "1234567890", "3581620794");
            /**
            <inheritdoc cref="New(ValueTuple{string, string, string}, ValueTuple{int, int, int, int})" />
            */
            [SetsRequiredMembers]
            #pragma warning disable CS8618
            public WithStringChar()
            #pragma warning restore CS8618
            {}
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.New(TEntrywheel, IEnumerable{TRotor}, TReflector)" />
            */
            public static WithStringChar New(Entrywheel<char> entrywheel, IEnumerable<Rotor<char>> rotors, RotateableReflector<Reflector<char>, ReflectorPair<char>, Rotor<char>, RotorPair<char>, char> reflector)
                => new WithStringChar().Setup(entrywheel, rotors, reflector);
            /**
            <inheritdoc cref="New(Entrywheel{char}, IEnumerable{Rotor{char}}, RotateableReflector{Reflector{char}, ReflectorPair{char}, Rotor{char}, RotorPair{char}, char})" />
            <param name="rotors">The rotors.</param>
            <param name="pos">The rotors' initial positions.</param>
            */
            public static WithStringChar New((string III, string II, string I) rotors, (int Reflector, int III, int II, int I) pos)
            {
                rotors.GetType()
                    .GetFields()
                    .Select(field => field.GetValue(rotors))
                    .Cast<string>()
                    .ToList()
                    .ForEach(rotor => ArgumentException.ThrowIfNullOrEmpty(rotor));
                var enigma = New(Entrywheel<char>.New("1234567890", "1234567890"),
                    new[]{GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III)},
                    RotateableReflector<Reflector<char>,
                        ReflectorPair<char>,
                        Rotor<char>,
                        RotorPair<char>,
                        char>.New(pos.Reflector, new[]{9}, Reflector<char>.New("1520374968"), "1234567890"));
                enigma.Rotors[0].Position = pos.I;
                enigma.Rotors[1].Position = pos.II;
                enigma.Rotors[2].Position = pos.III;
                return enigma;
            }
            private static Rotor<char> GetRotor(string rotor)
                => new Dictionary<string, Rotor<char>>(){
                    {"I", I},
                    {"II", II},
                    {"III", III}
                }[rotor];
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Step()" />
            */
            public void Step() => this.Rotors.Append(this.Reflector.Interface).StepWithDoubleSteppingMechanism();
        }
        /**
        <summary>Enigma Z implementations with int components.</summary>
        */
        public class WithInt32 : IEnigma<WithInt32, Entrywheel<int>, EntrywheelPair<int>, Rotor<int>, RotorPair<int>, RotateableReflector<Reflector<int>, ReflectorPair<int>, Rotor<int>, RotorPair<int>, int>, ReflectorPair<int>, int>
        {
            private Entrywheel<int> _Entrywheel;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Entrywheel" />
            */
            public required Entrywheel<int> Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
            private Rotor<int>[] _Rotors = Array.Empty<Rotor<int>>();
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Rotors" />
            */
            public Rotor<int>[] Rotors {get => this._Rotors; set => this._Rotors = value;}
            private RotateableReflector<Reflector<int>, ReflectorPair<int>, Rotor<int>, RotorPair<int>, int> _Reflector;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Reflector" />
            */
            public RotateableReflector<Reflector<int>, ReflectorPair<int>, Rotor<int>, RotorPair<int>, int> Reflector {get => this._Reflector; set => this._Reflector = value;}
            /**
            <summary>I rotor I.</summary>
            */
            public static Rotor<int> I => Rotor<int>.New(0, new[]{9}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{6, 4, 1, 8, 2, 7, 0, 3, 5, 9});
            /**
            <summary>I rotor II.</summary>
            */
            public static Rotor<int> II => Rotor<int>.New(0, new[]{9}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{5, 8, 4, 1, 0, 9, 7, 6, 3, 2});
            /**
            <summary>I rotor III.</summary>
            */
            public static Rotor<int> III => Rotor<int>.New(0, new[]{9}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{3, 5, 8, 1, 6, 2, 0, 7, 9, 4});
            /**
            <inheritdoc cref="New(ValueTuple{string, string, string}, ValueTuple{int, int, int, int})" />
            */
            [SetsRequiredMembers]
            #pragma warning disable CS8618
            public WithInt32()
            #pragma warning restore CS8618
            {}
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.New(TEntrywheel, IEnumerable{TRotor}, TReflector)" />
            */
            public static WithInt32 New(Entrywheel<int> entrywheel, IEnumerable<Rotor<int>> rotors, RotateableReflector<Reflector<int>, ReflectorPair<int>, Rotor<int>, RotorPair<int>, int> reflector)
                => new WithInt32().Setup(entrywheel, rotors, reflector);
            /**
            <inheritdoc cref="New(Entrywheel{int}, IEnumerable{Rotor{int}}, RotateableReflector{Reflector{int}, ReflectorPair{int}, Rotor{int}, RotorPair{int}, int})" />
            <param name="rotors">The rotors.</param>
            <param name="pos">The rotors' initial positions.</param>
            */
            public static WithInt32 New((string III, string II, string I) rotors, (int Reflector, int III, int II, int I) pos)
            {
                rotors.GetType()
                    .GetFields()
                    .Select(field => field.GetValue(rotors))
                    .Cast<string>()
                    .ToList()
                    .ForEach(rotor => ArgumentException.ThrowIfNullOrEmpty(rotor));
                var enigma = New(Entrywheel<int>.New(new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}),
                    new[]{GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III)},
                    RotateableReflector<Reflector<int>,
                        ReflectorPair<int>,
                        Rotor<int>,
                        RotorPair<int>,
                        int>.New(pos.Reflector, new[]{9}, Reflector<int>.New(new[]{1, 5, 2, 0, 3, 7, 4, 9, 6, 8}), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}));
                enigma.Rotors[0].Position = pos.I;
                enigma.Rotors[1].Position = pos.II;
                enigma.Rotors[2].Position = pos.III;
                return enigma;
            }
            private static Rotor<int> GetRotor(string rotor)
                => new Dictionary<string, Rotor<int>>(){
                    {"I", I},
                    {"II", II},
                    {"III", III}
                }[rotor];
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle}.Step()" />
            */
            public void Step() => this.Rotors.Append(this.Reflector.Interface).StepWithDoubleSteppingMechanism();
        }
    }
}