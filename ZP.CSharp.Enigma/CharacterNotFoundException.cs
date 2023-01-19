using System;
using System.Runtime.Serialization;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>Represents the situation where no character could be found.</summary>
    <seealso cref="IRotor{TRotor, TRotorPair, TSingle}.FromEntryWheel(TSingle)" />
    <seealso cref="IRotor{TRotor, TRotorPair, TSingle}.FromReflector(TSingle)" />
    <seealso cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.FromPlugboard(TSingle)" />
    <seealso cref="IEntrywheel{TEntrywheel, TEntrywheelPair, TSingle}.FromReflector(TSingle)" />
    */
    [Serializable]
    public class CharacterNotFoundException : Exception
    {
        /**
        <summary>The error message.</summary>
        */
        public const string ErrorMessage = "Character not found.";
        /**
        <seealso cref="Exception(string)" />
        */
        public CharacterNotFoundException() : base(ErrorMessage)
        {}
        /**
        <seealso cref="Exception(string, Exception)" />
        */
        public CharacterNotFoundException(Exception inner) : base(ErrorMessage, inner)
        {}
        /**
        <seealso cref="Exception(SerializationInfo, StreamingContext)" />
        */
        protected CharacterNotFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {}
    }
}