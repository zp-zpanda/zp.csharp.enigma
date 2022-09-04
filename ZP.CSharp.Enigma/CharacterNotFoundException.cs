using System;
using System.Runtime.Serialization;
namespace ZP.CSharp.Enigma
{
    [Serializable]
    public class CharacterNotFoundException : Exception
    {
        public const string ErrorMessage = "Character not found.";
        public CharacterNotFoundException() : base(ErrorMessage)
        {}
        public CharacterNotFoundException(Exception inner) : base(ErrorMessage, inner)
        {}
        protected CharacterNotFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {}
    }
}