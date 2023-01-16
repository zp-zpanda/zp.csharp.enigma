using System;
using System.Runtime.Serialization;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>Represents the situation where no character could be found.</summary>
    <seealso cref="IRotor{TRotor, TRotorPair}.FromEntryWheel(char)" />
    <seealso cref="IRotor{TRotor, TRotorPair}.FromReflector(char)" />
    <seealso cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.FromPlugboard(char)" />
    <seealso cref="IEntrywheel{TEntrywheel, TEntrywheelPair}.FromReflector(char)" />
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