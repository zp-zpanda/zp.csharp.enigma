using System;
using System.Diagnostics.CodeAnalysis;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The string-char enigma.</summary>
    */
    public class StringCharEnigma : IStringCharEnigma<StringCharEnigma, StringCharEntrywheel, StringCharEntrywheelPair, StringCharRotor, StringCharRotorPair, StringCharReflector, StringCharReflectorPair>
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
        public required StringCharRotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        private StringCharReflector _Reflector;
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Reflector" />
        */
        public required StringCharReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        /**
        <inheritdoc cref="New(StringCharEntrywheel, StringCharReflector, StringCharRotor[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public StringCharEnigma()
        #pragma warning restore CS8618
        {}
        /**
        <summary>Creates a enigma with the rotors and the reflector provided.</summary>
        <param name="entrywheel">The entrywheel.</param>
        <param name="reflector">The reflector.</param>
        <param name="rotors">The rotors.</param>
        */
        public static StringCharEnigma New(StringCharEntrywheel entrywheel, StringCharReflector reflector, params StringCharRotor[] rotors)
        {
            ArgumentNullException.ThrowIfNull(reflector);
            ArgumentNullException.ThrowIfNull(rotors);
            return new StringCharEnigma().Setup(entrywheel, reflector, rotors);
        }
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.Step()" />
        */
        public void Step() {}
    }
}