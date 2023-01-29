using System;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>Options for the enigma.</summary>
    */
    [Flags]
    public enum EnigmaOptions
    {
        /**
        <summary>No options are provided.</summary>
        */
        Normal = 0,
        /**
        <summary>Rotors cannot step.</summary>
        */
        NoStepping = 1
    }
}