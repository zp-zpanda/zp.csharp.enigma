using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the fixed-domain rotor.</summary>
    */
    public interface IFixedDomainRotor<TRotor, TRotorPair> : IRotor<TRotor, TRotorPair>
        where TRotor : IFixedDomainRotor<TRotor, TRotorPair>
        where TRotorPair : IRotorPair<TRotorPair>
    {
        string IRotor<TRotor, TRotorPair>.Domain() => TRotor.FixedDomain();
        /**
        <summary>Gets the fixed domain.</summary>
        */
        public static abstract string FixedDomain();
    }
}