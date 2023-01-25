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
        
        */
        public class WithStringChar
            : IStringCharEnigma<WithStringChar,
                StringCharEntrywheel,
                StringCharEntrywheelPair,
                StringCharRotor,
                StringCharRotorPair,
                RotateableReflector<StringCharReflector,
                    StringCharReflectorPair,
                    StringCharRotor,
                    StringCharRotorPair,
                    char>, StringCharReflectorPair>
        {
            private StringCharEntrywheel _Entrywheel;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Entrywheel" />
            */
            public required StringCharEntrywheel Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
            private StringCharRotor[] _Rotors = Array.Empty<StringCharRotor>();
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Rotors" />
            */
            public StringCharRotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
            private RotateableReflector<StringCharReflector, StringCharReflectorPair, StringCharRotor, StringCharRotorPair, char> _Reflector;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Reflector" />
            */
            public RotateableReflector<StringCharReflector, StringCharReflectorPair, StringCharRotor, StringCharRotorPair, char> Reflector {get => this._Reflector; set => this._Reflector = value;}
            /**
            <summary>I rotor I.</summary>
            */
            public static StringCharRotor I => StringCharRotor.New(0, new[]{9}, "1234567890", "6418270359");
            /**
            <summary>I rotor II.</summary>
            */
            public static StringCharRotor II => StringCharRotor.New(0, new[]{9}, "1234567890", "5841097632");
            /**
            <summary>I rotor III.</summary>
            */
            public static StringCharRotor III => StringCharRotor.New(0, new[]{9}, "1234567890", "3581620794");
            /**
            <inheritdoc cref="New(ValueTuple{string, string, string}, ValueTuple{int, int, int})" />
            */
            [SetsRequiredMembers]
            #pragma warning disable CS8618
            public WithStringChar()
            #pragma warning restore CS8618
            {}
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.New(TEntrywheel, TReflector, TRotor[])" />
            */
            public static WithStringChar New(StringCharEntrywheel entrywheel, RotateableReflector<StringCharReflector, StringCharReflectorPair, StringCharRotor, StringCharRotorPair, char> reflector, params StringCharRotor[] rotors)
                => new WithStringChar().Setup(entrywheel, reflector, rotors);
            /**
            <inheritdoc cref="New(StringCharEntrywheel, StringCharReflector, StringCharRotor[])" />
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
                var enigma = New(StringCharEntrywheel.New("1234567890", "1234567890"),
                    RotateableReflector<StringCharReflector,
                        StringCharReflectorPair,
                        StringCharRotor,
                        StringCharRotorPair,
                        char>.New(pos.Reflector, new[]{9}, StringCharReflector.New("1520374968"), "1234567890".ToCharArray()), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
                enigma.Rotors[0].Position = pos.I;
                enigma.Rotors[1].Position = pos.II;
                enigma.Rotors[2].Position = pos.III;
                return enigma;
            }
            private static StringCharRotor GetRotor(string rotor)
                => new Dictionary<string, StringCharRotor>(){
                    {"I", I},
                    {"II", II},
                    {"III", III}
                }[rotor];
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Step()" />
            */
            public void Step() => this.Rotors.Append(this.Reflector.Interface).ToArray().StepWithDoubleSteppingMechanism();
        }
        public class WithInt32
            : IEnigma<WithInt32,
                Entrywheel<int>,
                EntrywheelPair<int>,
                Rotor<int>,
                RotorPair<int>,
                RotateableReflector<Reflector<int>,
                    ReflectorPair<int>,
                    Rotor<int>,
                    RotorPair<int>,
                    int>,
                ReflectorPair<int>,
                IEnumerable<int>,
                int>
        {
            private Entrywheel<int> _Entrywheel;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Entrywheel" />
            */
            public required Entrywheel<int> Entrywheel {get => this._Entrywheel; set => this._Entrywheel = value;}
            private Rotor<int>[] _Rotors = Array.Empty<Rotor<int>>();
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Rotors" />
            */
            public Rotor<int>[] Rotors {get => this._Rotors; set => this._Rotors = value;}
            private RotateableReflector<Reflector<int>, ReflectorPair<int>, Rotor<int>, RotorPair<int>, int> _Reflector;
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Reflector" />
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
            <inheritdoc cref="New(ValueTuple{string, string, string}, ValueTuple{int, int, int})" />
            */
            [SetsRequiredMembers]
            #pragma warning disable CS8618
            public WithInt32()
            #pragma warning restore CS8618
            {}
            /**
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.New(TEntrywheel, TReflector, TRotor[])" />
            */
            public static WithInt32 New(Entrywheel<int> entrywheel, RotateableReflector<Reflector<int>, ReflectorPair<int>, Rotor<int>, RotorPair<int>, int> reflector, params Rotor<int>[] rotors)
                => new WithInt32().Setup(entrywheel, reflector, rotors);
            /**
            <inheritdoc cref="New(StringCharEntrywheel, StringCharReflector, StringCharRotor[])" />
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
                    RotateableReflector<Reflector<int>,
                        ReflectorPair<int>,
                        Rotor<int>,
                        RotorPair<int>,
                        int>.New(pos.Reflector, new[]{9}, Reflector<int>.New(new[]{1, 5, 2, 0, 3, 7, 4, 9, 6, 8}), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}), GetRotor(rotors.I), GetRotor(rotors.II), GetRotor(rotors.III));
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
            <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Step()" />
            */
            public void Step() => this.Rotors.Append(this.Reflector.Interface).ToArray().StepWithDoubleSteppingMechanism();
        }
    }
}