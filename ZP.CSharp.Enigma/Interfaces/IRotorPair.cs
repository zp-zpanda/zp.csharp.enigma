using System;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the rotor pair.</summary>
    */
    public interface IRotorPair
    {
        /**
        <summary>The mapping.</summary>
        */
        public (char EntryWheelSide, char ReflectorSide) Map {get; set;}
    }
    /**
    <summary>The generic interface for the rotor pair.</summary>
    */
    public interface IRotorPair<TRotorPair> : IRotorPair
        where TRotorPair : IRotorPair<TRotorPair>, IRotorPair
    {
        /**
        <summary>Creates a rotor pair with two characters.</summary>
        <param name="eSide">The character on the entry wheel side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static abstract TRotorPair New(char eSide, char rSide);
        /**
        <summary>Creates a rotor pair with a two-character-long map.</summary>
        <param name="map">The mapping.</param>
        */
        public static abstract TRotorPair New(string map);
    }
}