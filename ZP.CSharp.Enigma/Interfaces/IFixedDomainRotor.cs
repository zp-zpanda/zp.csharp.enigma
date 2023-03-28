using System.Collections.Generic;
using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the fixed-domain rotor.</summary>
    */
    public interface IFixedDomainRotor<TRotor, TRotorPair, TSingle> : IRotor<TRotor, TRotorPair, TSingle>
        where TRotor : IFixedDomainRotor<TRotor, TRotorPair, TSingle>, new()
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        IEnumerable<TSingle> IRotor<TRotor, TRotorPair, TSingle>.Domain() => TRotor.FixedDomain();
        /**
        <summary>Gets the fixed domain.</summary>
        */
        public static abstract IEnumerable<TSingle> FixedDomain();
    }
}