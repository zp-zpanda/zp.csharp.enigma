using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The generic interface for the rotor pair.</summary>
    */
    public interface IRotorPair<TRotorPair, TSingle>
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TSingle :IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>The mapping.</summary>
        */
        public (TSingle EntryWheelSide, TSingle ReflectorSide) Map {get; set;}
        /**
        <summary>Creates a rotor pair with two characters.</summary>
        <param name="eSide">The character on the entry wheel side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static abstract TRotorPair New(TSingle eSide, TSingle rSide);
    }
}