using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the fixed-domain rotor.</summary>
    */
    public interface IFixedDomainRotor<TRotor, TRotorPair, TSingle> : IRotor<TRotor, TRotorPair, TSingle>
        where TRotor : IFixedDomainRotor<TRotor, TRotorPair, TSingle>
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>Gets the fixed domain.</summary>
        */
        public static abstract TSingle[] FixedDomain();
    }
}