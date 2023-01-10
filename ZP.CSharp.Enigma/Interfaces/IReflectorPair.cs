using System;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the reflector pair.</summary>
    */
    public interface IReflectorPair
    {
        /**
        <summary>The mapping.</summary>
        */
        public (char One, char Two) Map {get; set;}
    }
    /**
    <summary>The generic interface for the reflector pair.</summary>
    */
    public interface IReflectorPair<TReflectorPair> : IReflectorPair
        where TReflectorPair : IReflectorPair<TReflectorPair>, IReflectorPair
    {
        /**
        <summary>Creates a reflector pair with two characters.</summary>
        <param name="one">The first character.</param>
        <param name="two">The second character.</param>
        */
        public static abstract TReflectorPair New(char one, char two);
    }
}