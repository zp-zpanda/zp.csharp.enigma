using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The generic interface for the entrywheels pair.</summary>
    */
    public interface IEntrywheelPair<TEntrywheelPair, TSingle>
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>The mapping.</summary>
        */
        public (TSingle PlugboardSide, TSingle ReflectorSide) Map {get; set;}
        /**
        <summary>Creates a entrywheel pair with two characters.</summary>
        <param name="pSide">The character on the plugboard side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static abstract TEntrywheelPair New(TSingle pSide, TSingle rSide);
    }
}