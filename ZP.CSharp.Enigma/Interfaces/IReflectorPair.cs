using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The generic interface for the reflector pair.</summary>
    */
    public interface IReflectorPair<TReflectorPair, TSingle>
        where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>The mapping.</summary>
        */
        public (TSingle One, TSingle Two) Map {get; set;}
        /**
        <summary>Creates a reflector pair with two characters.</summary>
        <param name="one">The first character.</param>
        <param name="two">The second character.</param>
        */
        public static abstract TReflectorPair New(TSingle one, TSingle two);
    }
}